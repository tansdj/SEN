GO
CREATE PROCEDURE addClientWithoutPaymentDet
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = 'ADDR'+@id;
	 SET @contactId = 'CONT' + @id;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(AddressId,AddressLine1,AddressLine2,City)
				VALUES (@addrId,@addrLine1,@addrLine2);

				INSERT INTO tblContact(ContactId,Cell,Email)
				VALUES (@contactId,@cell,@email);

				INSERT INTO tblClient(IdNr,ClientName,ClientSurname,AddressId,ContactId,PaymentMethod,ClientStatus)
				VALUES (@id,@name,@surname,@addrId,@contactId,@payMethod,@status);
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE addClientWithPaymentDet
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20),@accNr VARCHAR(20),@bank VARCHAR(15),@branchCode VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = 'ADDR'+@id;
	 SET @contactId = 'CONT' + @id;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(AddressId,AddressLine1,AddressLine2,City)
				VALUES (@addrId,@addrLine1,@addrLine2);

				INSERT INTO tblContact(ContactId,Cell,Email)
				VALUES (@contactId,@cell,@email);

				INSERT INTO tblClient(IdNr,ClientName,ClientSurname,AddressId,ContactId,PaymentMethod,ClientStatus)
				VALUES (@id,@name,@surname,@addrId,@contactId,@payMethod,@status);

				INSERT INTO tblPaymentDetails(ClientIdNr,AccNr,Bank,BranchCode)
				VALUES (@id,@accNr,@bank,@branchCode);
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE updateClientWithoutPaymentDetails
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = (SELECT tblAddress.AddressId FROM tblAddress INNER JOIN tblClient ON tblClient.AddressId = tblAddress.AddressId WHERE tblClient.IdNr=@id);
	 SET @contactId = (SELECT tblContact.ContactId FROM tblContact INNER JOIN tblClient ON tblClient.ContactId = tblContact.ContactId WHERE tblClient.IdNr = @id);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city
				WHERE AddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE ContactId = @contactId;

				UPDATE tblClient SET ClientName=@name,ClientSurname=@surname, PaymentMethod = @payMethod,ClientStatus=@status
				WHERE IdNr = @id;
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END;

GO
CREATE PROCEDURE updateClientWithPaymentDetails
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@payMethod VARCHAR(30),@status VARCHAR(20),@accNr VARCHAR(20),@bank VARCHAR(15),@branchCode VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	  SET @addrId = (SELECT tblAddress.AddressId FROM tblAddress INNER JOIN tblClient ON tblClient.AddressId = tblAddress.AddressId WHERE tblClient.IdNr=@id);
	 SET @contactId = (SELECT tblContact.ContactId FROM tblContact INNER JOIN tblClient ON tblClient.ContactId = tblContact.ContactId WHERE tblClient.IdNr = @id);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city
				WHERE AddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE ContactId = @contactId;

				UPDATE tblClient SET ClientName=@name,ClientSurname=@surname, PaymentMethod = @payMethod,ClientStatus=@status
				WHERE IdNr = @id;

				UPDATE tblPaymentDetails SET AccNr=@accNr,Bank=@bank,BranchCode=@branchCode
				WHERE ClientIdNr = @id;
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
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@status VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = 'ADDR'+@id;
	 SET @contactId = 'CONT' + @id;
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO tblAddress(AddressId,AddressLine1,AddressLine2,City)
				VALUES (@addrId,@addrLine1,@addrLine2);

				INSERT INTO tblContact(ContactId,Cell,Email)
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
(@id VARCHAR(13),@name VARCHAR(13),@surname VARCHAR(13),@addrLine1 VARCHAR(30),@addrLine2 VARCHAR(30),@city VARCHAR(20),@cell VARCHAR(10),@email VARCHAR(50),@status VARCHAR(10))
AS
	BEGIN
	 DECLARE @addrId VARCHAR(17),@contactId VARCHAR(17);
	 SET @addrId = (SELECT tblAddress.AddressId FROM tblAddress INNER JOIN tblTechnicians ON tblTechnicians.AddressId = tblAddress.AddressId WHERE tblTechnicians.TechId=@id);
	 SET @contactId = (SELECT tblContact.ContactId FROM tblContact INNER JOIN tblTechnicians ON tblTechnicians.ContactId = tblContact.ContactId WHERE tblTechnicians.TechId = @id);
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE tblAddress SET AddressLine1 = @addrLine1,AddressLine2=@addrLine2,City=@city
				WHERE AddressId = @addrId;

				UPDATE tblContact SET Cell=@cell,Email=@email WHERE ContactId = @contactId;

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