using Serverside.HelperLibraries;
using ServerSide;
using ServerSide.HelperLibrabries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class CallOperators:Person
    {
        private string operatorStatus;

        public CallOperators(string personId, string name, string surname, Address personAddress, Contact personContact,string operatorStatus):base(personId,name,surname,personAddress,personContact)
        {
            this.OperatorStatus = operatorStatus;
        }

        public CallOperators()
        {

        }
        public string OperatorStatus
        {
            get { return operatorStatus; }
            set { operatorStatus = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            CallOperators co = (CallOperators)obj;
            if ((object)co==null)
            {
                return false;
            }
            return base.Equals(obj)&&(this.OperatorStatus==co.OperatorStatus);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^this.OperatorStatus.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertCallOperator()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> operator_details = new Dictionary<string, string[]>();

            operator_details.Add(QueryBuilder.spAddCallOperator.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_status, new string[] { DataAccesHelper.typeString, this.OperatorStatus });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spAddCallOperator.sp, operator_details);
        }

        public bool UpdateCallOperator()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> operator_details = new Dictionary<string, string[]>();

            operator_details.Add(QueryBuilder.spAddCallOperator.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_status, new string[] { DataAccesHelper.typeString, this.OperatorStatus });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            operator_details.Add(QueryBuilder.spAddCallOperator.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spAddCallOperator.sp, operator_details);
        }

        public List<CallOperators> GetCallOperators(string operatorId="")
        {
            Datahandler dh = Datahandler.getData();
            List<CallOperators> callOperators = new List<CallOperators>();
            DataTable table = new DataTable();
            if (operatorId!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetCallOperators+" WHERE "+DataAccesHelper.operatorId+" = '"+operatorId+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetCallOperators);
            }

            foreach (DataRow item in table.Rows)
            {
                CallOperators c = new CallOperators();
                c.PersonId = item[DataAccesHelper.operatorId].ToString();
                c.Name = item[DataAccesHelper.operatorName].ToString();
                c.Surname = item[DataAccesHelper.operatorSurname].ToString();
                c.PersonAddress = new Address(item[DataAccesHelper.addressId].ToString(),item[DataAccesHelper.addrLine1].ToString(),item[DataAccesHelper.addrLine2].ToString(),item[DataAccesHelper.addrCity].ToString(),item[DataAccesHelper.addrPostalCode].ToString());
                c.PersonContact = new Contact(item[DataAccesHelper.contactId].ToString(), item[DataAccesHelper.contactCell].ToString(), item[DataAccesHelper.contactEmail].ToString());
                c.OperatorStatus = item[DataAccesHelper.operatorStatus].ToString();
                callOperators.Add(c);
            }

            return callOperators;
        }
    }
}
