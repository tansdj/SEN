using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Billing
    {
        private string clientId;
        private DateTime date;
        private double amountDue;
        private double amountPaid;

        public Billing(string clientId, DateTime date, double amountDue, double amountPaid)
        {
            this.ClientId = clientId;
            this.Date = date;
            this.AmountDue = amountDue;
            this.AmountPaid = amountPaid;
        }

        public Billing(){}

        public double AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }


        public double AmountDue
        {
            get { return amountDue; }
            set { amountDue = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Billing b = obj as Billing;
            if ((object)b==null)
            {
                return false;
            }
            return (this.ClientId==b.ClientId)&&(this.Date==b.Date)&&(this.AmountDue==b.AmountDue)&&(this.AmountPaid==b.AmountPaid);
        }

        public override int GetHashCode()
        {
            return this.ClientId.GetHashCode()^this.Date.GetHashCode()^this.AmountDue.GetHashCode()^this.AmountPaid.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public List<Billing> monthlyBill(string clientId)
        {
            List<Billing> bill = new List<Billing>();

            return bill;
        }

        public void payBill(double amount) { }
    }
}
