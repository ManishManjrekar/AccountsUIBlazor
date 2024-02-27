CREATE TABLE [dbo].[StockIn] (
    [StockInId] INT NOT NULL IDENTITY, 
    [CreatedDate]           DATETIME         NOT NULL,
    [LoadName]              NVARCHAR (MAX)   NOT NULL,
    [ModifiedDate]      DATETIME         NULL,
    [LoginID]               NVARCHAR (MAX)   NULL,
    [isActive]              BIT              CONSTRAINT [DF_StockIn_isActive] DEFAULT ((1)) NOT NULL,
    [Quantity]              INT              NOT NULL,
    [IsPaymentDone] BIT              NULL,
    [VendorId] INT NOT NULL, 
    [VendorName] NVARCHAR(MAX) NULL, 
    [CreatedBy] NVARCHAR(500) NULL, 
    CONSTRAINT [PK_StockIn_1] PRIMARY KEY CLUSTERED ([StockInId]),
    CONSTRAINT [FK_StockIn_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId])
);

