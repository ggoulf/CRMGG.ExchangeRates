using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.Messages;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using Microsoft.Xrm.Sdk.Query;
using System.Text;
using Microsoft.Xrm.Sdk;
using System.Collections;
using System.Data;
using Providers;
using ExchangeRate;

namespace CRMGG.ExchangeRates
{
    public partial class ExchRateCalc : PluginControlBase, IGitHubPlugin, IHelpPlugin, IStatusBarMessenger
    {
        #region Base tool implementation

        EntityCollection default_ent = null;
        Hashtable exchangeRateProvidersList = new Hashtable();
        string organizationDefaultisocurrencycode = "";

        public ExchRateCalc()
        {
            InitializeComponent();




            setExchangeRateProviders();
            LogInfo("An information message");
            LogWarning("A warning message");
            LogError("An error message");



        }

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        private void setExchangeRateProviders()
        {

            foreach (CurrencyProvider p in Enum.GetValues(typeof(CurrencyProvider)))
            {
                int providerNumber = (int)p;
                CurrencyHelper CH = new CurrencyHelper();
                CH.setProvider(providerNumber);
                exchangeRateProvidersList.Add(providerNumber, CH);



            }

        }

        private void GetCurrentCurrencies()
        {


            WorkAsync(new WorkAsyncInfo
            {

                Message = "Getting Current CRM Currencies...",
                Work = (w, e) =>
                {
                    //  QueryExpression query = new QueryExpression("organization");

                    // Instantiate QueryExpression QEtransactioncurrency
                    var QEtransactioncurrency = new QueryExpression("transactioncurrency");
                    QEtransactioncurrency.Distinct = true;

                    // Add columns to QEtransactioncurrency.ColumnSet
                    QEtransactioncurrency.ColumnSet.AddColumns("transactioncurrencyid", "currencyname", "isocurrencycode", "currencysymbol", "exchangerate", "currencyprecision");
                    QEtransactioncurrency.AddOrder("currencyname", OrderType.Ascending);

                    // Define filter QEtransactioncurrency.Criteria
                    QEtransactioncurrency.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);

                    // Add link-entity QEtransactioncurrency_organization
                    var QEtransactioncurrency_organization = QEtransactioncurrency.AddLink("organization", "transactioncurrencyid", "basecurrencyid");
                    QEtransactioncurrency_organization.EntityAlias = "ac";


                    EntityCollection default_ents = Service.RetrieveMultiple(QEtransactioncurrency);

                    Guid entid = (Guid)default_ents.Entities[0].Attributes["transactioncurrencyid"];
                    string entname = (string)default_ents.Entities[0].Attributes["currencyname"];


                    // Instantiate QueryExpression QEtransactioncurrency
                    QEtransactioncurrency = new QueryExpression("transactioncurrency");

                    // Add columns to QEtransactioncurrency.ColumnSet
                    QEtransactioncurrency.ColumnSet.AddColumns("transactioncurrencyid", "currencyname", "isocurrencycode", "currencysymbol", "exchangerate", "currencyprecision");
                    QEtransactioncurrency.AddOrder("currencyname", OrderType.Ascending);

                    // Define filter QEtransactioncurrency.Criteria
                    QEtransactioncurrency.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                    QEtransactioncurrency.Criteria.AddCondition("transactioncurrencyid", ConditionOperator.NotEqual, entid.ToString());





                    EntityCollection ents = Service.RetrieveMultiple(QEtransactioncurrency);

                    ArrayList arr = new ArrayList();
                    arr.Add(default_ents);
                    arr.Add(ents);

                    e.Result = arr;

                },
                ProgressChanged = e =>
                {

                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {

                   
                 
                    

                   ArrayList arr = (ArrayList)e.Result;

                    default_ent = (EntityCollection)arr[0];
                    EntityCollection ents = (EntityCollection)arr[1];
                    organizationDefaultisocurrencycode = default_ent[0].Attributes["isocurrencycode"].ToString();
                    lblDefaultCurrency.Text = "Organization Default Currency: " + (default_ent[0].Attributes["currencyname"].ToString() +
                            " (" + default_ent[0].Attributes["currencysymbol"].ToString() + "-" +
                            default_ent[0].Attributes["isocurrencycode"].ToString() + ")");

                    if (dataGridView1.Columns.Contains("comboProviderColumn"))
                    {
                        dataGridView1.Columns.Remove("comboProviderColumn");
                    }
                        DataTable crmCurrenciesTable = new DataTable();
                    crmCurrenciesTable.Columns.Add("ID");
                    crmCurrenciesTable.Columns.Add("Name");
                    crmCurrenciesTable.Columns.Add("IsoCurrencyCode");
                    crmCurrenciesTable.Columns.Add("Symbol");
                    crmCurrenciesTable.Columns.Add("CRM Rate");
                    crmCurrenciesTable.Columns.Add("New Rate");
                    crmCurrenciesTable.Columns.Add("Precision");


                    foreach (Entity ent in ents.Entities)
                    {
                        DataRow dr = crmCurrenciesTable.NewRow();
                        dr["ID"] = ((Guid)ent.Attributes["transactioncurrencyid"]).ToString();
                        dr["Name"] = ent.Attributes["currencyname"].ToString();
                        dr["IsoCurrencyCode"] = ent["isocurrencycode"].ToString();

                        dr["Symbol"] = ent.Attributes["currencysymbol"].ToString();
                        dr["CRM Rate"] = ent.Attributes["exchangerate"];

                        // dr["New Rate"] = Convert.ToDecimal(0);
                        //dr["Provider"] = "Bank";
                        dr["Precision"] = ent.Attributes["currencyprecision"];
                        crmCurrenciesTable.Rows.Add(dr);
                    }
                    dataGridView1.DataSource = crmCurrenciesTable;
                    dataGridView1.AutoGenerateColumns = true;

                    if (!dataGridView1.Columns.Contains("comboProviderColumn"))
                    {
                        //https://stackoverflow.com/questions/867514/make-listbox-items-have-a-different-value-than-item-text
                        //int value = (listBox1.SelectedItem as SomeData).Value;
                        List<Provider> providersList = new List<Provider>();
                        providersList.Add(new Provider() { Value = 0, Text = "Select your provider" });
                        CurrencyHelper CH = new CurrencyHelper();
                        foreach (CurrencyProvider p in Enum.GetValues(typeof(CurrencyProvider)))
                        {
                            int providerNumber = (int)p;


                            providersList.Add(new Provider()
                            {
                                Value = providerNumber,
                                Text = CH.getStrProvider(providerNumber)
                            });

                        }

                        DataGridViewComboBoxColumn providersCombo = new DataGridViewComboBoxColumn();
                        {
                            providersCombo.Name = "comboProviderColumn";
                            providersCombo.HeaderText = "Provider";
                            providersCombo.DisplayMember = "Text";
                            providersCombo.ValueMember = "Value";
                            providersCombo.DataSource = providersList;
                            providersCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                        }
                        dataGridView1.Columns.Add(providersCombo);
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int providerID = GetProviderID((string)dataGridView1.Rows[i].Cells["ID"].Value);
                        dataGridView1.Rows[i].Cells["comboProviderColumn"].Value = providerID;
                        if (exchangeRateProvidersList.ContainsKey(providerID))
                        {
                            decimal currentRates = ((CurrencyHelper)exchangeRateProvidersList[providerID]).getRate(organizationDefaultisocurrencycode, (string)dataGridView1.Rows[i].Cells["IsoCurrencyCode"].Value);
                            
                            dataGridView1.Rows[i].Cells["New Rate"].Value = checkExchRate(currentRates, ((CurrencyHelper)exchangeRateProvidersList[providerID]).getStrProvider(providerID), (string)dataGridView1.Rows[i].Cells["IsoCurrencyCode"].Value);
                        }

                    }
                    dataGridView1.Refresh();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
                    dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;



                },
                AsyncArgument = null,
                IsCancelable = false,
                MessageWidth = 340,
                MessageHeight = 150
            });



        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private decimal checkExchRate(decimal rate,string providername, string isocurrencycode)
        {
            if(rate <= 0)
            {
                MessageBox.Show(string.Format("Bad news. It seems that the provider {1} doesn't works today for the currency {0}, click on \"Get Exchange Rates from Providers\" to try again or select another provider.", isocurrencycode, providername));

                return 0;
            }
            else
            {
                return rate;
            }
        }

      
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[e.ColumnIndex];


            if (col is DataGridViewComboBoxColumn && col.Name == "comboProviderColumn")
            {

                string isocurrencycode = (string)dataGridView1.Rows[e.RowIndex].Cells["IsoCurrencyCode"].Value;
                int providerID = (int)dataGridView1.Rows[e.RowIndex].Cells["comboProviderColumn"].Value;
                if (exchangeRateProvidersList.ContainsKey(providerID))
                {
                    if (((CurrencyHelper)exchangeRateProvidersList[providerID]).isCurrencyAvailable(isocurrencycode) && ((CurrencyHelper)exchangeRateProvidersList[providerID]).isCurrencyAvailable(organizationDefaultisocurrencycode))
                    {
                        decimal currentRates = ((CurrencyHelper)exchangeRateProvidersList[providerID]).getRate(organizationDefaultisocurrencycode, isocurrencycode);

                        

                        dataGridView1.Rows[e.RowIndex].Cells["New Rate"].Value = checkExchRate(currentRates, ((CurrencyHelper)exchangeRateProvidersList[providerID]).getStrProvider(providerID), isocurrencycode);
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["New Rate"].Value = "";
                        MessageBox.Show(string.Format("There is no exchange rate between {0} and {1} for this provider, please select another provider.", isocurrencycode, organizationDefaultisocurrencycode));
                        
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["New Rate"].Value = "";
                }
            }
        }
        private int GetProviderID(String CurrencyId)
        {


            Settings settings;

            if (SettingsManager.Instance.TryLoad(typeof(ExchRateCalc), out settings))
            {
            }
            else
            {

                settings = new Settings
                {

                    ProviderSettings = new List<AssociateProvider>()
                };
            }
            foreach (AssociateProvider a in settings.ProviderSettings)
            {
                if (a.CurrencyID == CurrencyId)
                    return a.ProviderID;
            }
            return 0;
        }

        private void GetExchangeRates()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int providerID = (int)dataGridView1.Rows[i].Cells["comboProviderColumn"].Value;
                dataGridView1.Rows[i].Cells["comboProviderColumn"].Value = providerID;

                if (exchangeRateProvidersList.ContainsKey(providerID))
                {
                    decimal currentRates = ((CurrencyHelper)exchangeRateProvidersList[providerID]).getRate(organizationDefaultisocurrencycode, (string)dataGridView1.Rows[i].Cells["IsoCurrencyCode"].Value);
                    
                    dataGridView1.Rows[i].Cells["New Rate"].Value = checkExchRate(currentRates, ((CurrencyHelper)exchangeRateProvidersList[providerID]).getStrProvider(providerID), (string)dataGridView1.Rows[i].Cells["IsoCurrencyCode"].Value);
                }
            }
        }
        private void SaveMapping()
        {

            Settings settings;

            if (SettingsManager.Instance.TryLoad(typeof(ExchRateCalc), out settings))
            {
            }
            else
            {

                settings = new Settings
                {

                    ProviderSettings = new List<AssociateProvider>()
                };
            }



            settings.ProviderSettings = new List<AssociateProvider>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                settings.ProviderSettings.Add(new AssociateProvider { CurrencyID = (String)dataGridView1.Rows[i].Cells["ID"].Value, ProviderID = (int)dataGridView1.Rows[i].Cells["comboProviderColumn"].Value });
            }

            SettingsManager.Instance.Save(typeof(ExchRateCalc), settings);
        }

        private void UpdateCRMCurrencies()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Update of the exchange rates in CRM",
                Work = (w, e) =>
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {


                        Entity ent = new Entity("transactioncurrency");
                        ent.Attributes.Add("transactioncurrencyid", new Guid((string)dataGridView1.Rows[i].Cells["ID"].Value));
                        if (dataGridView1.Rows[i].Cells["New Rate"].Value == null || Convert.ToDecimal(dataGridView1.Rows[i].Cells["New Rate"].Value) == 0)
                        { continue; }
                        ent.Attributes.Add("exchangerate", Convert.ToDecimal(dataGridView1.Rows[i].Cells["New Rate"].Value));
                        Service.Update(ent);
                    }






                    w.ReportProgress(0, "Your exchange rates have been updated!");

                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Update of the exchange rates in CRM");
                },
                PostWorkCallBack = e =>
                {
                    //MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                },
                AsyncArgument = null,
                IsCancelable = false,
                MessageWidth = 340,
                MessageHeight = 150
            });

        }


        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            //MessageBox.Show("Custom logic here");

            base.ClosingPlugin(info);
        }





        

       

        private void SampleTool_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox reposiotry", new Uri("http://github.com/MscrmTools/XrmToolBox"));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HideNotification();

            ExecuteMethod(GetCurrentCurrencies);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            SaveMapping();
            GetExchangeRates();
        }

        private void EuropeanCentralBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/stats/policy_and_exchange_rates/euro_reference_exchange_rates/html/index.en.html");
        }

        private void RussiaCentralBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cbr.ru/eng/");
        }

        private void SloveniaCentralBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bsi.si/podatki/eksot-tec-en.asp?MapaId=1237");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveMapping();
            UpdateCRMCurrencies();
        }

        private void webservicex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.webservicex.net");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveMapping();
            MessageBox.Show("Your mapping has been save.");
         }

        #endregion Base tool implementation

        #region Github implementation

        public string RepositoryName
        {
            get { return "GithubRepositoryName"; }
        }

        public string UserName
        {
            get { return "GithubUserName"; }
        }

        #endregion Github implementation



 

        #region Help implementation

        public string HelpUrl
        {
            get { return "http://www.google.com"; }
        }

        #endregion Help implementation
    }
}