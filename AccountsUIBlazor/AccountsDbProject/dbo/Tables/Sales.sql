﻿CREATE TABLE [dbo].[Sales] (
    [SalesId] INT NOT NULL IDENTITY,
    [CustomerId]   INT NULL,
    [VendorId]     INT NULL,
    [StockInId]    INT NULL,
    [Quantity]     INT              NOT NULL,
    [Price]        INT              NOT NULL,
    [Total]        INT              NOT NULL,
    [Type]   NVARCHAR (50)    NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_Sales_createdDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Sales_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]    NVARCHAR (50)    NULL,
    [LoggedInUser] NVARCHAR (500)   NULL,
    [IsActive]     BIT              CONSTRAINT [DF_Sales_IsActive] DEFAULT ((1)) NOT NULL,
    
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([SalesId]),
    CONSTRAINT [FK_Sales_StockIn] FOREIGN KEY ([StockInId]) REFERENCES [dbo].[StockIn] ([StockInId]),
    CONSTRAINT [FK_Sales_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId]),
    CONSTRAINT [FK_Sales_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])

);

