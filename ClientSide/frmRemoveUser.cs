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
    public partial class frmRemoveUser : Form
    {
        BindingSource userBind = new BindingSource();
        public frmRemoveUser()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            userBind.DataSource = new User().GetAllUsers();
            cmbUsers.DataSource = userBind;
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
        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (Validation.ValidateCombo(ref cmbUsers))
            {
                User u = (User)userBind.Current;
                if (u.RemoveUser())
                {
                    MessageBoxShower.ShowInfo("The User have been successfully removed!", "User Removed!");
                    this.Close();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("The user could not be removed. Please try again later.", "Failure!");
                }
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Please select a client to remove.", "No client selected.");
            }
            
        }
    }
}
