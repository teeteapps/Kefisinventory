CREATE PROCEDURE [dbo].[Usp_VerifyUser]
	@Emailaddress varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Declare @Code int,
			@RespStat int = 0,
			@RespMsg varchar(150) = 'login success',
			@UserCode BIGINT,
			@Fullname varchar(100),
			@Pwd varchar(150),
			@Rolecode int,
			@Email varchar(100)

    BEGIN TRY
		----- Get user details
		Select @UserCode =Userid,@Fullname=Fullname, @Pwd = userpass,@Rolecode=Profilecode,@Email=Emailaddress From Users Where Emailaddress = @Emailaddress
		If(@UserCode Is Null)
		Begin
			Select  1 as RespStatus, 'Invalid Username and/or Password!' as RespMessage
			Return
		End
		
		If(@Pwd Is Null)
		Begin
			Select  1 as RespStatus, 'Invalid Username and/or Password!' as RespMessage
			Return
		End
		If(@Fullname Is Null)
		Begin
			Select  1 as RespStatus, 'Invalid Username and/or Password!' as RespMessage
			Return
		End
		
		--- Create response
		Select  @RespStat as RespStatus, @RespMsg as RespMessage, @UserCode as Data1,@Fullname as Data2,@Pwd as Data3,@Email as Data4,@Rolecode as Data5

	END TRY
	BEGIN CATCH
		SELECT @RespMsg = ERROR_MESSAGE(), @RespStat = 2;
		Select  @RespStat as RespStatus, @RespMsg as RespMessage
	END CATCH

END
