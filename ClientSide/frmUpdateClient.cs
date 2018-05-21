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

namespace ClientSide
{
    public partial class frmUpdateClient : Form
    {
       
        List<PaymentDetails> details = new PaymentDetails().GetAllPaymentDetails();
        BindingSource bind1 = new BindingSource();
        public frmUpdateClient()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
           
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

        private void btnClientManagement_Click(object sender, EventArgs e)
        {

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

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Client client = (Client)bind1.Current;
            if (cmbPayment.SelectedItem.ToString() == "Debit Order")
            {
                client.UpdateClientWithPaymentDetails(txtAccNr.Text, txtBank.Text, txtBranch.Text);
            }
            else
            {
                client.UpdateClient();
            }
            this.Close();
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
            Client current = (Client)cmbClients.SelectedItem;
            var results = from pd in details where pd.PaymentDet_Client.ClientIdentifier == current.ClientIdentifier select new { PAccNr = pd.AccNr, PBank = pd.Bank, PBranch = pd.BranchCode };
            if (results!=null)
            {
                foreach (var item in results)
                {
                    txtAccNr.Text = item.PAccNr;
                    txtBank.Text = item.PBank;
                    txtBranch.Text = item.PBranch;
                }
            }
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CallSimulator cs = new CallSimulator();
            cs.Show();
        }
    }
}
