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

        public Billing()
        {

        }

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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
