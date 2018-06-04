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
    public partial class frmUpdateClient : Form,IAccessibility
    {
       
        List<PaymentDetails> details = new PaymentDetails().GetAllPaymentDetails();
        BindingSource bind1 = new BindingSource();
        public frmUpdateClient()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();
           
            bind1.DataSource = new Client().GetAllClients();
            cmbClients.DataSource = bind1;
            txtId.DataBindings.Add("Text", bind1, "PersonId");
            txtName.DataBindings.Add("Text", bind1, "Name");
            txtSurname.DataBindings.Add("Text", bind1, "Surname");
            cmbPayment.DataBindings.Add("SelectedItem", bind1, "PaymentMethod");
            txtLine1.DataBindings.Add("Text", bind1, "PersonAddress.AddressLine1");
            txtLine2.DataBindings.Add("Text", bind1, "PersonAddress.AddressLine2");
            txtCity.DataBindings.Add("Text", bind1, "PersonAddress.City");
            txtPostalCode.DataBindings.Add("Text", bind1, "PersonAddress.PostalCode");
            txtCell.DataBindings.Add("Text", bind1, "PersonContact.Cell");
            txtEmail.DataBindings.Add("Text", bind1, "PersonContact.Email");

        }
        #region menuItems
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnClientManagement_Click(object sender, EventArgs e)
        {

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
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Client client = (Client)bind1.Current;
                if (cmbPayment.SelectedItem.ToString() == "Debit Order")
                {
                    if (client.UpdateClientWithPaymentDetails(txtAccNr.Text, txtBank.Text, txtBranch.Text))
                    {
                        MessageBoxShower.ShowInfo("The Client was updated successfully!", "Success!");
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The client could not be updated, Please try again later.", "Something went wrong..");
                    }
                }
                else
                {
                    if (client.UpdateClient())
                    {
                        MessageBoxShower.ShowInfo("The Client was updated successfully!", "Success!");
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The client could not be updated, Please try again later.", "Something went wrong..");
                    }
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Failure!");
            }
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedItem.ToString() == "Debit Order")
            {
                gbDebitOrder.Visible = true;
            }
            else
            {
                gbDebitOrder.Visible = false;
            }
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Validation.ValidateCombo(ref cmbClients))
            {
                Client current = (Client)cmbClients.SelectedItem;
                var results = from pd in details where pd.PaymentDet_Client.ClientIdentifier == current.ClientIdentifier select new { PAccNr = pd.AccNr, PBank = pd.Bank, PBranch = pd.BranchCode };
                if (results != null)
                {
                    foreach (var item in results)
                    {
                        txtAccNr.Text = item.PAccNr;
                        txtBank.Text = item.PBank;
                        txtBranch.Text = item.PBranch;
                    }
                }
            }
        }

        
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
        private bool ValidateForm()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbClients)) valid = false;
            if (!Validation.ValidateTextbox(13, 13, "LONG", ref txtId)) valid = false;
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
                    txtEmail.BackColor = System.Drawing.Color.Tomato;
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
    }
}
