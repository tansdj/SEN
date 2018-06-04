using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;
using ServerSide.HelperLibrabries;

namespace SHSApplication.Business_Layer
{
    public class Client:Person
    {
        private string paymentMethod;
        private string status;
        private PaymentDetails pd;
        private string clientIdentifier;

        public Client(string personId, string name, string surname, Address personAddress, Contact personContact,string paymentMethod, string status, string clientIdentifier="") :base(personId,name,surname,personAddress,personContact)
        {
            this.PaymentMethod = paymentMethod;
            this.Status = status;
            this.ClientIdentifier = clientIdentifier;
        }

        public Client():base()
        {

        }
        public string ClientIdentifier
        {
            get { return clientIdentifier; }
            set { clientIdentifier = value.Trim(' '); }
        }
        public PaymentDetails PD
        {
            get { return pd; }
            set { pd = value; }
        }


        public string Status
        {
            get { return status; }
            set { status = value.Trim(' '); }
        }


        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value.Trim(' '); }
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
            return base.Equals(obj)&&(this.PaymentMethod==c.PaymentMethod)&&(this.Status==c.Status)&&(this.ClientIdentifier==c.ClientIdentifier);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^this.PaymentMethod.GetHashCode()^this.Status.GetHashCode()^this.ClientIdentifier.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname + " (" + this.PersonId + ")/"+this.ClientIdentifier;
        }

        public bool NewClientWithPaymentDet(string accNr,string bank,string branchCode)
        {
            Datahandler dh = Datahandler.getData();
            PD = new PaymentDetails(this, accNr, bank, branchCode);
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();

            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_payMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_accNr, new string[] { DataAccesHelper.typeString, this.PD.AccNr });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_bank, new string[] { DataAccesHelper.typeString, this.PD.Bank });
            client_details.Add(QueryBuilder.spAddClientWithPaymentDet.sp_branch, new string[] { DataAccesHelper.typeString, this.PD.BranchCode });

            return dh.runStoredProcedure(QueryBuilder.spAddClientWithPaymentDet.sp, client_details);
        }

        public bool NewClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();

            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_payMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            client_details.Add(QueryBuilder.spAddClientWithoutPaymentDetails.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spAddClientWithoutPaymentDetails.sp, client_details);
        }

        public bool UpdateClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();

            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_identifier, new string[] { DataAccesHelper.typeString, this.ClientIdentifier });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_payMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            client_details.Add(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spUpdateClientWithoutPaymentDetails.sp, client_details);
        }

        public bool UpdateClientWithPaymentDetails(string accNr, string bank, string branchCode)
        {
            Datahandler dh = Datahandler.getData();
            PD = new PaymentDetails(this, accNr, bank, branchCode);
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();

            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_identifier, new string[] { DataAccesHelper.typeString, this.ClientIdentifier });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_payMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_accNr, new string[] { DataAccesHelper.typeString, this.PD.AccNr });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_bank, new string[] { DataAccesHelper.typeString, this.PD.Bank });
            client_details.Add(QueryBuilder.spUpdateClientWithPaymentDetails.sp_branch, new string[] { DataAccesHelper.typeString, this.PD.BranchCode });

            return dh.runStoredProcedure(QueryBuilder.spUpdateClientWithPaymentDetails.sp, client_details);

        }

        public bool RemoveClient()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> client_details = new Dictionary<string, string[]>();

            client_details.Add(DataAccesHelper.clientId, new string[] { DataAccesHelper.typeString, this.PersonId });
            client_details.Add(DataAccesHelper.clientName, new string[] { DataAccesHelper.typeString, this.Name });
            client_details.Add(DataAccesHelper.clientSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            client_details.Add(DataAccesHelper.clientPaymentMethod, new string[] { DataAccesHelper.typeString, this.PaymentMethod });
            client_details.Add(DataAccesHelper.clientStatus, new string[] { DataAccesHelper.typeString, this.Status });
            client_details.Add(DataAccesHelper.clientAddrId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            client_details.Add(DataAccesHelper.clientContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });

            return dh.runQuery(DataAccesHelper.targetClient, DataAccesHelper.requestDelete, client_details, DataAccesHelper.clientId + " = '" + this.PersonId + "'");
        }

        public List<Client> GetAllClients(string clientId="")
        {
            Datahandler dh = Datahandler.getData();
            List<Client> clients = new List<Client>();
            DataTable table = new DataTable();
            if (clientId!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetClients+" WHERE "+DataAccesHelper.clientIdentifier+" = '"+clientId+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetClients);
            }

            foreach (DataRow item in table.Rows)
            {
                Client c = new Client();
                c.ClientIdentifier = item[DataAccesHelper.clientIdentifier].ToString();
                c.PersonId = item[DataAccesHelper.clientId].ToString();
                c.Name = item[DataAccesHelper.clientName].ToString();
                c.Surname = item[DataAccesHelper.clientSurname].ToString();
                c.PersonAddress = new Address(item[DataAccesHelper.addressId].ToString(), 
                                  item[DataAccesHelper.addrLine1].ToString(), item[DataAccesHelper.addrLine2].ToString(), 
                                  item[DataAccesHelper.addrCity].ToString(),item[DataAccesHelper.addrPostalCode].ToString());
                c.PersonContact = new Contact(item[DataAccesHelper.contactId].ToString(), item[DataAccesHelper.contactCell].ToString(), 
                                  item[DataAccesHelper.contactEmail].ToString());
                c.Status = item[DataAccesHelper.clientStatus].ToString();
                c.PaymentMethod = item[DataAccesHelper.clientPaymentMethod].ToString();
                clients.Add(c);
            }

            return clients;
        }

    }
}
