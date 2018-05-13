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
        List<Client> clients = new Client().GetAllClients();
        List<PaymentDetails> details = new PaymentDetails().GetAllPaymentDetails();
        public frmUpdateClient()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            cmbClients.DataSource = clients;
            txtId.DataBindings.Add("Text", clients, "PersonId");
            txtName.DataBindings.Add("Text", clients, "Name");
            txtSurname.DataBindings.Add("Text", clients, "Surname");
            cmbPayment.DataBindings.Add("SelectedItem", clients, "PaymentMethod");
            txtLine1.DataBindings.Add("Text", clients, "PersonAddress.AddressLine1");
            txtLine2.DataBindings.Add("Text", clients, "PersonAddress.AddressLine2");
            txtCity.DataBindings.Add("Text", clients, "PersonAddress.City");
            txtPostalCode.DataBindings.Add("Text", clients, "PersonAddress.PostalCode");
            txtCell.DataBindings.Add("Text", clients, "PersonContact.Cell");
            txtEmail.DataBindings.Add("Text", clients, "PersonContact.Email");

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
            frmTechManagement tm = new frmTechManagement();
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
            Client client = new Client(txtId.Text, txtName.Text, txtSurname.Text, new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbPayment.SelectedItem.ToString(), "Active");
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
            var results = from pd in details where pd.PaymentDet_Client.PersonId == current.PersonId select new { PAccNr = pd.AccNr, PBank = pd.Bank, PBranch = pd.BranchCode };
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
    }
}
