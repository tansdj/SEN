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
    public partial class frmNewUser : Form
    {
        string password;
        public frmNewUser()
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
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (ValidateUser()&&ValidatePassword())
            {
                User u = new User(txtUsername.Text, txtPassword.Text, txtName.Text, txtSurname.Text, txtEmail.Text, cmbAccess.SelectedItem.ToString());
                if (NoDuplicates(u))
                {
                    if (u.InsertUser())
                    {
                        MessageBoxShower.ShowInfo("User Inserted!", "Success!");
                        this.Close();
                    }
                    else
                    {
                        CustomExceptions error = new CustomExceptions("The user could not be inserted. Please try again.", "Something went wrong..");
                    }
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("A User with this email has already been added. Please update.", "Cannot add user.");
                }
            }  
        }

        private void btnGenPw_Click(object sender, EventArgs e)
        {
            char[] chars = new char[] { '@', '#', '$', '%', '&' };
            Random rand = new Random();
            if (txtUsername.Text!="")
            {
                password = txtUsername.Text.Substring(0, 3).ToUpper() + rand.Next(10, 99).ToString() + chars[rand.Next(0, 4)].ToString() + txtUsername.Text.Substring(txtUsername.Text.Length - 3, 2).ToLower(); 
            }
            txtPassword.Text = password;
            txtRePw.Text = password;
            lblAutoPw.Text = "User Password: " + password;
        }

        #region Validation
        private bool ValidateUser()
        {
            bool valid = true;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtName)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtSurname)) valid = false;
            if (!Validation.ValidateTextbox(1, 50, "STRING", ref txtUsername)) valid = false;
            if(!Validation.ValidateTextbox(1,50,"STRING",ref txtEmail))
            {
                valid = false;
            }
            else
            {
                if (txtEmail.Text.IndexOf('@')==-1||txtEmail.Text.IndexOf('.')==-1)
                {
                    valid = false;
                    CustomExceptions error = new CustomExceptions("Invalid Email", "Email error!");
                }
            }
            if (!Validation.ValidateCombo(ref cmbAccess)) valid = false;
            return valid;
        }

        private bool ValidatePassword()
        {
            bool valid = true;
            string password = "";
            char[] specialChars = new char[] { '!','@','#','$','%','^','&','*','(',')','<','>','?',',','.','/','|','-','_'};
            char[] upperCase = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            char[] lowerCase = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] nums = new char[] {'1','2','3','4','5','6','7','8','9','0' };
            if ((!Validation.ValidateTextbox(1, 8, "STRING", ref txtPassword))|| (!Validation.ValidateTextbox(1, 8, "STRING", ref txtRePw)))
            {
                CustomExceptions error_length = new CustomExceptions("Password should be exactly 8 characters long.", "Password Error!");
                valid = false;
            }
            if (txtPassword.Text!=txtRePw.Text)
            {
                CustomExceptions error_equals = new CustomExceptions("Password entry boxes does not match.", "Password Error!");
            }
            else
            {
                password = txtPassword.Text;
                if (password.IndexOfAny(specialChars)==-1)
                {
                    CustomExceptions error_special = new CustomExceptions("Password should contains at least 1 special character.", "Password Error!");
                    valid = false;
                }
                if (password.IndexOfAny(upperCase) == -1)
                {
                    CustomExceptions error_upper = new CustomExceptions("Password should contains at least 1 uppercase character.", "Password Error!");
                    valid = false;
                }
                if (password.IndexOfAny(lowerCase) == -1)
                {
                    CustomExceptions error_lower = new CustomExceptions("Password should contains at least 1 lowercase character.", "Password Error!");
                    valid = false;
                }
                if (password.IndexOfAny(nums) == -1)
                {
                    CustomExceptions error_nums = new CustomExceptions("Password should contains at least 1 digit.", "Password Error!");
                    valid = false;
                }
            }
            return valid;            
        }

        private bool NoDuplicates(User u)
        {
            List<User> users = u.GetAllUsers();
            foreach (User item in users)
            {
                if (item.Email==u.Email)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
