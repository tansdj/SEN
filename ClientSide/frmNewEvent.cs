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
    public partial class frmNewEvent : Form,IAccessibility
    {
        BindingSource clientBind = new BindingSource();
        public frmNewEvent()
        {
            InitializeComponent();
            VerifyAccessibility();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

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
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
                this.Close();
            }
        }

        #endregion

        private void btnReqEvent_Click(object sender, EventArgs e)
        {
            if (ValidateEvent())
            {
                RequestedEvents reqEvent = new RequestedEvents((Client)clientBind.Current,dtpReqDate.Value, cmbStatus.SelectedItem.ToString(), txtRemarks.Text,cmbSkill.SelectedItem.ToString());
                if (reqEvent.NewEvent())
                {
                    MessageBoxShower.ShowInfo("The event has been logged succesfully.", "Success");
                    Scheduler.ScheduleEvents();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The event could not be scheduled. Please try again later.", "Success");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Validation Error!");
            }
        }

        private bool ValidateEvent()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbClients)) valid = false;
            if (!Validation.ValidateTextbox(1, 100, "STRING", ref txtRemarks)) valid = false;
            if (!Validation.ValidateCombo(ref cmbStatus)) valid = false;
            if (!Validation.ValidateCombo(ref cmbSkill)) valid = false;
            return valid;
        }
    }
}
