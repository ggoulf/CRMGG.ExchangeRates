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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EuropeanCentralBank = new System.Windows.Forms.LinkLabel();
            this.RussiaCentralBank = new System.Windows.Forms.LinkLabel();
            this.SloveniaCentralBank = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.webservicex = new System.Windows.Forms.LinkLabel();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1323, 32);
            this.toolStripMenu.TabIndex = 5;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(18, 63);
            this.lblDefaultCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(124, 20);
            this.lblDefaultCurrency.TabIndex = 7;
            this.lblDefaultCurrency.Text = "DefaultCurrency";
            this.lblDefaultCurrency.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(22, 302);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1274, 528);
            this.dataGridView1.TabIndex = 8;
            // 
            // EuropeanCentralBank
            // 
            this.EuropeanCentralBank.AutoSize = true;
            this.EuropeanCentralBank.Location = new System.Drawing.Point(21, 251);
            this.EuropeanCentralBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EuropeanCentralBank.Name = "EuropeanCentralBank";
            this.EuropeanCentralBank.Size = new System.Drawing.Size(175, 20);
            this.EuropeanCentralBank.TabIndex = 10;
            this.EuropeanCentralBank.TabStop = true;
            this.EuropeanCentralBank.Text = "European Central Bank";
            this.EuropeanCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EuropeanCentralBank_LinkClicked);
            // 
            // RussiaCentralBank
            // 
            this.RussiaCentralBank.AutoSize = true;
            this.RussiaCentralBank.Location = new System.Drawing.Point(236, 251);
            this.RussiaCentralBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RussiaCentralBank.Name = "RussiaCentralBank";
            this.RussiaCentralBank.Size = new System.Drawing.Size(154, 20);
            this.RussiaCentralBank.TabIndex = 11;
            this.RussiaCentralBank.TabStop = true;
            this.RussiaCentralBank.Text = "Russia Central Bank";
            this.RussiaCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RussiaCentralBank_LinkClicked);
            // 
            // SloveniaCentralBank
            // 
            this.SloveniaCentralBank.AutoSize = true;
            this.SloveniaCentralBank.Location = new System.Drawing.Point(434, 251);
            this.SloveniaCentralBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SloveniaCentralBank.Name = "SloveniaCentralBank";
            this.SloveniaCentralBank.Size = new System.Drawing.Size(524, 20);
            this.SloveniaCentralBank.TabIndex = 12;
            this.SloveniaCentralBank.TabStop = true;
            this.SloveniaCentralBank.Text = "Slovenia Central Bank (Currencies not published as ECB reference rates)";
            this.SloveniaCentralBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SloveniaCentralBank_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(987, 120);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // webservicex
            // 
            this.webservicex.AutoSize = true;
            this.webservicex.Location = new System.Drawing.Point(1007, 251);
            this.webservicex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.webservicex.Name = "webservicex";
            this.webservicex.Size = new System.Drawing.Size(198, 20);
            this.webservicex.TabIndex = 15;
            this.webservicex.TabStop = true;
            this.webservicex.Text = "http://www.webservicex.net";
            this.webservicex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webservicex_LinkClicked);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(28, 29);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CRMGG.ExchangeRates.Properties.Resources.get_currencies;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(196, 29);
            this.toolStripButton1.Text = "Get CRM Currencies";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::CRMGG.ExchangeRates.Properties.Resources.get_exc_rates;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(317, 29);
            this.toolStripButton2.Text = "Get Exchange Rates from Providers";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::CRMGG.ExchangeRates.Properties.Resources.conversion_of_currency;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(287, 29);
            this.toolStripButton3.Text = "Update Exchange Rates in CRM";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::CRMGG.ExchangeRates.Properties.Resources.save_as;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(154, 29);
            this.toolStripButton4.Text = "Save Mapping";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // ExchRateCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webservicex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SloveniaCentralBank);
            this.Controls.Add(this.RussiaCentralBank);
            this.Controls.Add(this.EuropeanCentralBank);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDefaultCurrency);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ExchRateCalc";
            this.Size = new System.Drawing.Size(1323, 848);
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
