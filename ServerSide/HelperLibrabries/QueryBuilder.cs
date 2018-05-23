using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.HelperLibrabries
{
    public struct QueryBuilder
    {
        public struct spAddClientWithoutPaymentDetails
        {
            public const string sp = "addClientWithoutPaymentDet";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_payMethod = "@payMethod";
            public const string sp_status = "@status";
        }

        public struct spAddClientWithPaymentDet
        {
            public const string sp = "addClientWithPaymentDet";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_payMethod = "@payMethod";
            public const string sp_status = "@status";
            public const string sp_accNr = "@accNr";
            public const string sp_bank = "@bank";
            public const string sp_branch = "@branchCode";
        }

        public struct spUpdateClientWithoutPaymentDetails
        {
            public const string sp = "updateClientWithoutPaymentDetails";
            public const string sp_identifier = "@identifier";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_payMethod = "@payMethod";
            public const string sp_status = "@status";
        }

        public struct spUpdateClientWithPaymentDetails
        {
            public const string sp = "updateClientWithPaymentDetails";
            public const string sp_identifier = "@identifier";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_payMethod = "@payMethod";
            public const string sp_status = "@status";
            public const string sp_accNr = "@accNr";
            public const string sp_bank = "@bank";
            public const string sp_branch = "@branchCode";
        }

        public struct spAddTech
        {
            public const string sp = "addTech";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_status = "@status";
        }

        public struct spUpdateTech
        {
            public const string sp = "updateTech";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_status = "@status";
        }

        public struct spAddCallOperator
        {
            public const string sp = "addCallOperator";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_status = "@status";
        }

        public struct spUpdateCallOperator
        {
            public const string sp = "updateCallOperator";
            public const string sp_id = "@id";
            public const string sp_name = "@name";
            public const string sp_surname = "@surname";
            public const string sp_addrLine1 = "@addrLine1";
            public const string sp_addrLine2 = "@addrLine2";
            public const string sp_city = "@city";
            public const string sp_postCode = "@postCode";
            public const string sp_cell = "@cell";
            public const string sp_email = "@email";
            public const string sp_status = "@status";
        }

        public struct spRemoveConf
        {
            public const string sp = "removeConf";
            public const string sp_confCode = "@confCode";
        }

        public struct spRemoveComponent
        {
            public const string sp = "removeComp";
            public const string sp_compCode = "@compCode";
        }
    }
}
