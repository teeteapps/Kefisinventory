CREATE PROCEDURE [dbo].[Usp_Makeadispatch]
	@id BIGINT,
	@productid BIGINT,
	@quantity INT
AS
BEGIN
   BEGIN
	DECLARE 
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		BEGIN TRANSACTION;
		UPDATE Companypurchase SET Orderstatus='Processed' WHERE Orderid=@id
		UPDATE Products SET Quantity= @quantity WHERE Productid=@productid
		Set @RespMsg ='Product Updated.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage;
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION
		PRINT ''
		PRINT 'Error ' + error_message();
		Select 2 as RespStatus, '0 - Error(s) Occurred' + error_message() as RespMessage
		END CATCH
		RETURN; 
		END;
	END
END