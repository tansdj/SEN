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
    public partial class frmCallHistory : Form,IAccessibility
    {
 
        public frmCallHistory()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            cmbClients.DataSource = new Client().GetAllClients();
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
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
                this.Close();
            }
        }
        #endregion

        private void btnRetrieveHistory_Click(object sender, EventArgs e)
        {
            Client c = (Client)cmbClients.SelectedItem;
            List<CallLog> calls = new CallLog(new CallOperators(), c, new DateTime(), new DateTime(), "").GetCalls(c.ClientIdentifier);
            PdfWriter.CreateCallHistoryPdf(c, calls);
        }

        
    }
}
