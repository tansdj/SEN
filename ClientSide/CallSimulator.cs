using SHSApplication.Business_Layer;
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
        List<PaymentDetails> details = new PaymentDetails().GetAllPaymentDetails();
        BindingSource bind1 = new BindingSource();
        Client current = new Client();
        DateTime start = new DateTime();
        DateTime end = new DateTime();
        int hours = 0, minutes = 0, seconds = 0;
        public CallSimulator()
        {
            InitializeComponent();
            bind1.DataSource = new Client().GetAllClients();
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
            end = DateTime.UtcNow;
            //Test if call was taken
            callTime.Stop();
            CallOperators co = new CallOperators();
            CallLog call = new CallLog(co, current, start, end, rtxtRemarks.Text);
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
