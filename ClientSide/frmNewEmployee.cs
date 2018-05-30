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
    public partial class frmNewEmployee : Form
    {
        public frmNewEmployee()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            lblSkill.Visible = false;
            cmbSkill.Visible = false;
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

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString()== "Technician")
            {
                Technicians t = new Technicians(txtId.Text, txtName.Text, txtSurname.Text,new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbStatus.SelectedItem.ToString(), cmbSkill.SelectedItem.ToString());
                if (t.AddTech())
                {
                    MessageBoxShower.ShowInfo("The Technician was added to the system.", "Success!");
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The Technician could not be added. Please try again.", "Failure!");
                }
            }
            else if (cmbType.SelectedItem.ToString() == "Call Operator")
            {
                CallOperators c = new CallOperators(txtId.Text, txtName.Text, txtSurname.Text, new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbStatus.SelectedItem.ToString());
                if (c.InsertCallOperator())
                {
                    MessageBoxShower.ShowInfo("The Call Operator was added to the system.", "Success!");
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The Call Operator could not be added. Please try again.", "Failure!");
                }
            }
        }
    }
}
