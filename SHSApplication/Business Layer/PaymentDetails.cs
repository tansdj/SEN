using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class PaymentDetails
    {
        private Client paymentDet_client;
        private string accNr;
        private string bank;
        private string branchCode;

        public PaymentDetails()
        {

        }

        public string BranchCode
        {
            get { return branchCode; }
            set { branchCode = value; }
        }


        public string Bank
        {
            get { return bank; }
            set { bank = value; }
        }


        public string AccNr
        {
            get { return accNr; }
            set { accNr = value; }
        }


        public Client PaymentDet_Client
        {
            get { return paymentDet_client; }
            set { paymentDet_client = value; }
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

        public void deductDebit(string clientId) { }

        public void reverseDebit(string clientId) { }

        public void deleteDebit(string clientId) { }

    }
}
