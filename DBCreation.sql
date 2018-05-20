CREATE DATABASE SHSDb
ON
(NAME = shsdata1,
 FILENAME = 'C:\Users\Tanya\Documents\BC\BC 3rd Year\SEN321\SHSApplication\shsdata1.mdf',
 SIZE = 200MB,
 MAXSIZE = UNLIMITED,
 FILEGROWTH = 10%)
 LOG ON
 (NAME = shslog1,
  FILENAME = 'C:\Users\Tanya\Documents\BC\BC 3rd Year\SEN321\SHSApplication\shslog1.ldf');

DROP TABLE tblPaymentDetails;
DROP TABLE tblBilling;
DROP TABLE tblTechnicalDetails
DROP TABLE tblTechnicalLog;
DROP TABLE tblTechnicians;
DROP TABLE tblClientProducts;
DROP TABLE tblClientCompConfiguration;
DROP TABLE tblConfiguration;
DROP TABLE tblSystemComponents;
DROP TABLE tblClient;
DROP TABLE tblProductFunctions;
DROP TABLE tblComponentVendors;
DROP TABLE tblVendors;
DROP TABLE tblContact;
DROP TABLE tblAddress;
DROP TABLE tblProducts;

CREATE TABLE tblAddress
(pAddressId nCHAR(13) PRIMARY KEY,
 AddressLine1 VARCHAR(30) NOT NULL,
 AddressLine2 VARCHAR(30) NOT NULL,
 City VARCHAR(20) NOT NULL,
 PostalCode VARCHAR(10) NOT NULL
)

CREATE TABLE tblContact
(pContactId nCHAR(13) PRIMARY KEY,
 Cell VARCHAR(10) NOT NULL,
 Email VARCHAR(50) NOT NULL
 )

CREATE TABLE tblClient
(ClientCount INT IDENTITY,
 ClientIdentifier nCHAR(9) PRIMARY KEY,
 IdNr nCHAR(13) NOT NULL,
 ClientName VARCHAR(50) NOT NULL,
 ClientSurname VARCHAR(50) NOT NULL,
 AddressId nCHAR(13) FOREIGN KEY REFERENCES tblAddress(pAddressId),
 ContactId nCHAR(13) FOREIGN KEY REFERENCES tblContact(pContactId),
 PaymentMethod VARCHAR(30) NOT NULL,
 ClientStatus VARCHAR(20) NOT NULL
 )

 CREATE TABLE tblContract
 (ContractIdentifier nCHAR(12) PRIMARY KEY,
  ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
  ServiceLevel VARCHAR(20) NOT NULL,
  DateOfIssue DATETIME NOT NULL,
  TermDuration INT NOT NULL
 )

 CREATE TABLE tblBilling
 (BillingId INT IDENTITY PRIMARY KEY,
  ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
  BillDate DATETIME NOT NULL,
  AmountDue SMALLMONEY NOT NULL DEFAULT 0,
  AmountPaid SMALLMONEY NOT NULL DEFAULT 0
  )

  CREATE TABLE tblPaymentDetails
  (PaymentDetId INT IDENTITY PRIMARY KEY,
   ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
   AccNr VARCHAR(20) NOT NULL,
   Bank VARCHAR(15) NOT NULL,
   BranchCode VARCHAR(10) NOT NULL
   )

   CREATE TABLE tblProducts
   (ProductCount INT IDENTITY,
    ProductSerialNr VARCHAR(100) PRIMARY KEY,
	ProdName VARCHAR(20) NOT NULL,
	ProdDescription VARCHAR(200) NOT NULL,
	BasePrice SMALLMONEY NOT NULL DEFAULT 0,
	ProdStatus VARCHAR(15) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(20) NOT NULL
	)

   CREATE TABLE tblVendors
   (VendorCode nCHAR(10) PRIMARY KEY,
    VendorName VARCHAR(30) NOT NULL,
	AddressId nCHAR(13) FOREIGN KEY REFERENCES tblAddress(pAddressId),
	ContactId nCHAR(13) FOREIGN KEY REFERENCES tblContact(pContactId)
	)

	CREATE TABLE tblProductFunctions
	(FunctionCount INT IDENTITY,
	 ProductSerial VARCHAR(100) FOREIGN KEY REFERENCES tblProducts(ProductSerialNr),
	 ProdFunction VARCHAR(200) NOT NULL)

	CREATE TABLE tblContractProducts
	(ContractProdCount INT IDENTITY,
	 ContractId nCHAR(12) FOREIGN KEY REFERENCES tblContract(ContractIdentifier),
	 ProductSerial VARCHAR(100) FOREIGN KEY REFERENCES tblProducts(ProductSerialNr),
	 PRIMARY KEY(ContractId,ProductSerial)
	)

	CREATE TABLE tblSystemComponents
	(CompCount INT IDENTITY,
	 ComponentCode nCHAR(10) PRIMARY KEY,
	 ProductSerial VARCHAR(100) FOREIGN KEY REFERENCES tblProducts(ProductSerialNr),
	 CompDesc VARCHAR(200) NOT NULL
	 )
	 CREATE TABLE tblComponentVendors
	(CompVendorCount INT IDENTITY,
	 ComponentCode nCHAR(10) FOREIGN KEY REFERENCES tblSystemComponents(ComponentCode),
	 VendorCode nCHAR(10) FOREIGN KEY REFERENCES tblVendors(VendorCode)
	 PRIMARY KEY(ComponentCode,VendorCode)
	)

	CREATE TABLE tblConfiguration
	(ConfigCount INT IDENTITY,
	 ConfigurationCode nCHAR(10) PRIMARY KEY,
	 ConfigName VARCHAR(20) NOT NULL,
	 ConfigDesc VARCHAR(200) NOT NULL,
	 ComponentCode nCHAR(10) FOREIGN KEY REFERENCES tblSystemComponents(ComponentCode),
	 AddCost SMALLMONEY NOT NULL DEFAULT 0
	 )

	CREATE TABLE tblClientCompConfiguration
	(ClientConfigCount INT IDENTITY,
	 ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
	 ConfigCode nCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 PRIMARY KEY(ClientId,ConfigCode)
	 )

	CREATE TABLE tblTechnicians
	(TechCount INT IDENTITY,
	 TechId nCHAR(13) PRIMARY KEY,
	 TechName VARCHAR(20) NOT NULL,
	 TechSurname VARCHAR(20) NOT NULL,
	 ContactId nCHAR(13) FOREIGN KEY REFERENCES tblContact(pContactId),
	 AddressId nCHAR(13) FOREIGN KEY REFERENCES tblAddress(pAddressId),
	 TechStatus VARCHAR(10) NOT NULL,
	 SkillLevel VARCHAR(20) NOT NULL
	 )

	CREATE TABLE tblCallOperators
	(OperatorCount INT IDENTITY,
	 OperatorId nCHAR(13) PRIMARY KEY,
	 OperatorName VARCHAR(20) NOT NULL,
	 OperatorSurname VARCHAR(20) NOT NULL,
	 ContactId nCHAR(13) FOREIGN KEY REFERENCES tblContact(pContactId),
	 AddressId nCHAR(13) FOREIGN KEY REFERENCES tblAddress(pAddressId),
	 OperatorStatus VARCHAR(10) NOT NULL,
	)

	CREATE TABLE tblCallLog
	(CallId INT IDENTITY PRIMARY KEY,
	 OperatorId nCHAR(13) FOREIGN KEY REFERENCES tblCallOperators(OperatorId),
	 ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
	 StartTime DATETIME,
	 EndTime DATETIME,
	 Remarks VARCHAR(100)
	)

	CREATE TABLE tblRequestedEvents
	(EventId INt IDENTITY PRIMARY KEY,
	 ClientId nCHAR(9) FOREIGN KEY REFERENCES tblClient(ClientIdentifier),
	 RequestDate DATETIME,
	 DateCompleted DATETIME,
	 Remarks VARCHAR(100),
	 Event_Status VARCHAR(20) NOT NULL,
	 SkillRequired VARCHAR(20) NOT NULL
	) 

	CREATE TABLE tblTechnicalLog
	(EventId INT FOREIGN KEY REFERENCES tblRequestedEvents(EventId),
	 TechIdNr nCHAR(13) FOREIGN KEY REFERENCES tblTechnicians(TechId),
	 PRIMARY KEY(EventId,TechIdNr)
	 )
	 
	CREATE TABLE tblTechnicalDetails
	(DetailId INT IDENTITY PRIMARY KEY,
	 ConfigCode nCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 DocPath VARCHAR(200) NOT NULL
	 ) 

	 CREATE TABLE tblUsers
	 (UserCount INT IDENTITY,
	  Username VARCHAR(50) NOT NULL,
	  UserPassword VARCHAR(50) NOT NULL,
	  UserFirstName VARCHAR(30) NOT NULL,
	  UserSurname VARCHAR(50) NOT NULL,
	  UserEmail VARCHAR(100) PRIMARY KEY
	 )