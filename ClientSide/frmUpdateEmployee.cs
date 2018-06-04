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
            txtName.DataBindings.Add("Text", empBind, "Name");
            txtSurname.DataBindings.Add("Text", empBind, "Surname");
            txtLine1.DataBindings.Add("Text", empBind, "PersonAddress.AddressLine1");
            txtLine2.DataBindings.Add("Text", empBind, "PersonAddress.AddressLine2");
            txtCity.DataBindings.Add("Text", empBind, "PersonAddress.City");
            txtPostalCode.DataBindings.Add("Text", empBind, "PersonAddress.PostalCode");
            txtCell.DataBindings.Add("Text", empBind, "PersonContact.Cell");
            txtEmail.DataBindings.Add("Text", empBind, "PersonContact.Email");
            cmbStatus.DataBindings.Add("SelectedItem", empBind, "Status");
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
        #region userAccessManagement
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString() == "Technician")
            {
                lblSkill.Visible = true;
                cmbSkill.Visible = true;
                cmbSkill.DataBindings.Clear();
                cmbSkill.DataBindings.Add("SelectedItem", empBind, "SkillLevel");
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
        #endregion
        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (empBind.Current is Technicians)
                {
                    Technicians t = (Technicians)empBind.Current;
                    if (t.UpdateTech())
                    {
                        MessageBoxShower.ShowInfo("The Technician was successfully updated!", "Success");
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The Technician could not be updated.Please try again later.", "Something went wrong..");
                    }
                }
                else if (empBind.Current is CallOperators)
                {
                    CallOperators co = (CallOperators)empBind.Current;
                    if (co.UpdateCallOperator())
                    {
                        MessageBoxShower.ShowInfo("The Call Operator was successfully updated!", "Success");
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The Call Operator could not be updated.Please try again later.", "Something went wrong..");
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            bool valid = true;
            if (!Validation.ValidateCombo(ref cmbEmps)) valid = false;
            if (Validation.ValidateCombo(ref cmbType))
            {
                if (cmbType.SelectedItem.ToString() == "Technician")
                {
                    if (!Validation.ValidateCombo(ref cmbSkill)) valid = false;
                }
            }
            else
            {
                valid = false;
            }
            if (!Validation.ValidateTextbox(13, 13, "LONGINT", ref txtId)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtName)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtSurname)) valid = false;
            if (!Validation.ValidateTextbox(1, 30, "STRING", ref txtLine1)) valid = false;
            if (!Validation.ValidateTextbox(1, 30, "STRING", ref txtLine2)) valid = false;
            if (!Validation.ValidateTextbox(1, 20, "STRING", ref txtCity)) valid = false;
            if (!Validation.ValidateTextbox(1, 10, "INT", ref txtPostalCode)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtEmail)) valid = false;
            if (!Validation.ValidateTextbox(10, 10, "INT", ref txtCell)) valid = false;
            if (!Validation.ValidateCombo(ref cmbStatus)) valid = false;


            return valid;
        }

        private void cmbEmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empBind.Current is Technicians)
            {
                Technicians t = (Technicians)empBind.Current;
                cmbType.SelectedItem = "Technician";
            }
            else
            {
                cmbType.SelectedItem = "Call Operator";
            }
        }
    }
}
