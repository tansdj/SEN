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
    public partial class frmUpdateProduct : Form,IAccessibility
    {
        BindingSource prodBind = new BindingSource();
        BindingSource compBind = new BindingSource();
        BindingSource confBind = new BindingSource();
        List<Configurations> confsToUpdate = new List<Configurations>();
        List<SystemComponents> compsToUpdate = new List<SystemComponents>();
        public frmUpdateProduct()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();

            prodBind.DataSource = new Product().GetAllProducts();
            cmbProducts.DataSource = prodBind;
            txtProductName.DataBindings.Add("Text", prodBind, "Name");
            redProdDesc.DataBindings.Add("Text", prodBind, "Description");
            txtProductPrice.DataBindings.Add("Text", prodBind, "BasePrice");
            cmbProdStatus.DataBindings.Add("SelectedItem", prodBind, "Status");

            pnlComp.Hide();
            pnlConf.Hide();
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
            this.Close();
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
        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNextComp_Click(object sender, EventArgs e)
        {
            if (ValidateProductInfo())
            {
                compBind.DataSource = new SystemComponents((Product)prodBind.Current).GetSystemComponents();
                lbComponents.DataSource = compBind;

                txtCompName.DataBindings.Add("Text", compBind, "Model");
                txtCompManufacturer.DataBindings.Add("Text", compBind, "Manufacturer");
                redCompDesc.DataBindings.Add("Text", compBind, "Description");
                cmbCompStatus.DataBindings.Add("Text", compBind, "Status");
                pnlProduct.Hide();
                pnlComp.Show();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Product cannot be created.");
            }
            
        }

        private void btnCancelComp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNextConf_Click(object sender, EventArgs e)
        {
            compsToUpdate = (List<SystemComponents>)compBind.DataSource;

            lbConfs.DataSource = confBind;
            lbComponentsConf.DataSource = compBind;
            
            pnlComp.Hide();
            pnlConf.Show();
        }

        private void btnCancelConf_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool success = true;
            Product p = (Product)prodBind.Current;
            if (p.UpdateProduct())
            {
                foreach (SystemComponents item in compsToUpdate)
                {
                    if (ValidateComponentInfo(item))
                    {
                        if (!item.UpdateComponent()) success = false;
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("Cannot update component "+item.Model+" due to incorrect input.", "Validation error!"); 
                    }
                }
                foreach (Configurations item in confsToUpdate)
                {
                    if (!item.UpdateConfig()) success = false;
                } 
            }
            else
            {
                CustomExceptions error = new CustomExceptions("The product could not be updated. Please try again.", "Something went wrong..");
            }
            if (!success)
            {
                CustomExceptions error = new CustomExceptions("Not all configurations was updated. Please try again.", "Something went wrong..");
            }
            else
            {
                MessageBoxShower.ShowInfo("The product and its configurations was updated successfully!", "Success!");
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
        #region Validation
        private bool ValidateProductInfo()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtProductName)) valid = false;
            if (!Validation.ValidateRichText(ref redProdDesc)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "DOUBLE", ref txtProductPrice)) valid = false;
            return valid;
        }

        private bool ValidateComponentInfo(SystemComponents sc)
        {
            bool valid = true;
            if (sc.Description.Length == 0) valid = false;
            if (sc.Status == "") valid = false;
            return valid;
        }

        private bool ValidateConfInfo()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 20, "STRING", ref txtConfName)) valid = false;
            if (!Validation.ValidateRichText(ref redConfDesc)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "DOUBLE", ref txtAddCost)) valid = false;
            return valid;
        }
        #endregion
        private void lbComponentsConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Configurations> confs = (List<Configurations>)confBind.DataSource;
            if (confs!=null)
            {
                foreach (Configurations item in confs)
                {
                    var items = (from c in confsToUpdate where item.Name == c.Name select c);
                    List<Configurations> configs = new List<Configurations>();
                    foreach (var confItem in items)
                    {
                        configs.Add(confItem);
                    }
                    
                    if (configs.Count > 0)
                    {
                        Configurations confFound = configs[0];
                        int i = confsToUpdate.IndexOf(confFound);
                        confsToUpdate[i].Description = item.Description;
                        confsToUpdate[i].AddCost = item.AddCost;
                    }
                    else
                    {
                        confsToUpdate.Add(item);
                    } 
                }
            }
            List<Configurations> confsToBind = new Configurations((SystemComponents)compBind.Current).GetAllConfigurations();
            foreach (Configurations item in confsToBind)
            {
                var items = from c in confsToUpdate where (c.Name == item.Name) select c;
                List<Configurations> configs = new List<Configurations>();
                foreach (var confItem in items)
                {
                    configs.Add(confItem);
                }
                if (configs.Count>0)
                {
                    Configurations conf = configs[0];
                    item.Description = conf.Description;
                    item.AddCost = conf.AddCost;
                }
            }
            confBind.DataSource = confsToBind;
            txtConfName.DataBindings.Clear();
            txtConfName.DataBindings.Add("Text", confBind, "Name");
            redConfDesc.DataBindings.Clear();
            redConfDesc.DataBindings.Add("Text", confBind, "Description");
            txtAddCost.DataBindings.Clear();
            txtAddCost.DataBindings.Add("Text", confBind, "AddCost");
            cmbConfStatus.DataBindings.Clear();
            cmbConfStatus.DataBindings.Add("SelectedItem", confBind, "Status");
        }
    }
}
