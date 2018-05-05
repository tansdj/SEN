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
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
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
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId});
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });
            pay_details.Add(DataAccesHelper.paymentDetClientId, new string[] { DataAccesHelper.typeString, this.PD.PaymentDet_Client.PersonId });
            pay_details.Add(DataAccesHelper.paymentDetAccNr, new string[] { DataAccesHelper.typeString, this.PD.AccNr });
            pay_details.Add(DataAccesHelper.paymentDetBank, new string[] { DataAccesHelper.typeString, this.PD.Bank });
            pay_details.Add(DataAccesHelper.paymentDetBranch, new string[] { DataAccesHelper.typeString, this.PD.BranchCode });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestInsert, addr_details);
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestInsert, cont_details);
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestInsert, client_details);
            dh.runQuery(DataAccesHelper.targetPaymentDetails, DataAccesHelper.requestInsert, pay_details);
        }

        public void NewClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestInsert, addr_details);
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestInsert, cont_details);
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestInsert, client_details);
        }

        public void UpdateClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestUpdate, addr_details,DataAccesHelper.addressId+" = '"+this.PersonAddress.AddressId+"'");
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestUpdate, cont_details,DataAccesHelper.contactId+" = '"+this.PersonContact.ContactId+"'");
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestUpdate, client_details,DataAccesHelper.clientId+" = '"+this.PersonId+"'");
        }

        public void UpdateClientWithPaymentDetails(string accNr, string bank, string branchCode)
        {
            Datahandler dh = Datahandler.getData();
            PD = new PaymentDetails(this, accNr, bank, branchCode);
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
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
            addr_details.Add(DataAccesHelper.addressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            addr_details.Add(DataAccesHelper.addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            addr_details.Add(DataAccesHelper.addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            addr_details.Add(DataAccesHelper.addrCity, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            cont_details.Add(DataAccesHelper.contactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            cont_details.Add(DataAccesHelper.contactCell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            cont_details.Add(DataAccesHelper.contactEmail, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });
            pay_details.Add(DataAccesHelper.paymentDetClientId, new string[] { DataAccesHelper.typeString, this.PD.PaymentDet_Client.PersonId });
            pay_details.Add(DataAccesHelper.paymentDetAccNr, new string[] { DataAccesHelper.typeString, this.PD.AccNr });
            pay_details.Add(DataAccesHelper.paymentDetBank, new string[] { DataAccesHelper.typeString, this.PD.Bank });
            pay_details.Add(DataAccesHelper.paymentDetBranch, new string[] { DataAccesHelper.typeString, this.PD.BranchCode });

            dh.runQuery(DataAccesHelper.targetAddress, DataAccesHelper.requestUpdate, addr_details, DataAccesHelper.addressId + " = '" + this.PersonAddress.AddressId + "'");
            dh.runQuery(DataAccesHelper.targetContact, DataAccesHelper.requestUpdate, cont_details, DataAccesHelper.contactId + " = '" + this.PersonContact.ContactId + "'");
            dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestUpdate, client_details, DataAccesHelper.clientId + " = '" + this.PersonId + "'");
            dh.runQuery(DataAccesHelper.targetPaymentDetails, DataAccesHelper.requestUpdate, pay_details, DataAccesHelper.paymentDetClientId + " = '" + this.PersonId + "'");
        }

    }
}
