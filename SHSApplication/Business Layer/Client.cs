using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using SHSApplication.HelperLibraries;

namespace SHSApplication.Business_Layer
{
    public class Client:Person
    {
        private string paymentMethod;
        private string status;
        private PaymentDetails pd;

        public Client(string personId, string name, string surname, Address personAddress, Contact personContact,string paymentMethod, string status) :base(personId,name,surname,personAddress,personContact)
        {
            this.PaymentMethod = paymentMethod;
            this.Status = status;
        }
        public PaymentDetails PD
        {
            get { return pd; }
            set { pd = value; }
        }


        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }


        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }
            Client c = obj as Client;
            if ((object)c==null)
            {
                return false;
            }
            return base.Equals(obj)&&(this.PaymentMethod==c.PaymentMethod)&&(this.Status==c.Status);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^this.PaymentMethod.GetHashCode()^this.Status.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void NewClientWithPaymentDet(string accNr,string bank,string branchCode)
        {
            Datahandler dh = Datahandler.getData();
            PD = new PaymentDetails(this, accNr, bank, branchCode);
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
           
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });     

            this.PersonAddress.InsertAddress();
            this.PersonContact.InsertContact();
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestInsert, client_details);
            PD.InsertPaymentDetail();
        }

        public void NewClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });

            this.PersonAddress.InsertAddress();
            this.PersonContact.InsertContact();
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestInsert, client_details);
        }

        public void UpdateClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });

            this.PersonAddress.UpdateAddress();
            this.PersonContact.UpdateContact();
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestUpdate, client_details,DataAccesHelper.clientId+" = '"+this.PersonId+"'");
        }

        public void UpdateClientWithPaymentDetails(string accNr, string bank, string branchCode)
        {
            Datahandler dh = Datahandler.getData();
            PD = new PaymentDetails(this, accNr, bank, branchCode);
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> pay_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });

            this.PersonAddress.UpdateAddress();
            this.PersonContact.UpdateContact();
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestUpdate, client_details, DataAccesHelper.clientId + " = '" + this.PersonId + "'");
            PD.UpdatePaymentDetail();
        }

        public void RemoveClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });

            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestDelete, client_details, DataAccesHelper.clientId + " = '" + this.PersonId + "'");
        }

    }
}
