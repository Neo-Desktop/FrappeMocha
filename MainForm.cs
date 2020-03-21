using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrappeMocha
{
    public partial class MainForm : Form
    {
        protected Keygen frappeKeygen;
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
                    this.keygen(Keygen.LicenseTypes.License3270);
                    break;

                case 1:
                    this.keygen(Keygen.LicenseTypes.License5250);
                    break;

                case 2:
                    this.keygen(Keygen.LicenseTypes.License3812);
                    break;

                case 3:
                    this.keygen(Keygen.LicenseTypes.LicenseTelnet);
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
        }

        private void licensebox_Click(object sender, EventArgs e)
        {
            licensebox.SelectAll();
        }
    }
}
