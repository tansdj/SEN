using Microsoft.VisualBasic;
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
    public partial class frmCancelClient : Form,IAccessibility
    {
        double outstandingAmount = 0;
        BindingSource bind1 = new BindingSource();
        public frmCancelClient()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            List<Client> clients = new Client().GetAllClients();
            foreach (Client item in clients)
            {
                if (item.Status=="Inactive")
                {
                    clients.Remove(item);
                }
            }
            bind1.DataSource = clients;
            cmbClients.DataSource = bind1;
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
        private void btnCancelClient_Click(object sender, EventArgs e)
        {
            if (Validation.ValidateCombo(ref cmbClients))
            {
                Client current = (Client)bind1.Current;
                Contract c = new Contract().GetAllContracts(current.ClientIdentifier)[0];
                current.Status = "Inactive";
                c.TermDuration = c.TermDuration - Convert.ToInt32((DateAndTime.DateDiff(DateInterval.Month, c.DateOfIssue.AddMonths(c.TermDuration), DateTime.UtcNow)));
                if ((outstandingAmount > 0) && (chcDiffPaid.Checked))
                {
                    Billing b = new Billing(current, DateTime.UtcNow, outstandingAmount, outstandingAmount);
                    if (b.InsertBilling())
                    {
                        if (current.UpdateClient()&&c.UpdateContract())
                        {
                            MessageBoxShower.ShowInfo("Client Deactivated", "Cancel Contract");
                            this.Close();
                        }
                        else
                        {
                            CustomExceptions error = new CustomExceptions("The client contract could not be cancelled.", "Contract Cancel Failed!");
                        }
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The client payment could not be recorded.", "Contract Cancel Failed!");
                    }
                }
                else if (outstandingAmount <= 0)
                {
                    if (current.UpdateClient()&&c.UpdateContract())
                    {
                        MessageBoxShower.ShowInfo("Client Deactivated", "Cancel Contract");
                        this.Close();
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The client contract could not be cancelled.", "Contract Cancel Failed!");
                    }
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("No client selected!", "Something went wrong..");
            } 
        }

       
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalculateOutstanding.Visible = true;
        }

        private void btnCalculateOutstanding_Click(object sender, EventArgs e)
        {
            if (Validation.ValidateCombo(ref cmbClients))
            {
                Client current = (Client)bind1.Current;

                List<Contract> contracts = new Contract().GetAllContracts(current.ClientIdentifier);
                if (contracts.Count>0)
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
                                chcDiffPaid.Visible = true;
                                int monthsPaid = DateDifference.GetMonthDifference(item.DateOfIssue, DateTime.UtcNow);
                                double serviceFeePaid = monthsPaid * sl.MonthlyCost;
                                double sumProductCost = (from cProd in cp select cProd.ContractProducts_Product.BasePrice).Sum();
                                double sumAddCosts = (from cConf in cc select cConf.ContractConfigurations_Configuration.AddCost).Sum();
                                double sumProductCostPaid = (from bProd in b select bProd.AmountPaid).Sum() - serviceFeePaid;
                                outstandingAmount = (sumProductCost + sumAddCosts) - sumProductCostPaid;
                            }
                            else
                            {
                                chcDiffPaid.Visible = false;
                            }
                            txtOutstanding.Text = "R" + outstandingAmount.ToString();
                            txtOutstanding.Visible = true;
                            lblOutstanding.Visible = true;
                            btnCalculateOutstanding.Visible = false;
                            break;
                        }
                        
                    }
                }
                else
                {
                    MessageBoxShower.ShowInfo("This client does not have any active contracts.", "Cannot Cancel contract");
                    txtOutstanding.Visible = false;
                    lblOutstanding.Visible = false;
                    chcDiffPaid.Visible = false;
                }
            }
                
        }
    }
}
