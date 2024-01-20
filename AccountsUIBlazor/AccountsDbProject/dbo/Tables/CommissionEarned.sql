﻿CREATE TABLE [dbo].[CommissionEarned] (
    [CommissionEarnedId]     INT           IDENTITY (1, 1) NOT NULL,
    VendorId              INT           NOT NULL,
     [StockInId]              INT           NOT NULL,
     [LoadName]             NVARCHAR (500)   NULL,
     [VendorName]            NVARCHAR (500)   NULL,
    [Amount]                 INT           NULL,
    [createdBy]              NVARCHAR (500)   NULL,
    [ModifiedDate]           DATETIME         CONSTRAINT [DF_CommissionEarned_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedDate]            DATETIME         CONSTRAINT [DF_CommissionEarned_createdDate] DEFAULT (getdate()) NOT NULL,
    [LoggedInUser]             NVARCHAR (500)   NULL,
    [Comments]             NVARCHAR (500)   NULL,
    [CommissionPercentage] INT           NOT NULL,
    [IsActive] BIT NULL, 
    CONSTRAINT [PK_CommissionEarned] PRIMARY KEY CLUSTERED ([CommissionEarnedId] ASC),
    CONSTRAINT [FK_CommissionEarned_CommissionPercentage] FOREIGN KEY ([CommissionPercentage]) REFERENCES [dbo].[CommissionPercentage] ([CommissionPercentageId])
);

