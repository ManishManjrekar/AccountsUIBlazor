CREATE TABLE [dbo].[Customer] (
    [CustomerId] INT IDENTITY (1, 1) NOT NULL, 
    [FirstName]    NVARCHAR (MAX)   NULL,
    [MiddleName]   NVARCHAR (MAX)   NULL,
    [NickName]     NVARCHAR (MAX)   NULL,
    [LastName]     NVARCHAR (MAX)   NULL,
    [Mobile]       NVARCHAR (50)    NULL,
    [ReferredBy]   NVARCHAR (MAX)   NULL,
    [CreatedBy]    NVARCHAR (500)   NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Customer_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_Customer_modifiedDate1] DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   NVARCHAR (500)   NULL,
    [IsActive]     BIT              CONSTRAINT [DF_Customer_IsActive] DEFAULT ((1)) NULL,
   
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId])
);

