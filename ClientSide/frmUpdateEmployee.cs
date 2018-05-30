using SHSApplication.Business_Layer;
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
    public partial class frmUpdateEmployee : Form
    {
        BindingSource empBind = new BindingSource();
        List<Technicians> techs = new Technicians().GetAllTechnicians();
        List<CallOperators> cOps = new CallOperators().GetCallOperators();
        List<object> employees = new List<object>();
        public frmUpdateEmployee()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            lblSkill.Visible = false;
            cmbSkill.Visible = false;
            foreach (Technicians item in techs)
            {
                employees.Add(item);
            }
            foreach (CallOperators item in cOps)
            {
                employees.Add(item);
            }

            empBind.DataSource = employees;
            cmbEmps.DataSource = empBind;
            cmbEmps.DisplayMember = "Name" +" "+"Surname";
            txtId.DataBindings.Add("Text", empBind, "PersonId");
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
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString() == "Technician")
            {
                lblSkill.Visible = true;
                cmbSkill.Visible = true;
            }
            else
            {
                lblSkill.Visible = false;
                cmbSkill.Visible = false;
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
