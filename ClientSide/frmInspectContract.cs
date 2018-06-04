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
    public partial class frmInspectContract : Form,IAccessibility
    {
        BindingSource clientBind = new BindingSource();
        public frmInspectContract()
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
        private void btnPrintContract_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientBind.Current;
            List<Contract> contracts = new Contract().GetAllContracts(client.ClientIdentifier);
            foreach (Contract item in contracts)
            {
                List<Product> products = new List<Product>();
                List<SystemComponents> comps = new List<SystemComponents>();
                List<Configurations> confs = new List<Configurations>();

                List<ContractProducts> cp = new ContractProducts(item,new Product()).GetContractProducts();
                foreach (ContractProducts cproduct in cp)
                {
                    products.Add(cproduct.ContractProducts_Product);
                }

                foreach (Product p in products)
                {
                    List<SystemComponents> comp = new SystemComponents(p).GetSystemComponents();
                    foreach (SystemComponents c in comp)
                    {
                        comps.Add(c);
                    }
                }

               
                List<ContractConfigurations> cc = new ContractConfigurations(item).GetContractConfigurations();
                foreach (ContractConfigurations configuration in cc)
                {
                   confs.Add(configuration.ContractConfigurations_Configuration);
                }
               

                PdfWriter.CreateClientContractPdf(client,item, products, comps, confs);
            }
        }
    }
}
