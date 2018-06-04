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
    public partial class frmUpdateEvent : Form,IAccessibility
    {
        BindingSource eventBind = new BindingSource();
        BindingSource techBind = new BindingSource();
        public frmUpdateEvent()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            List<Technicians> techs = new Technicians().GetAllTechnicians();
            techBind.DataSource = techs;
            eventBind.DataSource = new RequestedEvents().GetRequestedEvents();
            cmbEvents.DataSource = eventBind;

            dtpReqDate.DataBindings.Add("Value", eventBind, "RequestedDate");
            txtRemarks.DataBindings.Add("Text", eventBind, "Remarks");
            cmbSkill.DataBindings.Add("SelectedItem", eventBind, "SkillRequired");
            cmbStatus.DataBindings.Add("SelectedItem", eventBind, "Status");
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
            if (frmMain.loggedIn!=null)
            {
                btnLoginLogout.Text = "Logout";
                if (frmMain.loggedIn.Access=="Admin")
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
            if (frmMain.loggedIn != null)
            {
                frmMain.lh.LogOut();
            }
            else
            {
                frmLogin l = new frmLogin();
                l.Show();
            }
        }

        #endregion

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (Validation.ValidateCombo(ref cmbEvents)&&Validation.ValidateCombo(ref cmbTechs))
            {
                RequestedEvents currentEvent = (RequestedEvents)eventBind.Current;
                TechnicalLog tl = new TechnicalLog(currentEvent, (Technicians)techBind.Current);
                if (currentEvent.UpdateEvent()&& tl.LogEvent())
                {
                    MessageBoxShower.ShowInfo("The event was successfully updated.", "Success!");
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The event could not be updated. Please try again later.", "Something went wrong..");
                }
                Scheduler.ScheduleEvents();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields correctly.", "Validation Error");
            }
        }
    }
}
