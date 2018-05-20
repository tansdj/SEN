GO
CREATE PROCEDURE addClientWithoutPaymentDet
(@id nCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20))
AS
	BEGIN
	 DECLARE @identifier nCHAR(9),@addrId nCHAR(13),@contactId nCHAR(13);
	 DECLARE @num INT,@char nCHAR(1);
	 SET @num = FLOOR(RAND()*(5-1+1)+1);
	 SET @char =  CASE 
				WHEN @num = 1 THEN 'A'
				WHEN @num = 2 THEN 'B'
				WHEN @num = 3 THEN 'C'
				WHEN @num = 4 THEN 'D'
				WHEN @num = 5 THEN 'E'
			END
	 SET @identifier = @char + REPLICATE('0',8 - ((SELECT COUNT(IdNr) FROM tblClient)+1));
	 SET @addrId = 'ADDR'+@identifier;
	 SET @contactId = 'CONT' + @identifier;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(pAddressId,AddressLine1,AddressLine2,City,PostalCode)
				VALUES (@addrId,@addrLine1,@addrLine2,@city,@postCode);

				INSERT INTO tblContact(pContactId,Cell,Email)
				VALUES (@contactId,@cell,@email);

				INSERT INTO tblClient(ClientIdentifier,IdNr,ClientName,ClientSurname,AddressId,ContactId,PaymentMethod,ClientStatus)
				VALUES (@identifier,@id,@name,@surname,@addrId,@contactId,@payMethod,@status);
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE addClientWithPaymentDet
(@id nCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20),@accNr VARCHAR(20),@bank VARCHAR(15),@branchCode VARCHAR(10))
AS
	BEGIN
	 DECLARE @identifier nCHAR(9),@addrId nCHAR(13),@contactId nCHAR(13);
	 DECLARE @num INT,@char nCHAR(1);
	 SET @num = FLOOR(RAND()*(5-1+1)+1);
	 SET @char =  CASE 
				WHEN @num = 1 THEN 'A'
				WHEN @num = 2 THEN 'B'
				WHEN @num = 3 THEN 'C'
				WHEN @num = 4 THEN 'D'
				WHEN @num = 5 THEN 'E'
			END
	 SET @identifier = @char + REPLICATE('0',8 - ((SELECT COUNT(IdNr) FROM tblClient)+1));
	 SET @addrId = 'ADDR'+@identifier;
	 SET @contactId = 'CONT' + @identifier;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(pAddressId,AddressLine1,AddressLine2,City,PostalCode)
				VALUES (@addrId,@addrLine1,@addrLine2,@city,@postCode);

				INSERT INTO tblContact(pContactId,Cell,Email)
				VALUES (@contactId,@cell,@email);

				INSERT INTO tblClient(ClientIdentifier,IdNr,ClientName,ClientSurname,AddressId,ContactId,PaymentMethod,ClientStatus)
				VALUES (@identifier,@id,@name,@surname,@addrId,@contactId,@payMethod,@status);

				INSERT INTO tblPaymentDetails(ClientId,AccNr,Bank,BranchCode)
				VALUES (@identifier,@accNr,@bank,@branchCode);
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE updateClientWithoutPaymentDetails
(@identifier nCHAR(9),@id nCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20))
AS
	BEGIN
	 DECLARE @addrId nCHAR(13),@contactId nCHAR(13);
	 SET @addrId = (SELECT tblAddress.pAddressId FROM tblAddress INNER JOIN tblClient ON tblClient.AddressId = tblAddress.pAddressId WHERE tblClient.ClientIdentifier=@identifier);
	 SET @contactId = (SELECT tblContact.pContactId FROM tblContact INNER JOIN tblClient ON tblClient.ContactId = tblContact.pContactId WHERE tblClient.ClientIdentifier = @identifier);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city, PostalCode = @postCode
				WHERE pAddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE pContactId = @contactId;

				UPDATE tblClient SET ClientName=@name,ClientSurname=@surname, PaymentMethod = @payMethod,ClientStatus=@status
				WHERE ClientIdentifier = @identifier;

				IF (SELECT COUNT(ClientId) FROM tblPaymentDetails WHERE ClientId = @identifier)>0
				BEGIN
					DELETE FROM tblPaymentDetails WHERE ClientId = @identifier
				END
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE updateClientWithPaymentDetails
(@identifier nCHAR(9),@id nCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20),@accNr VARCHAR(20),@bank VARCHAR(15),@branchCode VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = (SELECT tblAddress.pAddressId FROM tblAddress INNER JOIN tblClient ON tblClient.AddressId = tblAddress.pAddressId WHERE tblClient.IdNr=@id);
	 SET @contactId = (SELECT tblContact.pContactId FROM tblContact INNER JOIN tblClient ON tblClient.ContactId = tblContact.pContactId WHERE tblClient.IdNr = @id);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city,PostalCode = @postCode
				WHERE pAddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE pContactId = @contactId;

				UPDATE tblClient SET ClientName=@name,ClientSurname=@surname, PaymentMethod = @payMethod,ClientStatus=@status
				WHERE IdNr = @id;

				IF (SELECT ClientId FROM tblPaymentDetails WHERE ClientId = @identifier) IS NULL
				 INSERT INTO tblPaymentDetails(ClientId,AccNr,Bank,BranchCode)
				 VALUES (@identifier,@accNr,@bank,@branchCode);
				ELSE
				 UPDATE tblPaymentDetails SET AccNr=@accNr,Bank=@bank,BranchCode=@branchCode
				 WHERE ClientId = @identifier;
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE addProduct
(@name VARCHAR(20),@desc VARCHAR(200),@basePrice SMALLMONEY,@status VARCHAR(15))
AS
	BEGIN
		DECLARE @productCode VARCHAR(10);
		SET @productCode = 'PROD'+ UPPER(LEFT(@name,3)) + (SELECT COUNT(ProductCount) FROM tblProducts);
		INSERT INTO tblProducts(ProductCode,ProdName,ProdDescription,BasePrice,ProdStatus)
		VALUES(@productCode,@name,@desc,@basePrice,@status); 
	END;

GO
CREATE PROCEDURE updateProduct
(@prodCode VARCHAR(10),@desc VARCHAR(200),@basePrice SMALLMONEY,@status VARCHAR(15))
AS
	BEGIN
		UPDATE tblProducts SET ProdDescription = @desc,BasePrice =@basePrice,ProdStatus = @status
		WHERE ProductCode = @prodCode;
	END;

GO
CREATE PROCEDURE addComponent
(@prodCode VARCHAR(10),@desc VARCHAR(200))
AS
	BEGIN
		DECLARE @compCode VARCHAR(10);
		SET @compCode = 'COMP'+ SUBSTRING(@prodCode,4,3) + (SELECT COUNT(CompCount) FROM tblSystemComponents);

		INSERT INTO tblSystemComponents(ComponentCode,ProductCode,CompDesc)
		VALUES (@compCode,@prodCode,@desc);
	END;

GO
CREATE PROCEDURE removeComp
(@compCode VARCHAR(10))
AS
	BEGIN
		DECLARE @config VARCHAR(10);
		SET @config = (SELECT ConfigurationCode FROM tblConfiguration WHERE ComponentCode = @compCode);
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE FROM tblClientCompConfiguration WHERE ConfigCode = @config;
				DELETE FROM tblConfiguration WHERE ConfigurationCode = @config;
				DELETE FROM tblSystemComponents WHERE ComponentCode = @compCode;
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE addConfiguration
(@name VARCHAR(20),@desc VARCHAR(200),@compCode VARCHAR(10),@cost SMALLMONEY)
AS
	BEGIN
		DECLARE @confCode VARCHAR(10);
		SET @confCode = 'CONF'+UPPER(LEFT(@name,3))+ (SELECT COUNT(ConfigCount) FROM tblConfiguration);

		INSERT INTO tblConfiguration(ConfigurationCode,ConfigName,ConfigDesc,ComponentCode,AddCost)
		VALUES (@confCode,@name,@desc,@compCode,@cost);
	END

GO
CREATE PROCEDURE updateConf
(@confCode VARCHAR(10),@desc VARCHAR(200),@cost SMALLMONEY)
AS
	BEGIN
		UPDATE tblConfiguration SET ConfigDesc=@desc,AddCost = @cost
		WHERE ConfigurationCode=@confCode;
	END;

GO
CREATE PROCEDURE removeConf
(@confCode VARCHAR(10))
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE FROM tblClientCompConfiguration WHERE ConfigCode = @confCode;
				DELETE FROM tblConfiguration WHERE ConfigurationCode = @confCode;
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END

GO 
CREATE PROCEDURE addTech
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@status VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = 'ADDR'+@id;
	 SET @contactId = 'CONT' + @id;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(pAddressId,AddressLine1,AddressLine2,City,PostalCode)
				VALUES (@addrId,@addrLine1,@addrLine2,@city,@postCode);

				INSERT INTO tblContact(pContactId,Cell,Email)
				VALUES (@contactId,@cell,@email);

				INSERT INTO tblTechnicians(TechId,TechName,TechSurname,AddressId,ContactId,TechStatus)
				VALUES (@id,@name,@surname,@addrId,@contactId,@status);
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE updateTech
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@postCode VARCHAR(10),@cell VARCHAR(10),@email VARCHAR(50),@status VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = (SELECT tblAddress.pAddressId FROM tblAddress INNER JOIN tblTechnicians ON tblTechnicians.AddressId = tblAddress.pAddressId WHERE tblTechnicians.TechId=@id);
	 SET @contactId = (SELECT tblContact.pContactId FROM tblContact INNER JOIN tblTechnicians ON tblTechnicians.ContactId = tblContact.pContactId WHERE tblTechnicians.TechId = @id);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city, PostalCode = @postCode
				WHERE pAddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE pContactId = @contactId;

				UPDATE tblTechnicians SET TechName=@name,TechSurname=@surname,TechStatus=@status
				WHERE TechId = @id;
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE addTechDetail
(@confCode VARCHAR(10),@docPath VARCHAR(200))
AS
	BEGIN
		INSERT INTO tblTechnicalDetails(ConfigCode,DocPath)
		VALUES (@confCode,@docPath);
	END;

GO
CREATE PROCEDURE removeTechDetail
(@detailId INT)
AS
	BEGIN
		DELETE FROM tblTechnicalDetails WHERE DetailId = @detailId;
	END;

GO
CREATE PROCEDURE logTechEvent
(@clientId VARCHAR(13),@techId VARCHAR(13),@date DATETIME,@remarks VARCHAR(200))
AS
	BEGIN
		INSERT INTO tblTechnicalLog(ClientIdNr,TechIdNr,EventDate,Remarks)
		VALUES (@clientId,@techId,@date,@remarks);
	END;

GO
CREATE PROCEDURE addClientProduct
(@clientId VARCHAR(13),@prodCode VARCHAR(10))
AS
	BEGIN
		INSERT INTO tblClientProducts(ClientIdNr,ProductCode)
		VALUES (@clientId,@prodCode);
	END;