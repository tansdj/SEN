using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverside.HelperLibraries
{
    public static class DataAccesHelper
    {
        public const string requestInsert = "INSERT";
        public const string requestUpdate = "UPDATE";
        public const string requestDelete = "DELETE";

        public const string targetAddress = "tblAddress";
        public const string addressId = "pAddressId";
        public const string addrLine1 = "AddressLine1";
        public const string addrLine2 = "AddressLine2";
        public const string addrCity = "City";
        public const string addrPostalCode = "PostalCode";

        public const string targetContact = "tblContact";
        public const string contactId = "pContactId";
        public const string contactCell = "Cell";
        public const string contactEmail = "Email";

        public const string targetClient = "tblClient";
        public const string clientId = "IdNr";
        public const string clientName = "ClientName";
        public const string clientSurname = "ClientSurname";
        public const string clientAddrId = "AddressId";
        public const string clientContactId = "ContactId";
        public const string clientPaymentMethod = "PaymentMethod";
        public const string clientStatus = "ClientStatus";
   
        public const string targetBilling = "tblBilling";
        public const string billingClientid = "ClientIdNr";
        public const string billingDate = "BillDate";
        public const string billAmountDue = "AmountDue";
        public const string billAmountPaid = "AmountPaid";

        public const string targetPaymentDetails = "tblPaymentDetails";
        public const string paymentDetClientId = "ClientIdNr";
        public const string paymentDetAccNr = "AccNr";
        public const string paymentDetBank = "Bank";
        public const string paymentDetBranch = "BranchCode";

        public const string targetProduct = "tblProducts";
        public const string prodCode = "ProductCode";
        public const string prodName = "ProdName";
        public const string prodDesc = "ProdDescription";
        public const string prodPrice = "BasePrice";
        public const string prodStatus = "ProdStatus";

        public const string targetVendor = "tblVendors";
        public const string vendCode = "VendorCode";
        public const string vendName = "VendorName";
        public const string vendAddressId = "AddressId";
        public const string vendContactId = "ContactId";

        public const string targetProductFunction = "tblProductFunctions";
        public const string pfProductCode = "ProductCode";
        public const string pfFunction = "ProdFunction";

        public const string targetComponents = "tblSystemComponents";
        public const string compCode = "ComponentCode";
        public const string compProdCode = "ProductCode";
        public const string compDesc = "CompDesc";

        public const string targetConfiguration = "tblConfiguration";
        public const string confCode = "ConfigurationCode";
        public const string confName = "ConfigName";
        public const string confDesc = "ConfigDesc";
        public const string confCompCode = "ComponentCode";
        public const string confAddCost = "AddCost";

        public const string targetTechnicians = "tblTechnicians";
        public const string techId = "TechId";
        public const string techName = "TechName";
        public const string techSurname = "TechSurname";
        public const string techContactId = "ContactId";
        public const string techAddressId = "AddressId";
        public const string techStatus = "TechStatus";
        public const string techSkill = "SkillLevel";

        public const string targetTechDetail = "tblTechnicalDetails";
        public const string tecDetId = "DetailId";
        public const string tecDetConfCode = "ConfigCode";
        public const string tecDetDocPath = "DocPath";

        public const string targetTechEvents = "tblTechnicalLog";
        public const string eventId = "EventId";
        public const string eventClientId = "ClientIdNr";
        public const string eventTechId = "TechIdNr";
        public const string eventDate = "EventDate";
        public const string eventRemarks = "Remarks";
        public const string eventStatus = "Event_Status";
        public const string skillReq = "SkillRequired";

        public const string targetClientProducts = "tblClientProducts";
        public const string cpClientId = "ClientIdNr";
        public const string cpProductId = "ProductCode";

        public const string targetClientConf = "tblClientCompConfiguration";
        public const string ccClientId = "ClientId";
        public const string ccConfId = "ConfigCode";

        public const string targetCompVendors = "tblComponentVendors";
        public const string cvCompCode = "ComponentCode";
        public const string cvVendorCode = "VendorCode";

        public const string targetUsers = "tblUsers";
        public const string uUsername = "Username";
        public const string uPassword = "UserPassword";
        public const string uName = "UserFirstName";
        public const string uSurname = "UserSurname";
        public const string uEmail = "UserEmail";

        public const string QueryGetClients= @"SELECT * FROM tblClient C
                                              INNER JOIN tblAddress A ON C.AddressId = A.pAddressId
                                              INNER JOIN tblContact CT ON C.ContactId = CT.pContactId";
        public const string QueryGetBilling = "";
        public const string QueryGetClientConfiguration = "";
        public const string QueryGetClientProducts = "";
        public const string QueryGetComponentVendors = "";
        public const string QueryGetConfigurations = "";
        public const string QueryGetPaymentDetails = "SELECT * FROM tblPaymentDetails";
        public const string QueryTestForPaymentDet = "SELECT * FROM tblPaymentDetails WHERE ClientIdNr = ";
        public const string QueryGetProducts = "";
        public const string QueryGetProductFunction = "";
        public const string QueryGetSystemComponents = "";
        public const string QueryGetTechnicalDetails = "";
        public const string QueryGetTechnicalLog = "";
        public const string QueryGetTechnicians = "";
        public const string QueryGetUsers = "";
        public const string QueryGetVendors = "";

        public const string typeString = "STRING";
        public const string typeDouble = "DOUBLE";
        public const string typeInt = "INT";
        public const string typeDateTime = "DATETIME";
        public const string typeBool = "BOOL";
    }
}
