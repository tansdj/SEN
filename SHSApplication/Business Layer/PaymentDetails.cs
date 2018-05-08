using Serverside.HelperLibraries;
using ServerSide;
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

        public PaymentDetails(Client paymentDet_client, string accNr, string bank, string branchCode)
        {
            this.PaymentDet_Client = paymentDet_client;
            this.AccNr = accNr;
            this.Bank = bank;
            this.BranchCode = branchCode;
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
            if (obj==null)
            {
                return false;
            }

            PaymentDetails pd = obj as PaymentDetails;
            if ((object)pd==null)
            {
                return false;
            }
            return (this.PaymentDet_Client==pd.PaymentDet_Client)&&(this.AccNr==pd.AccNr)&&(this.Bank==pd.Bank)&&(this.BranchCode==pd.BranchCode);
        }

        public override int GetHashCode()
        {
            return this.PaymentDet_Client.GetHashCode() ^ this.AccNr.GetHashCode() ^ this.Bank.GetHashCode() ^ this.BranchCode.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertPaymentDetail()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> pay_details = new Dictionary<string, string[]>();

            pay_details.Add(DataAccesHelper.paymentDetClientId, new string[] { DataAccesHelper.typeString, this.PaymentDet_Client.PersonId });
            pay_details.Add(DataAccesHelper.paymentDetAccNr, new string[] { DataAccesHelper.typeString, this.AccNr });
            pay_details.Add(DataAccesHelper.paymentDetBank, new string[] { DataAccesHelper.typeString, this.Bank });
            pay_details.Add(DataAccesHelper.paymentDetBranch, new string[] { DataAccesHelper.typeString, this.BranchCode });

            dh.runQuery(DataAccesHelper.targetPaymentDetails, DataAccesHelper.requestInsert, pay_details);
        }

        public void UpdatePaymentDetail()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> pay_details = new Dictionary<string, string[]>();

            pay_details.Add(DataAccesHelper.paymentDetClientId, new string[] { DataAccesHelper.typeString, this.PaymentDet_Client.PersonId });
            pay_details.Add(DataAccesHelper.paymentDetAccNr, new string[] { DataAccesHelper.typeString, this.AccNr });
            pay_details.Add(DataAccesHelper.paymentDetBank, new string[] { DataAccesHelper.typeString, this.Bank });
            pay_details.Add(DataAccesHelper.paymentDetBranch, new string[] { DataAccesHelper.typeString, this.BranchCode });

            dh.runQuery(DataAccesHelper.targetPaymentDetails, DataAccesHelper.requestUpdate, pay_details, DataAccesHelper.paymentDetClientId + " = '" + this.PaymentDet_Client.PersonId + "'");
        }

        public void RemovePaymnetDetail()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> pay_details = new Dictionary<string, string[]>();

            pay_details.Add(DataAccesHelper.paymentDetClientId, new string[] { DataAccesHelper.typeString, this.PaymentDet_Client.PersonId });
            pay_details.Add(DataAccesHelper.paymentDetAccNr, new string[] { DataAccesHelper.typeString, this.AccNr });
            pay_details.Add(DataAccesHelper.paymentDetBank, new string[] { DataAccesHelper.typeString, this.Bank });
            pay_details.Add(DataAccesHelper.paymentDetBranch, new string[] { DataAccesHelper.typeString, this.BranchCode });

            dh.runQuery(DataAccesHelper.targetPaymentDetails, DataAccesHelper.requestDelete, pay_details, DataAccesHelper.paymentDetClientId + " = '" + this.PaymentDet_Client.PersonId + "'");
        }
        public void deductDebit(string clientId) { }

        public void reverseDebit(string clientId) { }

        public void deleteDebit(string clientId) { }

    }
}
