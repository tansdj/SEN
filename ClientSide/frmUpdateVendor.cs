using SHSApplication.Business_Layer;
using SHSApplication.Helper_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class frmUpdateVendor : Form,IAccessibility
    {
        BindingSource vendBind = new BindingSource();
        public frmUpdateVendor()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            vendBind.DataSource = new Vendor().GetAllVendors();
            cmbVends.DataSource = vendBind;
            txtName.DataBindings.Add("Text", vendBind, "Name");
            txtLine1.DataBindings.Add("Text", vendBind, "VendorAddress.AddressLine1");
            txtLine2.DataBindings.Add("Text", vendBind, "VendorAddress.AddressLine2");
            txtCity.DataBindings.Add("Text", vendBind, "VendorAddress.City");
            txtPostalCode.DataBindings.Add("Text", vendBind, "VendorAddress.PostalCode");
            txtCell.DataBindings.Add("Text", vendBind, "VendorContact.Cell");
            txtEmail.DataBindings.Add("Text", vendBind, "VendorContact.Email");
        }
        #region menuItems

        private void btnClientManagement_Click(object sender, EventArgs e)
        {
            frmClientManagement cm = new frmClientManagement();
            cm.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProdManagement_Click(object sender, EventArgs e)
        {
            frmProductManagement pm = new frmProductManagement();
            pm.Show();
            this.Close();
        }

        private void btnTecManagement_Click(object sender, EventArgs e)
        {
            frmEmpManagement tm = new frmEmpManagement();
            tm.Show();
            this.Close();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmUserManagement um = new frmUserManagement();
            um.Show();
            this.Close();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CallSimulator cs = new CallSimulator();
            cs.Show();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region UserAccessManagement
        public void VerifyAccessibility()
        {
            if (frmMain.loggedIn != null)
            {
                btnLoginLogout.Text = "Logout";
                if (frmMain.loggedIn.Access == "Admin")
                {
                    btnTecManagement.Enabled = true;
                    btnTecManagement.Visible = true;
                    btnUserManagement.Enabled = true;
                    btnUserManagement.Visible = true;
                }
                else
                {
                    btnTecManagement.Enabled = false;
                    btnTecManagement.Visible = false;
                    btnUserManagement.Enabled = false;
                    btnUserManagement.Visible = false;
                }
            }
        }

        private void btnLoginLogout_Click(object sender, EventArgs e)
        {
            if (frmMain.loggedIn != null)
            {
                frmMain.lh.LogOut();
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
                this.Close();
            }
        }
        #endregion

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            if (ValidateVendor())
            {
                Vendor vend = (Vendor)vendBind.Current;
                if (vend.UpdateVendor())
                {
                    MessageBoxShower.ShowInfo("Vendor updated!", "Success!");
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The vendor could not be updated. Please try again later.", "Something went wrong");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Validation Error");
            }
        }
        private bool ValidateVendor()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbVends)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtName)) valid = false;
            if (!Validation.ValidateTextbox(1, 30, "STRING", ref txtLine1)) valid = false;
            if (!Validation.ValidateTextbox(1, 30, "STRING", ref txtLine2)) valid = false;
            if (!Validation.ValidateTextbox(1, 20, "STRING", ref txtCity)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "INT", ref txtPostalCode)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtEmail))
            {
                valid = false;
            }
            else
            {
                if (txtEmail.Text.IndexOf('@') == -1 || txtEmail.Text.IndexOf('.') == -1)
                {
                    valid = false;
                    CustomExceptions error = new CustomExceptions("Invalid Email", "Email error!");
                }
            }
            if (!Validation.ValidateTextbox(10, 10, "INT", ref txtCell)) valid = false;

            return valid;
        }
    }
}
