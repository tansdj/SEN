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
    public partial class frmNewClient : Form
    {
        public frmNewClient()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

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
                client.NewClientWithPaymentDet(txtAccNr.Text, txtBank.Text, txtBranch.Text);
            }
            else
            {
                client.NewClient();
            }
            this.Close();
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
    }
}
