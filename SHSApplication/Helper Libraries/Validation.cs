using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHSApplication.Helper_Libraries
{
    public static class Validation
    {
        public static bool ValidateTextbox(int minLength,int maxLength,string type,ref TextBox t)
        {
            bool validated = true;
            if ((t.Text.Length>=minLength)&&(t.Text.Length<=maxLength))
            {
                validated = true;
                switch (type)
                {
                    case "STRING":validated = true;break;
                    case "INT":
                            int valInt = Convert.ToInt32(t.Text);
                            if (valInt == 0) validated = false;
                        break;
                    case "DOUBLE":
                        double valD = Convert.ToDouble(t.Text);
                        if (valD == 0) validated = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                validated = false;
            }
            if (!validated)
            {
                t.BackColor = System.Drawing.Color.Red;
            }
            return validated;
        }

        public static bool ValidateCombo(ref ComboBox cb)
        {
            if (cb.SelectedIndex!=-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
