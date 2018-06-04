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
    public partial class frmEmpManagement : Form
    {
        public frmEmpManagement()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProdManagement_Click(object sender, EventArgs e)
        {
            frmProductManagement pm = new frmProductManagement();
            pm.Show();
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

        private void btnNewEmp_Click(object sender, EventArgs e)
        {
            frmNewEmployee emp = new frmNewEmployee();
            emp.Show();
            this.Close();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            frmUpdateEmployee uEmp = new frmUpdateEmployee();
            uEmp.Show();
            this.Close();
        }
        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            frmUpdateEvent ue = new frmUpdateEvent();
            ue.Show();
            this.Close();
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {
            frmNewEvent ne = new frmNewEvent();
            ne.Show();
            this.Close();
        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            frmTechSchedule ts = new frmTechSchedule();
            ts.Show();
            this.Close();
        }
        #endregion
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
