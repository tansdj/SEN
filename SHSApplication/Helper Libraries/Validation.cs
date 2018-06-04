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
                    case "LONGINT":
                        long valLongInt = Convert.ToInt64(t.Text);
                        if (valLongInt == 0) validated = false;
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
                t.BackColor = System.Drawing.Color.Tomato;
            }
            else
            {
                t.BackColor = System.Drawing.Color.FromArgb(64,64,64);
            }
            return validated;
        }

        public static bool ValidateCombo(ref ComboBox cb)
        {
            if (cb.SelectedIndex!=-1)
            {
                cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
                return true;
            }
            else
            {
                cb.BackColor = System.Drawing.Color.Tomato;
                return false;
            }
        }

        public static bool ValidateRichText(ref RichTextBox rt)
        {
            if (rt.Text.Length>0)
            {
                rt.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
                return true;
            }
            else
            {
                rt.BackColor = System.Drawing.Color.Tomato;
                return false;
            }
        }

        public static bool ValidateSpinEdit(ref NumericUpDown num)
        {
            if (num.Value > 0)
            {
                num.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
                return true;
            }
            else
            {
                num.BackColor = System.Drawing.Color.Tomato;
                return false;
            }
        }
    }
}
