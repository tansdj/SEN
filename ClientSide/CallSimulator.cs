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
    public partial class CallSimulator : Form
    {
        BindingSource bind1 = new BindingSource();
        Client current = new Client();
        DateTime start;
        DateTime end;
        int hours = 0, minutes = 0, seconds = 0;
        public CallSimulator()
        {
            InitializeComponent();
            bind1.DataSource = current.GetAllClients();
            cmbClients.DataSource = bind1;
            cmbClientsHandler.DataSource = bind1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblDialing.Visible = true;
            current = (Client)bind1.Current;
            Thread.Sleep(10000);
            start = DateTime.UtcNow;
            callTime.Start();
            tabCall.SelectedIndex = 1;
            btnAnswer.Visible = false;
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            btnClose.Visible = true;
            current = (Client)bind1.Current;
            if (start != null)
            {
                end = DateTime.UtcNow;
                callTime.Stop();
                CallOperators co = frmMain.loggedIn.GetMatchingCallOperator();
                CallLog call = new CallLog(co, current, start, end, rtxtRemarks.Text);
                if (call.InsertCall())
                {
                    MessageBoxShower.ShowInfo("This called has been logged. Thank you.", "Call Log");
                }
                else
                {
                    CustomExceptions error = new CustomExceptions("This call could not be logged. Please try again", "Logging Error!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            btnClose.Visible = false;
            start = DateTime.UtcNow;
            callTime.Start();
        }

        private void callTime_Tick(object sender, EventArgs e)
        {
            if (seconds==60)
            {
                minutes ++;
                seconds = 0;
            }
            else
            {
                seconds++;
            }
            if (minutes==60)
            {
                hours++;
                minutes = 0;
            }
            
            lblTimer.Text = String.Format("{0}:{1}:{2}",hours.ToString(),minutes.ToString(),seconds.ToString());
        }
    }
}
