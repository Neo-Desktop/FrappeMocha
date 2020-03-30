namespace FrappeMocha
{
    partial class FrmMain
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

        #region PlatformWindows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cbxLicenseType = new System.Windows.Forms.ComboBox();
            this.tbxCompanyUserName = new System.Windows.Forms.TextBox();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.lblCompanyUserName = new System.Windows.Forms.Label();
            this.lblLicenseKey = new System.Windows.Forms.Label();
            this.tbxLicenseKey = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.cbxPlatform = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxLicenseType
            // 
            this.cbxLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLicenseType.FormattingEnabled = true;
            this.cbxLicenseType.Items.AddRange(new object[] {
            "Company License",
            "Single User License"});
            this.cbxLicenseType.Location = new System.Drawing.Point(12, 112);
            this.cbxLicenseType.Name = "cbxLicenseType";
            this.cbxLicenseType.Size = new System.Drawing.Size(146, 21);
            this.cbxLicenseType.TabIndex = 0;
            this.cbxLicenseType.SelectedIndexChanged += new System.EventHandler(this.cbxLicenseType_SelectedIndexChanged);
            // 
            // tbxCompanyUserName
            // 
            this.tbxCompanyUserName.Location = new System.Drawing.Point(12, 152);
            this.tbxCompanyUserName.MaxLength = 80;
            this.tbxCompanyUserName.Name = "tbxCompanyUserName";
            this.tbxCompanyUserName.Size = new System.Drawing.Size(146, 20);
            this.tbxCompanyUserName.TabIndex = 1;
            this.tbxCompanyUserName.Text = "FrappeMocha";
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.AutoSize = true;
            this.lblLicenseType.Location = new System.Drawing.Point(9, 96);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(71, 13);
            this.lblLicenseType.TabIndex = 2;
            this.lblLicenseType.Text = "License Type";
            // 
            // lblCompanyUserName
            // 
            this.lblCompanyUserName.AutoSize = true;
            this.lblCompanyUserName.Location = new System.Drawing.Point(9, 136);
            this.lblCompanyUserName.Name = "lblCompanyUserName";
            this.lblCompanyUserName.Size = new System.Drawing.Size(115, 13);
            this.lblCompanyUserName.TabIndex = 3;
            this.lblCompanyUserName.Text = "Company / User Name";
            // 
            // lblLicenseKey
            // 
            this.lblLicenseKey.AutoSize = true;
            this.lblLicenseKey.Location = new System.Drawing.Point(9, 175);
            this.lblLicenseKey.Name = "lblLicenseKey";
            this.lblLicenseKey.Size = new System.Drawing.Size(65, 13);
            this.lblLicenseKey.TabIndex = 4;
            this.lblLicenseKey.Text = "License Key";
            // 
            // tbxLicenseKey
            // 
            this.tbxLicenseKey.Location = new System.Drawing.Point(12, 191);
            this.tbxLicenseKey.Name = "tbxLicenseKey";
            this.tbxLicenseKey.ReadOnly = true;
            this.tbxLicenseKey.Size = new System.Drawing.Size(146, 20);
            this.tbxLicenseKey.TabIndex = 5;
            this.tbxLicenseKey.Click += new System.EventHandler(this.tbxLicenseKey_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 222);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(146, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Frappe Mocha";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(9, 56);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 7;
            this.lblProduct.Text = "Product";
            // 
            // cbxProduct
            // 
            this.cbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.Location = new System.Drawing.Point(12, 72);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(146, 21);
            this.cbxProduct.TabIndex = 8;
            this.cbxProduct.SelectedIndexChanged += new System.EventHandler(this.cbxProduct_SelectedIndexChanged);
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(9, 13);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(45, 13);
            this.lblPlatform.TabIndex = 9;
            this.lblPlatform.Text = "Platform";
            // 
            // cbxPlatform
            // 
            this.cbxPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlatform.FormattingEnabled = true;
            this.cbxPlatform.Location = new System.Drawing.Point(12, 29);
            this.cbxPlatform.Name = "cbxPlatform";
            this.cbxPlatform.Size = new System.Drawing.Size(146, 21);
            this.cbxPlatform.TabIndex = 10;
            this.cbxPlatform.SelectedIndexChanged += new System.EventHandler(this.cbxPlatform_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(173, 258);
            this.Controls.Add(this.cbxPlatform);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.cbxProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbxLicenseKey);
            this.Controls.Add(this.lblLicenseKey);
            this.Controls.Add(this.lblCompanyUserName);
            this.Controls.Add(this.lblLicenseType);
            this.Controls.Add(this.tbxCompanyUserName);
            this.Controls.Add(this.cbxLicenseType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrappeMocha";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxLicenseType;
        private System.Windows.Forms.TextBox tbxCompanyUserName;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.Label lblCompanyUserName;
        private System.Windows.Forms.Label lblLicenseKey;
        private System.Windows.Forms.TextBox tbxLicenseKey;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.ComboBox cbxPlatform;
    }
}

