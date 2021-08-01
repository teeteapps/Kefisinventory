CREATE TABLE [dbo].[Companypurchase] (
    [Orderid]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Productid]      BIGINT        NOT NULL,
    [Productname]    VARCHAR (100) NOT NULL,
    [Orderquantity]  INT           NOT NULL,
    [Orderstatus]    VARCHAR (100) NOT NULL,
    [Dateordered]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datedispatched] DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datecreated]    DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Orderid] ASC)
);

