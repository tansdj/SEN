using Serverside.HelperLibraries;
using ServerSide;
using ServerSide.HelperLibrabries;
using System;
using System.Collections.Generic;
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
    }
}
