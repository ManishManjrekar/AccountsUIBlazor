﻿CREATE TABLE [dbo].[VendorPayments] (
    [VendorPaymentId]          INT NOT NULL IDENTITY,
    [AmountPaid]   BIGINT           NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_VendorPayments_createdDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_VendorPayments_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]    NVARCHAR (50)    NULL,
    [ModifiedBy]   NVARCHAR (50)    NULL,
    [LoggedInUser] NVARCHAR (500)   NULL,
    [VendorId]     INT NOT NULL,
    [StockInId]    INT NOT NULL, 
    [TypeOfTransaction] NVARCHAR(50) NULL, 
    [Comments] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_VendorPayments] PRIMARY KEY ([VendorPaymentId])
    
);

