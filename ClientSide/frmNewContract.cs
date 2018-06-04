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

            pnlProducts.Hide();
            pnlComponents.Hide();

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

            List<Product> products = new Product().GetAllProducts();
            foreach (Product item in products)
            {
                if (item.Status=="Discontinued")
                {
                    products.Remove(item);
                }
            }
            productBind.DataSource = products;
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
        private void btnAnotherProduct_Click(object sender, EventArgs e)
        {
            if (CheckAllComponentsConfigured())
            {
                pnlComponents.Hide();
                pnlProducts.Show();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Not all components have been configured.", "Configuration failed.");
            }

        }

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
        #region BindingManagement
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            product = (Product)productBind.Current;
        }

        private void lbComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCompSerial.Clear();
            comp = (SystemComponents)lbComponents.SelectedItem;
            List<Configurations> confs = new Configurations(comp).GetAllConfigurations();
            foreach (Configurations item in confs)
            {
                if (item.Status=="Discontinued")
                {
                    confs.Remove(item);
                }
            }
            configBind.DataSource = confs;
            cmbConf.DataSource = configBind;
            txtConfName.DataBindings.Clear();
            txtConfName.DataBindings.Add("Text", configBind, "Name");
            redConfDesc.DataBindings.Clear();
            redConfDesc.DataBindings.Add("Text", configBind, "Description");
            txtConfAddCost.DataBindings.Clear();
            txtConfAddCost.DataBindings.Add("Text", configBind, "AddCost");
            txtCompSerial.Focus();

            foreach (ContractConfigurations item in configs)
            {
                if (item.ContractConfigurations_Configuration.Configuration_Component== (SystemComponents)compBind.Current)
                {
                    cmbConf.SelectedItem = item.ContractConfigurations_Configuration;
                    txtCompSerial.Text = item.CompSerial;
                    break;
                }
            }
        }

        private void cmbConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateContractInfo())
            {
                client = (Client)clientBind.Current;
                contract = new Contract("", client, new ServiceLevel(cmbServiceLevel.SelectedItem.ToString()), dtpIssueDate.Value, term);
                if (NoDuplicates(contract))
                {
                    pnlContract.Hide();
                    pnlProducts.Show();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("Customer still has an active contract. Please cancel before a new contract is issued.", "Unable to create contract");
                }
                
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Contract cannot be created. Please complete all fields.", "Something went wronng...");
            }
            
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
            if (ValidateProductInfo())
            {
                ContractProducts cp = new ContractProducts(contract, product);
                if (!products.Contains(cp))
                {
                    products.Add(cp);
                    List<SystemComponents> comps = new SystemComponents(product).GetSystemComponents();
                    foreach (SystemComponents item in comps)
                    {
                        if (item.Status=="Discontinued")
                        {
                            comps.Remove(item);
                        }
                    }
                    compBind.DataSource = comps;
                    lbComponents.DataSource = compBind;
                    pnlProducts.Hide();
                    pnlComponents.Show();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("This product has already been added to the contract.", "Duplicate Product");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please select a product before you continue.", "No product selected");
            }
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (contract.InsertContract() && SubmitAllProducts() && SubmitAllConfigs())
            {
                MessageBoxShower.ShowInfo("The Contract has been recorded successfully.", "Success!");
                
                Client current = client;
                double outstandingAmount = 0;
                List<Contract> contracts = new Contract().GetAllContracts(current.ClientIdentifier);
                if (contracts.Count > 0)
                {
                    foreach (Contract item in contracts)
                    {
                        if (item.DateOfIssue.AddMonths(item.TermDuration) > DateTime.UtcNow)
                        {
                            ServiceLevel sl = new ServiceLevel().GetServiceLevels(item.SLevel.Level)[0];
                            List<ContractProducts> cp = new ContractProducts(item, new Product()).GetContractProducts();
                            List<ContractConfigurations> cc = new ContractConfigurations(item).GetContractConfigurations();
                            List<Billing> b = new Billing(current, DateTime.UtcNow, 0, 0).GetClientBilling();
                            int monthsLeft = DateDifference.GetMonthDifference(item.DateOfIssue, item.DateOfIssue.AddMonths(item.TermDuration));
                            if (monthsLeft > 0)
                            {
                                int monthsPaid = DateDifference.GetMonthDifference(item.DateOfIssue, DateTime.UtcNow);
                                double serviceFeePaid = monthsPaid * sl.MonthlyCost;
                                double sumProductCost = (from cProd in cp select cProd.ContractProducts_Product.BasePrice).Sum();
                                double sumAddCosts = (from cConf in cc select cConf.ContractConfigurations_Configuration.AddCost).Sum();
                                double sumProductCostPaid = (from bProd in b select bProd.AmountPaid).Sum() - serviceFeePaid;
                                outstandingAmount = (sumProductCost + sumAddCosts) - sumProductCostPaid;
                            }
                            Billing bill = new Billing(client, DateTime.UtcNow, outstandingAmount, 0);
                            bill.InsertBilling();
                        }

                    }
                }
            }
            this.Close();
        }

        #region Validation
        private bool ValidateContractInfo()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbClients)) valid = false;
            if (!Validation.ValidateCombo(ref cmbServiceLevel)) valid = false;
            if (!Validation.ValidateCombo(ref cmbTerm))
            {
                if (!Validation.ValidateSpinEdit(ref numDuration)) valid = false;
            }
            return valid;
        }

        private bool ValidateProductInfo()
        {
            return Validation.ValidateCombo(ref cmbProducts);
        }

        private bool ValidateConfInfo()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbConf))valid = false ;
            if (!Validation.ValidateTextbox(2, 50, "STRING", ref txtCompSerial)) valid = false;
            return valid;
        }
        private bool CheckAllComponentsConfigured()
        {
            List<SystemComponents> components = (List<SystemComponents>)compBind.DataSource;
            foreach (ContractConfigurations item in configs)
            {
                var results = from comps in components where comps.CompCode == item.ContractConfigurations_Configuration.Configuration_Component.CompCode select comps;
                if (results == null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool NoDuplicates(Contract c)
        {
            List<Contract> contracts = new Contract().GetAllContracts();
            foreach (Contract item in contracts)
            {
                if ((c.ContractClient==item.ContractClient))
                {
                    if (item.DateOfIssue.AddMonths(item.TermDuration)>c.DateOfIssue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            bool found = false;
            config = (Configurations)configBind.Current;
            foreach (ContractConfigurations item in configs)
            {
                if (item.ContractConfigurations_Configuration.Configuration_Component == config.Configuration_Component)
                {
                    item.ContractConfigurations_Configuration = config;
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                if (ValidateConfInfo())
                {
                    configs.Add(new ContractConfigurations(contract, config, txtCompSerial.Text));
                    MessageBoxShower.ShowInfo("Configuration saved!", "Success!");

                }
                else
                {
                    CustomExceptions error = new CustomExceptions("Please complete all fields.", "Configuration failed.");
                }

            }
            txtCompSerial.Clear();
        }
    }
}
