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
DROP TABLE tblVendors;
DROP TABLE tblProductVendors;
DROP TABLE tblContact;
DROP TABLE tblAddress;
DROP TABLE tblProducts;

CREATE TABLE tblAddress
(AddressId VARCHAR(17) PRIMARY KEY,
 AddressLine1 VARCHAR(30) NOT NULL,
 AddressLine2 VARCHAR(30) NOT NULL,
 City VARCHAR(20) NOT NULL
)

CREATE TABLE tblContact
(ContactId VARCHAR(17) PRIMARY KEY,
 Cell VARCHAR(10) NOT NULL,
 Email VARCHAR(50) NOT NULL
 )

CREATE TABLE tblClient
(ClientCount INT IDENTITY,
 IdNr VARCHAR(13) PRIMARY KEY,
 ClientName VARCHAR(50) NOT NULL,
 ClientSurname VARCHAR(50) NOT NULL,
 AddressId VARCHAR(17) FOREIGN KEY REFERENCES tblAddress(AddressId),
 ContactId VARCHAR(17) FOREIGN KEY REFERENCES tblContact(ContactId),
 PaymentMethod VARCHAR(30) NOT NULL,
 ClientStatus VARCHAR(20) NOT NULL
 )

 CREATE TABLE tblBilling
 (BillingId INT IDENTITY PRIMARY KEY,
  ClientIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
  BillDate DATETIME NOT NULL,
  AmountDue SMALLMONEY NOT NULL DEFAULT 0,
  AmountPaid SMALLMONEY NOT NULL DEFAULT 0
  )

  CREATE TABLE tblPaymentDetails
  (PaymentDetId INT IDENTITY PRIMARY KEY,
   ClientIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
   AccNr VARCHAR(20) NOT NULL,
   Bank VARCHAR(15) NOT NULL,
   BranchCode VARCHAR(10) NOT NULL
   )

   CREATE TABLE tblProducts
   (ProductCount INT IDENTITY,
    ProductCode VARCHAR(10) PRIMARY KEY,
	ProdName VARCHAR(20) NOT NULL,
	ProdDescription VARCHAR(200) NOT NULL,
	BasePrice SMALLMONEY NOT NULL DEFAULT 0,
	ProdStatus VARCHAR(15) NOT NULL
	)

   CREATE TABLE tblVendors
   (VendorCode VARCHAR(10) PRIMARY KEY,
    VendorName VARCHAR(30) NOT NULL,
	AddressId VARCHAR(17) FOREIGN KEY REFERENCES tblAddress(AddressId),
	ContactId VARCHAR(17) FOREIGN KEY REFERENCES tblContact(ContactId)
	)

	CREATE TABLE tblProductVendors
	(ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 VendorCode VARCHAR(10) FOREIGN KEY REFERENCES tblVendors(VendorCode)
	)

	CREATE TABLE tblProductFunctions
	(FunctionCount INT IDENTITY,
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 ProdFunction VARCHAR(200) NOT NULL)

	CREATE TABLE tblClientProducts
	(ClientProdCount INT IDENTITY,
	 ClientIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 PRIMARY KEY(ClientIdNr,ProductCode)
	)

	CREATE TABLE tblSystemComponents
	(CompCount INT IDENTITY,
	 ComponentCode VARCHAR(10) PRIMARY KEY,
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 CompDesc VARCHAR(200) NOT NULL
	 )

	CREATE TABLE tblConfiguration
	(ConfigCount INT IDENTITY,
	 ConfigurationCode VARCHAR(10) PRIMARY KEY,
	 ConfigName VARCHAR(20) NOT NULL,
	 ConfigDesc VARCHAR(200) NOT NULL,
	 ComponentCode VARCHAR(10) FOREIGN KEY REFERENCES tblSystemComponents(ComponentCode),
	 AddCost SMALLMONEY NOT NULL DEFAULT 0
	 )

	CREATE TABLE tblClientCompConfiguration
	(ClientConfigCount INT IDENTITY,
	 ClientId VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
	 ConfigCode VARCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 PRIMARY KEY(ClientId,ConfigCode)
	 )

	CREATE TABLE tblTechnicians
	(TechCount INT IDENTITY,
	 TechId VARCHAR(13) PRIMARY KEY,
	 TechName VARCHAR(20) NOT NULL,
	 TechSurname VARCHAR(20) NOT NULL,
	 ContactId VARCHAR(17) FOREIGN KEY REFERENCES tblContact(ContactId),
	 AddressId VARCHAR(17) FOREIGN KEY REFERENCES tblAddress(AddressId),
	 TechStatus VARCHAR(10) NOT NULL
	 )

	CREATE TABLE tblTechnicalLog
	(EventId INt IDENTITY PRIMARY KEY,
	 ClientIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
	 TechIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblTechnicians(TechId),
	 EventDate DATETIME NOT NULL,
	 Remarks VARCHAR(100) NOT NULL
	 )
	 
	CREATE TABLE tblTechnicalDetails
	(DetailId INT IDENTITY PRIMARY KEY,
	 ConfigCode VARCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 DocPath VARCHAR(200) NOT NULL
	 ) 