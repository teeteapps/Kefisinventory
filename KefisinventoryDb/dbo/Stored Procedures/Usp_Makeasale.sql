CREATE PROCEDURE [dbo].[Usp_Makeasale]
	@id BIGINT
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
		UPDATE Products SET Quantity=Quantity-1 WHERE Productid=@id
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