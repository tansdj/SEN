using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public interface ILogin<T>
    {
        bool TestLogin(ref T userObject);
        bool RecoverPassword(T userObject);
    }
}
