CREATE DATABASE
();

CREATE TABLE tblClient
(ClientCount INT IDENTITY,
 IdNr VARCHAR(13) PRIMARY KEY,
 ClientName VARCHAR(50) NOT NULL,
 ClientSurname VARCHAR(50) NOT NULL,
 AddressLine1 VARCHAR(30) NOT NULL,
 AddressLine2 VARCHAR(30) NOT NULL,
 City VARCHAR(20) NOT NULL,
 Cell VARCHAR(10) NOT NULL,
 Email VARCHAR(50) NOT NULL,
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
  (DetCount INT IDENTITY,
   PaymentDetId INT IDENTITY PRIMARY KEY,
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
	ProdStatus VARCHAR(15) NOT NULL,
	ProdCategory VARCHAR(30) NOT NULL
	)

	CREATE TABLE tblClientProducts
	(ClientProdCount INT IDENTITY,
	 ClientIdNr VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 PRIMARY KEY(ClientIdNr,ProductCode)
	)

	CREATE TABLE tblConfiguration
	(ConfigCount INT IDENTITY,
	 ConfigurationCode VARCHAR(10) PRIMARY KEY,
	 ConfigName VARCHAR(20) NOT NULL,
	 ConfigDesc VARCHAR(200) NOT NULL,
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 AddCost SMALLMONEY NOT NULL DEFAULT 0
	 )

	CREATE TABLE tblClientProductConfiguration
	(ClientProdConfigCount INT IDENTITY,
	 ClientId VARCHAR(13) FOREIGN KEY REFERENCES tblClient(IdNr),
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 ConfigCode VARCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 PRIMARY KEY(ClientId,ProductCode,ConfigCode)
	 )

	CREATE TABLE tblSystemComponents
	(CompCount INT IDENTITY,
	 ComponentCode VARCHAR(10) PRIMARY KEY,
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 ConfigCode VARCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 CompDesc VARCHAR(200) NOT NULL
	 )

	CREATE TABLE tblTechnicians
	(TechCount INT IDENTITY,
	 TechId VARCHAR(13) PRIMARY KEY,
	 TechName VARCHAR(20) NOT NULL,
	 TechSurname VARCHAR(20) NOT NULL
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
	 ProductCode VARCHAR(10) FOREIGN KEY REFERENCES tblProducts(ProductCode),
	 ConfigCode VARCHAR(10) FOREIGN KEY REFERENCES tblConfiguration(ConfigurationCode),
	 DocPath VARCHAR(200) NOT NULL
	 ) 