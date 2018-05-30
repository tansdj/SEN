using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class frmClientManagement : Form,IAccessibility
    {
        public frmClientManagement()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        #region menuItems
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

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            frmNewClient nc = new frmNewClient();
            nc.Show();
            this.Close();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            frmUpdateClient uc = new frmUpdateClient();
            uc.Show();
            this.Close();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CallSimulator cs = new CallSimulator();
            cs.Show();
        }

        private void btnNewContract_Click(object sender, EventArgs e)
        {
            frmNewContract c = new frmNewContract();
            c.Show();
            this.Close();
        }

        private void btnCancelClient_Click(object sender, EventArgs e)
        {
            frmCancelClient cc = new frmCancelClient();
            cc.Show();
            this.Close();
        }

        private void btnViewContract_Click(object sender, EventArgs e)
        {
            frmInspectContract ic = new frmInspectContract();
            ic.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            frmRecPayment rp = new frmRecPayment();
            rp.Show();
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
    }
}
