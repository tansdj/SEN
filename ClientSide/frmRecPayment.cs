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
    public partial class frmRecPayment : Form,IAccessibility
    {
        BindingSource clientBind = new BindingSource();
        List<Billing> clientBilling;

        public frmRecPayment()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();


            List<Client> clients = new Client().GetAllClients();
            foreach (Client item in clients)
            {
                if (item.Status == "Inactive")
                {
                    clients.Remove(item);
                }
            }
            clientBind.DataSource = clients;
            cmbClients.DataSource = clientBind;
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
        private void btnRecPayment_Click(object sender, EventArgs e)
        {
            if (ValidateBilling())
            {
                clientBilling = new Billing((Client)clientBind.Current, DateTime.UtcNow, 0, 0).GetClientBilling();
                double paid = (from pBill in clientBilling select pBill.AmountPaid).Sum();
                double due = (from pBill in clientBilling select pBill.AmountDue).Sum();
                double currentDue = due - paid;
                try
                {
                    double amount = Convert.ToDouble(txtAmount.Text);
                    Billing b = new Billing((Client)clientBind.Current, dtpPayDate.Value, currentDue, Convert.ToDouble(txtAmount.Text));
                    if (b.InsertBilling())
                    {
                        MessageBoxShower.ShowInfo("Payment Recorded!", "Success!");
                        this.Close();
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The payment could not be recorded. Please try again later.", "Failure!");
                    }
                }
                catch (Exception)
                {
                    CustomExceptions error = new CustomExceptions("The payment could not be recorded. Please try again later.", "Failure!");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Failure!");
            } 
        }

        private bool ValidateBilling()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbClients)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "DOUBLE", ref txtAmount)) valid = false;
            return valid;
        }
    }
}
