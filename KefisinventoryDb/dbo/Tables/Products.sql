CREATE TABLE [dbo].[Products] (
    [Productid]     BIGINT          IDENTITY (1, 1) NOT NULL,
    [Productname]   VARCHAR (100)   NOT NULL,
    [Quantity]      INT             NOT NULL,
    [Price]         DECIMAL (10, 2) NOT NULL,
    [Reorderlevel]  INT             DEFAULT ((5)) NOT NULL,
    [Datereordered] DATETIME        DEFAULT (getdate()) NOT NULL,
    [Daterecieved]  DATETIME        DEFAULT (getdate()) NOT NULL,
    [Datecreated]   DATETIME        DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Productid] ASC)
);


GO
CREATE TRIGGER Automatedordering ON Products
AFTER UPDATE
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @Productname VARCHAR(100)
	   DECLARE @Productid INT
	   DECLARE @Quantity INT
	   DECLARE @Reorderlevel INT
	   SELECT @Productid = INSERTED.Productid FROM INSERTED
       SELECT @Productname = INSERTED.Productname FROM INSERTED
	   SELECT @Quantity = INSERTED.Quantity FROM INSERTED
	   SELECT @Reorderlevel = INSERTED.Reorderlevel FROM INSERTED
	   IF(@Quantity<=@Reorderlevel)
	   BEGIN
	   INSERT INTO Companypurchase (Productid,Productname,Orderquantity,Orderstatus)
	   VALUES(@Productid,@Productname,(@Quantity+5),'unprocessed' )
	   END
END