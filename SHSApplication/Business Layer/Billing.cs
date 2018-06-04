using Serverside.HelperLibraries;
using ServerSide;
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

        public bool InsertBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.ClientIdentifier });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });
            
            return dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestInsert, billing_details);
        }

        public bool UpdateBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.ClientIdentifier });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });

            return dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestUpdate, billing_details,DataAccesHelper.billingClientid+" = '"+this.Billing_Client.ClientIdentifier+"'");
        }

        public bool RemoveBilling()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> billing_details = new Dictionary<string, string[]>();

            billing_details.Add(DataAccesHelper.billingClientid, new string[] { DataAccesHelper.typeString, this.Billing_Client.ClientIdentifier });
            billing_details.Add(DataAccesHelper.billingDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            billing_details.Add(DataAccesHelper.billAmountDue, new string[] { DataAccesHelper.typeDouble, this.AmountDue.ToString() });
            billing_details.Add(DataAccesHelper.billAmountPaid, new string[] { DataAccesHelper.typeDouble, this.AmountPaid.ToString() });

            return dh.runQuery(DataAccesHelper.targetBilling, DataAccesHelper.requestDelete, billing_details, DataAccesHelper.billingClientid + " = '" + this.Billing_Client.ClientIdentifier + "'");
        }

        public List<Billing> GetClientBilling()
        {
            Datahandler dh = Datahandler.getData();
            List<Billing> bill = new List<Billing>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetBilling+this.Billing_Client.ClientIdentifier+"'");

            foreach (DataRow item in table.Rows)
            {
                Billing b = new Billing();
                b.Billing_Client = new Client();
                b.Billing_Client.ClientIdentifier = item[DataAccesHelper.billingClientid].ToString();
                b.AmountDue = Convert.ToDouble(item[DataAccesHelper.billAmountDue].ToString());
                b.AmountPaid = Convert.ToDouble(item[DataAccesHelper.billAmountPaid].ToString());
                b.Date = Convert.ToDateTime(item[DataAccesHelper.billingDate].ToString());
                bill.Add(b);
            }
            return bill;
        }

        public void payBill(double amount) { }

        public void SendBills()
        {

        }
    }
}
