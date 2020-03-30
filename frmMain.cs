using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrappeMocha.Keygen;
using FrappeMocha.Keygen.Platforms;

namespace FrappeMocha
{
    public partial class FrmMain : Form
    {
        private char[] ficus = new char[6];
        private Dictionary<string, KeygenBase> keygens = new Dictionary<string, KeygenBase>();
        private string[] platforms = {"Windows", "MacOSX", "Java", "Google Chrome", "Android"};
        private string[] companyUserName = {"Company Name", "User Name"};

        public FrmMain()
        {
            InitializeComponent();
            keygens.Add(platforms[0], new PlatformWindows());
            keygens.Add(platforms[1], new PlatformMac());
            keygens.Add(platforms[2], new PlatformJava());
            keygens.Add(platforms[3], new PlatformJavaScript());
            keygens.Add(platforms[4], new PlatformAndroid());

            foreach (var item in keygens)
            {
                cbxPlatform.Items.Add(item.Value);
            }

            cbxPlatform.SelectedIndex = 0;
        }

        private string keygen(KeygenBase platform, KeygenProduct product, int type, string name)
        {
            if (name.Length <= 1)
            {
                MessageBox.Show( companyUserName[type] + " must be longer than one character", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            if (name.Length > 80)
            {
                MessageBox.Show( companyUserName[type] + " must not be greater than eighty characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            string genlicense = platform.Generate(type, name, product.Licence);
            if (!platform.Check(genlicense, name, product.Licence))
            {
                MessageBox.Show("Generated license did not pass self check, please try again", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return genlicense;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            AcceptButton.PerformClick();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            Array.Copy(ficus, 1, ficus, 0, ficus.Length - 1);
            this.ficus[ficus.Length - 1] = e.KeyChar;
            if (new string(ficus) == "spicey")
            {
                switch (MessageBox.Show("Would you like a little salt, as a treat?", "Orly?",
                    MessageBoxButtons.YesNoCancel,
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            KeygenBase platform = (KeygenBase)cbxPlatform.SelectedItem;
            KeygenProduct product = (KeygenProduct)cbxProduct.SelectedItem;
            int type = cbxLicenseType.SelectedIndex;
            string name = tbxCompanyUserName.Text;

            tbxLicenseKey.Text = keygen(platform, product, type, name);
        }

        private void tbxLicenseKey_Click(object sender, EventArgs e)
        {
            tbxLicenseKey.SelectAll();
        }

        private void cbxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeygenBase platform = (KeygenBase) cbxPlatform.SelectedItem;

            cbxProduct.Enabled = false;
            cbxProduct.Items.Clear();
            foreach (var p in platform.Products)
            {
                cbxProduct.Items.Add(p);
            }
            cbxProduct.SelectedIndex = 0;
            cbxProduct.Enabled = true;
        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeygenBase platform = (KeygenBase)cbxPlatform.SelectedItem;
            KeygenProduct product = (KeygenProduct) cbxProduct.SelectedItem;

            cbxLicenseType.Enabled = false;
            cbxLicenseType.Items.Clear();
            var LicenceTypes = platform.GenerateLicencetypes(product);
            foreach (string type in LicenceTypes)
            {
                cbxLicenseType.Items.Add(type);
            }
            cbxLicenseType.Enabled = true;
            cbxLicenseType.SelectedIndex = 0;
            AcceptButton.PerformClick();
        }

        private void cbxLicenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLicenseType.Items.Count != 2)
            {
                lblCompanyUserName.Text = "Name";
            }
            else
            {
                lblCompanyUserName.Text = companyUserName[cbxLicenseType.SelectedIndex];
            }
            AcceptButton.PerformClick();
        }

    }
}