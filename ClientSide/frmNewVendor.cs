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
    public partial class frmNewVendor : Form,IAccessibility
    {
 
        public frmNewVendor()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
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

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            if (ValidateVendor())
            {
                Vendor vend = new Vendor("", txtName.Text,new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text));
                if (NoDuplicates(vend))
                {
                    if (vend.InsertVendor())
                    {
                        MessageBoxShower.ShowInfo("The Vendor was added successfully!", "Success");
                        this.Close();
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The vendor could not be added. Please try again later.", "Something went wrong..");
                    }
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("A Vendor with this name has already been added. Please update.", "The vendor could not be added.");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Validation Error!");
            }
        }

        #region Validation
        private bool ValidateVendor()
        {
            bool valid = true;
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

        private bool NoDuplicates(Vendor v)
        {
            List<Vendor> vends = v.GetAllVendors();
            foreach (Vendor item in vends)
            {
                if (item.Name==v.Name)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
