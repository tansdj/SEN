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
    public partial class frmLogin : Form
    {
        public static User loggedIn;
        public frmLogin()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User u = new User(txtUsername.Text,txtPassword.Text,"","","","");
            if (u.TestLogin(ref u))
            {
                frmMain.loggedIn = u;
                frmMain.lh.LogIn();
                MessageBoxShower.ShowInfo("Welcome " + u.Username,"Log in succesful!");
                this.Close();
            }
            else
            {
                CustomExceptions error = new CustomExceptions("Could not Log in. Please try again.", "Login Failed!");
            }
        }

        private void btnRecPw_Click(object sender, EventArgs e)
        {
            User u = new User();
            string email = Microsoft.VisualBasic.Interaction.InputBox("Please enter the email address associated with your account:", "Email Address", "", 0, 0);
            u = u.GetAllUsers(email)[0];
            if (u.Password!="")
            {
                if (u.RecoverPassword(u))
                {
                    MessageBoxShower.ShowInfo("Your password have been emailed to: " + u.Email, "Password Recovered.");
                    this.Close();
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("Could not recover password. Please try again...", "Password Recovery Failed!");
                }
            }
            else
            {
                MessageBoxShower.ShowInfo("Your account could not be found. Please try again or contact your administrator.", "Password Recovery failed!");
            }

        }
    }
}
