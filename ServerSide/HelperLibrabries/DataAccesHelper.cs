using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverside.HelperLibraries
{
    public struct DataAccesHelper
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
        public const string clientIdentifier = "ClientIdentifier";
        public const string clientId = "IdNr";
        public const string clientName = "ClientName";
        public const string clientSurname = "ClientSurname";
        public const string clientAddrId = "AddressId";
        public const string clientContactId = "ContactId";
        public const string clientPaymentMethod = "PaymentMethod";
        public const string clientStatus = "ClientStatus";

        public const string targetContract = "tblContract";
        public const string contractId = "ContractIdentifier";
        public const string contractClient = "ClientId";
        public const string contractServiceLevel = "ServiceLevel";
        public const string contractIssueDate = "DateOfIssue";
        public const string contractTermDur = "TermDuration";


        public const string targetBilling = "tblBilling";
        public const string billingClientid = "ClientId";
        public const string billingDate = "BillDate";
        public const string billAmountDue = "AmountDue";
        public const string billAmountPaid = "AmountPaid";

        public const string targetPaymentDetails = "tblPaymentDetails";
        public const string paymentDetClientId = "ClientId";
        public const string paymentDetAccNr = "AccNr";
        public const string paymentDetBank = "Bank";
        public const string paymentDetBranch = "BranchCode";

        public const string targetProduct = "tblProducts";
        public const string prodSerialNo = "ProductSerialNr";
        public const string prodName = "ProdName";
        public const string prodDesc = "ProdDescription";
        public const string prodPrice = "BasePrice";
        public const string prodStatus = "ProdStatus";
        public const string prodManufacturer = "Manufacturer";
        public const string prodModel = "Model";

        public const string targetVendor = "tblVendors";
        public const string vendCode = "VendorCode";
        public const string vendName = "VendorName";
        public const string vendAddressId = "AddressId";
        public const string vendContactId = "ContactId";

        public const string targetProductFunction = "tblProductFunctions";
        public const string pfProductSerial = "ProductSerial";
        public const string pfFunction = "ProdFunction";

        public const string targetComponents = "tblSystemComponents";
        public const string compCode = "ComponentCode";
        public const string compProdSerial = "ProductSerial";
        public const string compDesc = "CompDesc";
        public const string compStatus = "CompStatus";

        public const string targetConfiguration = "tblConfiguration";
        public const string confCode = "ConfigurationCode";
        public const string confName = "ConfigName";
        public const string confDesc = "ConfigDesc";
        public const string confCompCode = "ComponentCode";
        public const string confAddCost = "AddCost";
        public const string confStatus = "ConfStatus";

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

        public const string targetRequestedEvents = "tblRequestedEvents";
        public const string eventId = "EventId";
        public const string eventClientId = "ClientId";
        public const string eventReqDate = "RequestDate";
        public const string eventCompDate = "DateCompleted";
        public const string eventRemarks = "Remarks";
        public const string eventStatus = "Event_Status";
        public const string skillReq = "SkillRequired";

        public const string targetCallOperators = "tblCallOperators";
        public const string operatorId = "pOperatorId";
        public const string operatorName = "OperatorName";
        public const string operatorSurname = "OperatorSurname";
        public const string operatorContactId = "ContactId";
        public const string operatorAddressId = "AddressId";
        public const string operatorStatus = "OperatorStatus";

        public const string targetCallLog = "tblCallLog";
        public const string callOperatorId = "OperatorId";
        public const string callClientId = "ClientId";
        public const string callStartTime = "StartTime";
        public const string callEndTime = "EndTime";
        public const string callRemarks = "Remarks";

        public const string targetTechEvents = "tblTechnicalLog";
        public const string tlEventId = "EventId";
        public const string tlEventTechId = "TechIdNr";

        public const string targetContractProducts = "tblContractProducts";
        public const string cpContractId = "ContractId";
        public const string cpProductSerial = "ProductSerial";

        public const string targetContractConf = "tblContractCompConfiguration";
        public const string ccContractId = "ContractId";
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

        public const string QueryGetClients= "SELECT * FROM tblClient C INNER JOIN tblAddress A ON C.AddressId = A.pAddressId INNER JOIN tblContact CT ON C.ContactId = CT.pContactId";
        public const string QueryGetBilling = "SELECT * FROM tblBilling WHERE ClientIdNr = ";
        public const string QueryGetClientConfiguration = "SELECT * FROM tblClientCompConfiguration WHERE ClientId = ";
        public const string QueryGetContractProducts = "SELECT * FROM tblContractProducts WHERE ContractId = ";
        public const string QueryGetComponentVendors = "SELECT * FROM tblComponentVendors WHERE ComponentCode = ";
        public const string QueryGetConfigurations = "SELECT * FROM tblConfiguration WHERE ComponentCode = ";
        public const string QueryGetPaymentDetails = "SELECT * FROM tblPaymentDetails";
        public const string QueryTestForPaymentDet = "SELECT * FROM tblPaymentDetails WHERE ClientIdNr = ";
        public const string QueryGetProducts = "SELECT * FROM tblProducts";
        public const string QueryGetProductFunction = "SELECT * FROM tblProductFunctions WHERE ProductCode = ";
        public const string QueryGetSystemComponents = "SELECT * FROM tblSystemComponents WHERE ProductCode = ";
        public const string QueryGetTechnicalDetails = "SELECT * FROM tblTechnicalDetails WHERE ConfigCode = ";
        public const string QueryGetRequestedEvents = "SELECT * FROM tblRequestedEvents";
        public const string QueryGetTechnicians = @"SELECT * FROM tblTechnicians T
                                                    INNER JOIN tblAddress A ON T.AddressId = A.pAddressId
                                                    INNER JOIN tblContact C ON T.ContactId = C.pContactId";
        public const string QueryGetUsers = "SELECT * FROM tblUsers";
        public const string QueryGetVendors = @"SELECT * FROM tblVendors V
                                                INNER JOIN tblAddress A ON V.AddressId = A.pAddressId
                                                INNER JOIN tblContact C ON V.ContactId = C.pContactId";
        public const string QueryCountContracts = "SELECT COUNT(ContractIdentifier) AS 'NrContracts' FROM tblContract";
        public const string QueryGetAllCalls = "SELECT * FROM tblCallLog";
        public const string QueryGetCallOperators = @"SELECT * FROM tblCallOperators c
                                                    INNER JOIN tblAddress a ON a.pAddressId = c.AddressId
                                                    INNER JOIN tblContact ct ON ct.pContactId = c.ContactId";
        public const string QueryGetTechEvents = "SELECT * FROM tblTechnicalLog";
        public const string typeString = "STRING";
        public const string typeDouble = "DOUBLE";
        public const string typeInt = "INT";
        public const string typeDateTime = "DATETIME";
        public const string typeBool = "BOOL";
    }
}
