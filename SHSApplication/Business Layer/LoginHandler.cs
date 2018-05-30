using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class LoginHandler
    {
        public delegate void UserLoggedInEventHandler(object source, EventArgs e);
        public event UserLoggedInEventHandler LoggedIn;

        public delegate void UserLoggedOutEventHandler(object source, EventArgs e);
        public event UserLoggedOutEventHandler LoggedOut;

        public LoginHandler()
        {

        }

        public void LogIn()
        {
            OnLoggedIn();
        }

        public void LogOut()
        {
            OnLoggedOut();
        }

        protected virtual void OnLoggedIn()
        {
            if (LoggedIn != null) LoggedIn(this, EventArgs.Empty);
        }

        protected virtual void OnLoggedOut()
        {
            if (LoggedOut != null) LoggedOut(this, EventArgs.Empty);
        }
    }
}
