using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHSApplication.Business_Layer
{
    public class CustomExceptions:Exception
    {
        public CustomExceptions(string message, string topic):base(message)
            {
            MessageBox.Show(message, topic, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
