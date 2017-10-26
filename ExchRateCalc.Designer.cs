namespace CRMGG.ExchangeRates
{
    partial class ExchRateCalc
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExchRateCalc));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EuropeanCentralBank = new System.Windows.Forms.LinkLabel();
            this.RussiaCentralBank = new System.Windows.Forms.LinkLabel();
            this.SloveniaCentralBank = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.webservicex = new System.Windows.Forms.LinkLabel();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(882, 25);
            this.toolStripMenu.TabIndex = 5;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CRMGG.ExchangeRates.Properties.Resources.get_currencies;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(133, 22);
            this.toolStripButton1.Text = "Get CRM Currencies";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::CRMGG.ExchangeRates.Properties.Resources.get_exc_rates;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(210, 22);
            this.toolStripButton2.Text = "Get Exchange Rates from Providers";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::CRMGG.ExchangeRates.Properties.Resources.conversion_of_currency;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(191, 22);
            this.toolStripButton3.Text = "Update Exchange Rates in CRM";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::CRMGG.ExchangeRates.Properties.Resources.save_as;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(102, 22);
            this.toolStripButton4.Text = "Save Mapping";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(12, 41);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(83, 13);
            this.lblDefaultCurrency.TabIndex = 7;
            this.lblDefaultCurrency.Text = "DefaultCurrency";
            this.lblDefaultCurrency.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(15, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(849, 343);
            this.dataGridView1.TabIndex = 8;
            // 
            // EuropeanCentralBank
            // 
            this.EuropeanCentralBank.AutoSize = true;
            this.EuropeanCentralBank.Location = new System.Drawing.Point(14, 163);
            this.EuropeanCentralBank.Name = "EuropeanCentralBank";
            this.EuropeanCentralBank.Size = new System.Drawing.Size(117, 13);
            this.EuropeanCentralBank.TabIndex = 10;
            this.EuropeanCentralBank.TabStop = true;
            this.EuropeanCentralBank.Text = "European Central Bank";
            this.EuropeanCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EuropeanCentralBank_LinkClicked);
            // 
            // RussiaCentralBank
            // 
            this.RussiaCentralBank.AutoSize = true;
            this.RussiaCentralBank.Location = new System.Drawing.Point(157, 163);
            this.RussiaCentralBank.Name = "RussiaCentralBank";
            this.RussiaCentralBank.Size = new System.Drawing.Size(103, 13);
            this.RussiaCentralBank.TabIndex = 11;
            this.RussiaCentralBank.TabStop = true;
            this.RussiaCentralBank.Text = "Russia Central Bank";
            this.RussiaCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RussiaCentralBank_LinkClicked);
            // 
            // SloveniaCentralBank
            // 
            this.SloveniaCentralBank.AutoSize = true;
            this.SloveniaCentralBank.Location = new System.Drawing.Point(289, 163);
            this.SloveniaCentralBank.Name = "SloveniaCentralBank";
            this.SloveniaCentralBank.Size = new System.Drawing.Size(349, 13);
            this.SloveniaCentralBank.TabIndex = 12;
            this.SloveniaCentralBank.TabStop = true;
            this.SloveniaCentralBank.Text = "Slovenia Central Bank (Currencies not published as ECB reference rates)";
            this.SloveniaCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SloveniaCentralBank_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 78);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // webservicex
            // 
            this.webservicex.AutoSize = true;
            this.webservicex.Location = new System.Drawing.Point(671, 163);
            this.webservicex.Name = "webservicex";
            this.webservicex.Size = new System.Drawing.Size(142, 13);
            this.webservicex.TabIndex = 15;
            this.webservicex.TabStop = true;
            this.webservicex.Text = "http://www.webservicex.net";
            this.webservicex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webservicex_LinkClicked);
            // 
            // ExchRateCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.webservicex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SloveniaCentralBank);
            this.Controls.Add(this.RussiaCentralBank);
            this.Controls.Add(this.EuropeanCentralBank);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDefaultCurrency);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "ExchRateCalc";
            this.Size = new System.Drawing.Size(882, 551);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.LinkLabel EuropeanCentralBank;
        private System.Windows.Forms.LinkLabel RussiaCentralBank;
        private System.Windows.Forms.LinkLabel SloveniaCentralBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.LinkLabel webservicex;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}
