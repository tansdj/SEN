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
    public partial class frmNewProduct : Form,IAccessibility
    {
        Product p;
        List<SystemComponents> addComponents = new List<SystemComponents>();
        List<Configurations> addConfigurations = new List<Configurations>();

        public frmNewProduct()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            VerifyAccessibility();

            pnlComponnts.Hide();
            pnlConfiguration.Hide();
            pnlNewProduct.Show();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelComp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region panelNavigation
        private void btnNextConf_Click(object sender, EventArgs e)
        {
            if (addComponents != null)
            {
                pnlComponnts.Hide();
                pnlConfiguration.Show();

                lbComponentsConf.DataSource = addComponents;
            }
            else
            {
                MessageBoxShower.ShowInfo("Please add product Components.", "Unable to proceed");
            }
        }
        private void btnCancelProduct_Click(object sender, EventArgs e)
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

        private void btnNextComp_Click(object sender, EventArgs e)
        {
            if (ValidateProductInfo())
            {
                p = new Product("", txtProductName.Text, redProdDesc.Text, Convert.ToDouble(txtProductPrice.Text), "Active");
                if (NoDuplicates(p))
                {
                    pnlComponnts.Show();
                    pnlNewProduct.Hide();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("A Product with this name has already been added. Please update.", "Cannot add Product");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Product could not be created. Please complete all fields.", "Something went wrong..");
            }
        }
        private void btnAddComp_Click(object sender, EventArgs e)
        {
            if (ValidateComponentInfo())
            {
                bool exist = false;
                SystemComponents sc = new SystemComponents("", p, redCompDesc.Text, "Active", txtCompManufacturer.Text, txtCompModel.Text);
                foreach (SystemComponents item in addComponents)
                {
                    if ((item.Model == sc.Model) && (item.Manufacturer == sc.Manufacturer))
                    {
                        item.Description = sc.Description;
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    addComponents.Add(sc);
                    lbComponents.Items.Add(sc);
                    txtCompModel.Clear();
                    txtCompManufacturer.Clear();
                    redCompDesc.Clear();
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please fill in all required fields.", "Something went wrong..");
            }
            
        }

        private void btnAddConf_Click(object sender, EventArgs e)
        {
            if (ValidateConfInfo())
            {
                bool exist = false;
                Configurations c = new Configurations("", txtConfName.Text, redConfDesc.Text, (SystemComponents)lbComponentsConf.SelectedItem, Convert.ToDouble(txtAddCost.Text), "Active");
                foreach (Configurations item in addConfigurations)
                {
                    if (item.Name == c.Name)
                    {
                        item.Name = txtConfName.Text;
                        item.Description = redConfDesc.Text;
                        item.AddCost = Convert.ToDouble(txtAddCost.Text);
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    addConfigurations.Add(c);
                    lbComponentsConf.SelectedIndex = 0;

                }
                txtConfName.Clear();
                redConfDesc.Clear();
                txtAddCost.Clear();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields.", "Failure!");
            }
           
        }

        private void lbComponentsConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Configurations> confs = new List<Configurations>();
            var items = (from c in addConfigurations where c.Configuration_Component == (SystemComponents)lbComponentsConf.SelectedItem select c);
            foreach (var item in items)
            {
                confs.Add((Configurations)item);
            }
            if (confs.Count>0)
            {
                lbConfs.DataSource = confs;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            bool success = true;
            if (p.InsertProduct())
            {   
                foreach (SystemComponents item in addComponents)
                {
                    if(!item.InsertComponent())success=false;
                }
                foreach (Configurations item in addConfigurations)
                {
                    if(!item.InsertConfig())success=false;
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("The product could not be added succesfully. Please try again.", "Product Error!");
            }

            if (success)
            {
                MessageBoxShower.ShowInfo("The product and its components have been registered.","Success");
                this.Close();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("The product could not be extended/configured succesfully. Please update to ensure correctness.", "Product Error!");
            }
        }

        private void lbConfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configurations conf = (Configurations)lbConfs.SelectedItem;
            txtConfName.Text = conf.Name;
            redConfDesc.Text = conf.Description;
            txtAddCost.Text = conf.AddCost.ToString();
        }

        private void lbComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemComponents sc = (SystemComponents)lbComponents.SelectedItem;
            txtCompModel.Text = sc.Model;
            txtCompManufacturer.Text = sc.Manufacturer;
            redCompDesc.Text = sc.Description;
        }

        #region Validation
        private bool ValidateProductInfo()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtProductName)) valid = false;
            if (!Validation.ValidateRichText(ref redProdDesc)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "DOUBLE", ref txtProductPrice)) valid = false;
            return valid;
        }

        private bool ValidateComponentInfo()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 20, "STRING", ref txtCompModel)) valid = false;
            if (!Validation.ValidateRichText(ref redCompDesc)) valid = false;
            if (!Validation.ValidateTextbox(1, 30, "STRING", ref txtCompManufacturer)) ;
            return valid;
        }

        private bool ValidateConfInfo()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 20, "STRING", ref txtConfName)) valid = false;
            if (!Validation.ValidateRichText(ref redConfDesc)) valid = false;
            if (!Validation.ValidateTextbox(0, 10, "DOUBLE", ref txtAddCost)) valid = false;
            return valid;
        }

        private bool NoDuplicates(Product p)
        {
            List<Product> products = p.GetAllProducts();
            foreach (Product item in products)
            {
                if (item.Name==p.Name)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
