using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    interface IUserHandling
    {
        void OnLogIn(object source, EventArgs e);
        void OnLogOut(object source, EventArgs e);
    }
}
