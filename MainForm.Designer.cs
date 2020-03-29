namespace FrappeMocha
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TypeDropDown = new System.Windows.Forms.ComboBox();
            this.companytext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.companyusernamelabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.licensebox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.productSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TypeDropDown
            // 
            this.TypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeDropDown.FormattingEnabled = true;
            this.TypeDropDown.Items.AddRange(new object[] {
            "Company License",
            "Single User License"});
            this.TypeDropDown.Location = new System.Drawing.Point(12, 65);
            this.TypeDropDown.Name = "TypeDropDown";
            this.TypeDropDown.Size = new System.Drawing.Size(146, 21);
            this.TypeDropDown.TabIndex = 0;
            this.TypeDropDown.SelectedIndexChanged += new System.EventHandler(this.TypeDropDown_SelectedIndexChanged);
            // 
            // companytext
            // 
            this.companytext.Location = new System.Drawing.Point(12, 105);
            this.companytext.MaxLength = 80;
            this.companytext.Name = "companytext";
            this.companytext.Size = new System.Drawing.Size(146, 20);
            this.companytext.TabIndex = 1;
            this.companytext.Text = "FrappeMocha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "License Type";
            // 
            // companyusernamelabel
            // 
            this.companyusernamelabel.AutoSize = true;
            this.companyusernamelabel.Location = new System.Drawing.Point(9, 89);
            this.companyusernamelabel.Name = "companyusernamelabel";
            this.companyusernamelabel.Size = new System.Drawing.Size(115, 13);
            this.companyusernamelabel.TabIndex = 3;
            this.companyusernamelabel.Text = "Company / User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "License Key";
            // 
            // licensebox
            // 
            this.licensebox.Location = new System.Drawing.Point(12, 144);
            this.licensebox.Name = "licensebox";
            this.licensebox.ReadOnly = true;
            this.licensebox.Size = new System.Drawing.Size(146, 20);
            this.licensebox.TabIndex = 5;
            this.licensebox.Click += new System.EventHandler(this.licensebox_Click);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(12, 175);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(146, 23);
            this.submit.TabIndex = 6;
            this.submit.Text = "Frappe Mocha";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Product";
            // 
            // productSelect
            // 
            this.productSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productSelect.FormattingEnabled = true;
            this.productSelect.Items.AddRange(new object[] {
            "TN3270 for Windows",
            "TN5250 for Windows",
            "TN3812 for Windows",
            "Telnet for Windows",
            "TN3270 for Java",
            "TN5250 for Java",
            "Telnet for Java",
            "TN3270 for Mac OS X",
            "TN5250 for Mac OS X",
            "TN3812 for Mac OS X",
            "Telnet for Mac OS X",
            "Keyboard for Mac OS X",
            "TN3270 for Google Chrome",
            "TN5250 for Google Chrome",
            "Telnet for Google Chrome",
            "TN3270 for Android",
            "TN5250 for Android",
            "Telnet for Android",
            "VNC for Android",
            "Barcode for Android"});
            this.productSelect.Location = new System.Drawing.Point(12, 25);
            this.productSelect.Name = "productSelect";
            this.productSelect.Size = new System.Drawing.Size(146, 21);
            this.productSelect.TabIndex = 8;
            this.productSelect.SelectedIndexChanged += new System.EventHandler(this.productSelect_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(173, 210);
            this.Controls.Add(this.productSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.licensebox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.companyusernamelabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.companytext);
            this.Controls.Add(this.TypeDropDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "FrappeMocha";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TypeDropDown;
        private System.Windows.Forms.TextBox companytext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label companyusernamelabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox licensebox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox productSelect;
    }
}

