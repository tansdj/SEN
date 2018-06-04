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
        #region UserAccessManagement
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
        #endregion
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (cmbType.SelectedItem.ToString() == "Technician")
                {
                    Technicians t = new Technicians(txtId.Text, txtName.Text, txtSurname.Text, new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbStatus.SelectedItem.ToString(), cmbSkill.SelectedItem.ToString());
                    if (NoDuplicates(t))
                    {
                        if (t.AddTech())
                        {
                            MessageBoxShower.ShowInfo("The Technician was added to the system.", "Success!");
                            this.Close();
                        }
                        else
                        {
                            CustomExceptions error = new CustomExceptions("The Technician could not be added. Please try again.", "Failure!");
                        }
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("A technician with this ID has already been added. Please update.", "Cannot add technician.");
                    } 
                }
                else if (cmbType.SelectedItem.ToString() == "Call Operator")
                {
                    CallOperators c = new CallOperators(txtId.Text, txtName.Text, txtSurname.Text, new Address("", txtLine1.Text, txtLine2.Text, txtCity.Text, txtPostalCode.Text), new Contact("", txtCell.Text, txtEmail.Text), cmbStatus.SelectedItem.ToString());
                    if (NoDuplicates(c))
                    {
                        if (c.InsertCallOperator())
                        {
                            MessageBoxShower.ShowInfo("The Call Operator was added to the system.", "Success!");
                            this.Close();
                        }
                        else
                        {
                            CustomExceptions error = new CustomExceptions("The Call Operator could not be added. Please try again.", "Failure!");
                        }
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("A Call Operator with this ID has already been added. Please update.", "Cannot add Call Operator.");
                    }
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please complete all fields.", "Cannot add Employee.");
            }
 
        }
        #region Validation
        private bool ValidateForm()
        {
            bool valid = true;
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

        private bool NoDuplicates(object emp)
        {
            if (emp is Technicians)
            {
                Technicians t = (Technicians)emp;
                List<Technicians> techs = t.GetAllTechnicians();
                foreach (Technicians item in techs)
                {
                    if (item.PersonId==t.PersonId)
                    {
                        return false;
                    }
                }
            }
            else if (emp is CallOperators)
            {
                CallOperators co = (CallOperators)emp;
                List<CallOperators> callOps = co.GetCallOperators();
                foreach (CallOperators item in callOps)
                {
                    if (item.PersonId==co.PersonId)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
