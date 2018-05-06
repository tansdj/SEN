using ServerSide;
using SHSApplication.HelperLibraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Billing
    {
        private Client billing_client;
        private DateTime date;
        private double amountDue;
        private double amountPaid;

        public Billing(Client billing_client, DateTime date, double amountDue, double amountPaid)
        {
            this.Billing_Client = billing_client;
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


        public Client Billing_Client
        {
            get { return billing_client; }
            set { billing_client = value; }
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
            return (this.Billing_Client==b.Billing_Client)&&(this.Date==b.Date)&&(this.AmountDue==b.AmountDue)&&(this.AmountPaid==b.AmountPaid);
        }

        public override int GetHashCode()
        {
            return this.Billing_Client.GetHashCode()^this.Date.GetHashCode()^this.AmountDue.GetHashCode()^this.AmountPaid.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.PersonId });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });
            
            dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestInsert, billing_details);
        }

        public void UpdateBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.PersonId });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });

            dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestUpdate, billing_details,DataAccesHelper.billingClientid+" = '"+this.Billing_Client.PersonId+"'");
        }

        public void RemoveBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.PersonId });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });

            dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestDelete, billing_details, DataAccesHelper.billingClientid + " = '" + this.Billing_Client.PersonId + "'");
        }

        public List<Billing> monthlyBill(string clientId)
        {
            string query = "";
            Datahandler dh = Datahandler.getData();
            List<Billing> bill = new List<Billing>();
            DataTable table = dh.readDataFromDB(query);

            return bill;
        }

        public void payBill(double amount) { }
    }
}
