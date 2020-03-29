using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrappeMocha
{
    public partial class MainForm : Form
    {
        protected Keygen frappeKeygen;
        private char[] ficus = new char[6];
        private object[] windowsLicenseTypeItems = new object[2];
        private object[] macLicenseTypeItems = new object[1];
        private object[] javaLicenseTypeItems = new object[5];

        public MainForm()
        {
            InitializeComponent();
            TypeDropDown.SelectedIndex = 0;
            productSelect.SelectedIndex = 0;
            frappeKeygen = new Keygen();
            this.initDropDownMenuItems();
        }

        private void initDropDownMenuItems()
        {
            TypeDropDown.Items.CopyTo(windowsLicenseTypeItems, 0);

            initJavaLicenseTypeItems();
            initMacLicenseTypeItems();

            TypeDropDown.Items.Clear();
            TypeDropDown.Items.AddRange(this.windowsLicenseTypeItems);
            TypeDropDown.SelectedIndex = 0;
        }

        private void initJavaLicenseTypeItems()
        {
            TypeDropDown.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                TypeDropDown.Items.Add((char) ('A' + i));
            }
            TypeDropDown.Items.CopyTo(this.javaLicenseTypeItems, 0);
        }

        private void initMacLicenseTypeItems()
        {
            TypeDropDown.Items.Clear();
            for (int i = 0; i < 1; i++)
            {
                TypeDropDown.Items.Add((char) ('0' + i));
            }
            TypeDropDown.Items.CopyTo(this.macLicenseTypeItems, 0);
        }

        private void submit_Click(object sender, EventArgs e)
        {
            switch (productSelect.SelectedIndex)
            {
                case 0:
                    this.keygen(Keygen.LicenseTypes.LicenseWindows3270);
                    break;

                case 1:
                    this.keygen(Keygen.LicenseTypes.LicenseWindows5250);
                    break;

                case 2:
                    this.keygen(Keygen.LicenseTypes.LicenseWindows3812);
                    break;

                case 3:
                    this.keygen(Keygen.LicenseTypes.LicenseWindowsTelnet);
                    break;

                case 4:
                    this.keygen(Keygen.LicenseTypes.LicenseJava3270);
                    break;

                case 5:
                    this.keygen(Keygen.LicenseTypes.LicenseJava5250);
                    break;

                case 6:
                    this.keygen(Keygen.LicenseTypes.LicenseJavaTelnet);
                    break;

                case 7:
                    this.keygen(Keygen.LicenseTypes.LicenseMac3270);
                    break;

                case 8:
                    this.keygen(Keygen.LicenseTypes.LicenseMac5250);
                    break;

                case 9:
                    this.keygen(Keygen.LicenseTypes.LicenseMac3812);
                    break;

                case 10:
                    this.keygen(Keygen.LicenseTypes.LicenseMacTelnet);
                    break;

                case 11:
                    this.keygen(Keygen.LicenseTypes.LicenseMacKeyboard);
                    break;

                case 12:
                    this.keygen(Keygen.LicenseTypes.LicenseChrome3270);
                    break;

                case 13:
                    this.keygen(Keygen.LicenseTypes.LicenseChrome5250);
                    break;

                case 14:
                    this.keygen(Keygen.LicenseTypes.LicenseChromeTelnet);
                    break;

                case 15:
                    this.keygen(Keygen.LicenseTypes.LicenseAndroid3270);
                    break;

                case 16:
                    this.keygen(Keygen.LicenseTypes.LicenseAndroid5250);
                    break;

                case 17:
                    this.keygen(Keygen.LicenseTypes.LicenseAndroidTelnet);
                    break;

                case 18:
                    this.keygen(Keygen.LicenseTypes.LicenseAndroidVnc);
                    break;

                case 19:
                    this.keygen(Keygen.LicenseTypes.LicenseAndroidBarcode);
                    break;

            }
        }

        private void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TypeDropDown.SelectedIndex)
            {
                case 0:
                    companyusernamelabel.Text = "Company Name";
                    break;

                case 1:
                    companyusernamelabel.Text = "User Name";
                    break;
            }

            if (TypeDropDown.Items.Count > 2)
            {
                companyusernamelabel.Text = "Name";
            }

            AcceptButton.PerformClick();
        }

        private void keygen(Keygen.LicenseTypes license)
        {
            if (companytext.Text.Length <= 1)
            {
                MessageBox.Show(
                    (TypeDropDown.SelectedIndex == 0
                        ? "Company Name"
                        : "User Name") + " must be longer than one character", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (companytext.Text.Length > 80)
            {
                MessageBox.Show(
                    (TypeDropDown.SelectedIndex == 0
                        ? "Company Name"
                        : "User Name") + " must not be greater than eighty characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string genlicense = frappeKeygen.GenLicense(TypeDropDown.SelectedIndex, companytext.Text, license);
            if (!frappeKeygen.CheckLicense(genlicense, companytext.Text, license))
            {
                MessageBox.Show("Generated license did not pass self check, please try again", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            licensebox.Text = genlicense;
        }

        private void productSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (productSelect.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 7: // mac type 1
                case 8: // mac type 1
                case 12:
                    if (windowsLicenseTypeItems[0] != null)
                    {
                        TypeDropDown.Items.Clear();
                        TypeDropDown.Items.AddRange(this.windowsLicenseTypeItems);
                    }
                    break;
                case 4:
                case 5:
                case 6:
                    TypeDropDown.Items.Clear();
                    TypeDropDown.Items.AddRange(this.javaLicenseTypeItems);
                    break;

                case 9: // mac type 2
                case 10:
                case 11:
                    TypeDropDown.Items.Clear();
                    TypeDropDown.Items.AddRange(this.macLicenseTypeItems);
                    break;
            }
            TypeDropDown.SelectedIndex = 0;
            AcceptButton.PerformClick();
        }

        private void licensebox_Click(object sender, EventArgs e)
        {
            licensebox.SelectAll();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            AcceptButton.PerformClick();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Array.Copy(this.ficus, 1, this.ficus, 0, this.ficus.Length -1);
            this.ficus[ficus.Length -1] = e.KeyChar;
            if (new string (ficus) == "spicey")
            {
                switch (MessageBox.Show("Would you like a little salt, as a treat?", "Orly?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        Process.Start("https://i.imgur.com/EJ31bmk.jpg");
                        break;
                    case DialogResult.No:
                        Process.Start(
                            "https://pics.me.me/white-people-cant-handle-spicy-food-um-try-again-sweetie-6626438.png");
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }
    }
}