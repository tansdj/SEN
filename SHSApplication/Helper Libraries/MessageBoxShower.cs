using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHSApplication.Helper_Libraries
{
    public static class MessageBoxShower
    {
        public static void ShowInfo(string message, string topic)
        {
            MessageBox.Show(message, topic, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
