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
    public partial class frmMain : Form,IAccessibility,IUserHandling
    {
        public static User loggedIn;
        public static LoginHandler lh = new LoginHandler();
        public frmMain()
        {
            InitializeComponent();
            frmLogin log = new frmLogin();
            log.Show();
            log.TopMost = true;
            VerifyAccessibility();
           
            lh.LoggedIn += this.OnLogIn;
            lh.LoggedOut += this.OnLogOut;

            if (DateTime.UtcNow.Day==1)
            {
                Billing b = new Billing();
                Thread t = new Thread(b.SendBills);
                t.Start();
            }
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        #region menuItems

        private void btnClientManagement_Click(object sender, EventArgs e)
        {
            frmClientManagement cm = new frmClientManagement();
            cm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProdManagement_Click(object sender, EventArgs e)
        {
            frmProductManagement pm = new frmProductManagement();
            pm.Show();
        }

        private void btnTecManagement_Click(object sender, EventArgs e)
        {
            frmEmpManagement tm = new frmEmpManagement();
            tm.Show(); 
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmUserManagement um = new frmUserManagement();
            um.Show();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CallSimulator cs = new CallSimulator();
            cs.Show();
        }
        #endregion
        #region UserAccessManagement
        public void VerifyAccessibility()
        {
            if (loggedIn!=null)
            {
                btnLoginLogout.Text = "Logout";
                if (loggedIn.Access=="Admin")
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
                btnClientManagement.Enabled = true;
                btnClientManagement.Visible = true;
                btnProdManagement.Enabled = true;
                btnProdManagement.Visible = true;
            }
            else
            {
                btnTecManagement.Enabled = false;
                btnTecManagement.Visible = false;
                btnUserManagement.Enabled = false;
                btnUserManagement.Visible = false;

                btnClientManagement.Enabled = false;
                btnClientManagement.Visible = false;
                btnProdManagement.Enabled = false;
                btnProdManagement.Visible = false;
            }
        }

        private void btnLoginLogout_Click(object sender, EventArgs e)
        {
            if (loggedIn != null)
            {
                lh.LogOut();
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
            }
        }

        public void OnLogIn(object source, EventArgs e)
        {
            VerifyAccessibility();
        }

        public void OnLogOut(object source, EventArgs e)
        {
            loggedIn = null;
            frmLogin l = new frmLogin();
            l.Show();
        }
        #endregion

        private void picLogoSmall_Click(object sender, EventArgs e)
        {
            List<CallLog> calllog = new List<CallLog>();
            Client c = new Client("", "Ina", "de Jager", new Address(), new Contact(), "Debit", "Active","Client1");
            calllog.Add(new CallLog(new CallOperators("", "Tanya", "de Jager", new Address(), new Contact(), ""), new Client("", "Ina", "de Jager", new Address(), new Contact(), "Debit", "Active"), DateTime.UtcNow, DateTime.UtcNow, "Some call detail"));
            calllog.Add(new CallLog(new CallOperators("", "Tanya", "de Jager", new Address(), new Contact(), ""), new Client("", "Ina", "de Jager", new Address(), new Contact(), "Debit", "Active"), DateTime.UtcNow, DateTime.UtcNow, "Some call detail"));
            calllog.Add(new CallLog(new CallOperators("", "Tanya", "de Jager", new Address(), new Contact(), ""), new Client("", "Ina", "de Jager", new Address(), new Contact(), "Debit", "Active"), DateTime.UtcNow, DateTime.UtcNow, "Some call detail"));
            PdfWriter.CreateCallHistoryPdf(c, calllog);
        }
    }
}
