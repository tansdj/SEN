using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHSApplication.Business_Layer;
using SHSApplication.Helper_Libraries;

namespace ClientSide
{
    public partial class frmNewClient : Form,IAccessibility
    {
        public frmNewClient()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CallSimulator cs = new CallSimulator();
            cs.Show();
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
                this.Close();
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
                this.Close();
            }
        }
        #endregion
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Client client = new Client(txtId.Text, txtName.Text, txtSurname.Text, new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbPayment.SelectedItem.ToString(), "Active");
                if (NoDuplicates(client))
                {
                    if (cmbPayment.SelectedItem.ToString() == "Debit Order")
                    {
                        if (client.NewClientWithPaymentDet(txtAccNr.Text, txtBank.Text, txtBranch.Text))
                        {
                            MessageBoxShower.ShowInfo("The client was added succesfully!", "Success!");
                            this.Close();
                        }
                        else
                        {
                            CustomExceptions error = new CustomExceptions("The client could not be added. Please try again.", "Failure!");
                        }
                    }
                    else
                    {
                        if (client.NewClient())
                        {
                            MessageBoxShower.ShowInfo("The client was added succesfully!", "Success!");
                            this.Close();
                        }
                        else
                        {
                            CustomExceptions error = new CustomExceptions("The client could not be added. Please try again.", "Failure!");
                        }
                    }
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The client already exists.", "Cannot add client");
                } 
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please fill in all fields correctly.", "Faulure!");
            }  
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPayment.SelectedItem.ToString()=="Debit Order")
            {
                gbDebitOrder.Visible = true;
            }
            else
            {
                gbDebitOrder.Visible = false;
            }
        }

        #region Validation
        private bool ValidateForm()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(13, 13, "LONGINT", ref txtId)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtName)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtSurname)) valid = false;
            if (!Validation.ValidateCombo(ref cmbPayment)) valid = false;
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
            if (cmbPayment.SelectedIndex != -1)
            {
                if (cmbPayment.SelectedItem.ToString() == "Debit Order")
                {
                    if (!Validation.ValidateTextbox(5, 20, "LONGINT", ref txtAccNr)) valid = false;
                    if (!Validation.ValidateTextbox(1, 15, "STRING", ref txtBank)) valid = false;
                    if (!Validation.ValidateTextbox(1, 10, "STRING", ref txtBranch)) valid = false;
                }
            }
            
            return valid;
        }

        private bool NoDuplicates(Client c)
        {
            List<Client> clients = new Client().GetAllClients();
            foreach (Client item in clients)
            {
                if (item.PersonId==c.PersonId)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
