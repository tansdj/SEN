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
    public partial class frmNewContract : Form,IAccessibility
    {
        BindingSource clientBind = new BindingSource();
        BindingSource productBind = new BindingSource();
        BindingSource configBind = new BindingSource();
        BindingSource compBind = new BindingSource();

        Client client;
        Contract contract;
        Product product;
        SystemComponents comp;
        Configurations config;

        int term;
        List<ContractProducts> products = new List<ContractProducts>();
        List<ContractConfigurations> configs = new List<ContractConfigurations>();
        public frmNewContract()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();

            gpProductInformation.Hide();
            gbCompInfo.Hide();

            clientBind.DataSource = new Client().GetAllClients();
            cmbClients.DataSource = clientBind;

            productBind.DataSource = new Product().GetAllProducts();
            cmbProducts.DataSource = productBind;
            txtProductName.DataBindings.Add("Text", productBind, "Name");
            redProdDesc.DataBindings.Add("Text", productBind, "Description");
            txtProductPrice.DataBindings.Add("Text", productBind, "BasePrice");
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
        #endregion
        #region panelNavigation
        

        

        

        private void btnCancelComp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            client = (Client)clientBind.Current;
            contract = new Contract("", client, new ServiceLevel(cmbServiceLevel.SelectedItem.ToString()), dtpIssueDate.Value, term);
            gbContractInfo.Hide();
            gpProductInformation.Show();
        }

        private void cmbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTerm.SelectedItem.ToString()=="Custom")
            {
                numDuration.Enabled = true;
                numDuration.Visible = true;
            }
            else
            {
                numDuration.Enabled = false;
                numDuration.Visible = false;

                switch (cmbTerm.SelectedItem.ToString())
                {
                    case "Once - Off": term = 0; break;
                    case "6 Months": term = 6; break;
                    case "1 Year": term = 12; break;
                    case "2 Years": term = 24; break;
                    case "5 Years": term = 60; break;
                    default:
                        break;
                }
            }  
        }

        private void numDuration_ValueChanged(object sender, EventArgs e)
        {
            term = Convert.ToInt32(numDuration.Value);
        }

        private void btnNextComp_Click(object sender, EventArgs e)
        {
            products.Add(new ContractProducts(contract,product));
            compBind.DataSource = new SystemComponents("", product, "", "", "", "").GetSystemComponents();
            lbComponents.DataSource = compBind;
            gpProductInformation.Hide();
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            product = (Product)productBind.Current;
        }

        private void lbComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            configBind.DataSource = new Configurations("", "", "", comp, 0, "").GetAllConfigurations();
            txtConfName.DataBindings.Add("Text", configBind, "Name");
            redConfDesc.DataBindings.Add("Text", configBind, "Description");
            txtConfAddCost.DataBindings.Add("Text", configBind, "AddCost");
            txtCompSerial.Focus();
        }

        private void cmbConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool found = false;
            config = (Configurations)configBind.Current;
            if (txtCompSerial.Text.Length > 0)
            {
                foreach (ContractConfigurations item in configs)
                {
                    if (item.ContractConfigurations_Configuration.Configuration_Component == config.Configuration_Component)
                    {
                        item.ContractConfigurations_Configuration = config;
                        found = true;
                    }
                }
                if (found == false)
                {
                    configs.Add(new ContractConfigurations(contract, config, txtCompSerial.Text));
                }    
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Component Serial Code Not filled in.", "Configuration failed.");
            }          
        }

        private bool CheckAllComponentsConfigured()
        {
            List<SystemComponents> components = (List<SystemComponents>)compBind.DataSource;
            foreach (ContractConfigurations item in configs)
            {
                var results = from comps in components where comps.CompCode == item.ContractConfigurations_Configuration.Configuration_Component.CompCode select comps;
                if (results==null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool SubmitAllProducts()
        {
            bool valid = true;
            foreach (ContractProducts item in products)
            {
                if (!item.InsertContractProduct()) valid = false;
            }

            return valid;
        }

        public bool SubmitAllConfigs()
        {
            bool valid = true;
            foreach (ContractConfigurations item in configs)
            {
                if (!item.InsertContractConfiguration()) valid = false;
            }
            return valid;
        }

        private void btnAnotherProduct_Click(object sender, EventArgs e)
        {
            if (CheckAllComponentsConfigured())
            {
                gbCompInfo.Hide();
                gpProductInformation.Show();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Not all components have been configured.", "Configuration failed.");
            }
            
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (contract.InsertContract()&&SubmitAllProducts()&&SubmitAllConfigs())
            {
                MessageBoxShower.ShowInfo("The Contract has been recorded successfully.", "Success!");
                this.Close();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("The Contract was not recorded succesfully please inspect to ensure validity", "Failure!");
                frmInspectContract ic = new frmInspectContract();
                ic.Show();
                this.Close();
            }
        }
    }
}
