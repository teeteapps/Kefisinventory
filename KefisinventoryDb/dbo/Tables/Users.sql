CREATE TABLE [dbo].[Users] (
    [Userid]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Fullname]     VARCHAR (100) NOT NULL,
    [Emailaddress] VARCHAR (100) NOT NULL,
    [userpass]     VARCHAR (100) NOT NULL,
    [Profilecode]  VARCHAR (100) NOT NULL,
    [Datecreated]  DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Userid] ASC),
    UNIQUE NONCLUSTERED ([Emailaddress] ASC)
);

