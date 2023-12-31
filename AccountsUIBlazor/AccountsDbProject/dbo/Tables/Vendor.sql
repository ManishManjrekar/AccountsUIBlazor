CREATE TABLE [dbo].[Vendor] (
    [VendorId] INT NOT NULL IDENTITY, 
    [FirstName]         NVARCHAR (500)   NULL,
    [MiddleName]        NVARCHAR (500)   NULL,
    [LastName]          NVARCHAR (500)   NULL,
    [Mobile]          NVARCHAR (500)   NULL,
    [CreatedDate]       DATETIME         DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]      DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         NVARCHAR (50)    NULL,
    [ModifiedBy]        NVARCHAR (50)    NULL,
    [IsActive]          BIT              CONSTRAINT [DF_Vendor_IsActive] DEFAULT ((1)) NULL,
    [ReferredBy]        NVARCHAR (500)   NULL,
    [ElectronicPaymentId]             NVARCHAR (500)   NULL,
    [Address]           NVARCHAR (500)  NULL,
    [City]              NVARCHAR (50)    NULL,
    [State]             NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ([VendorId])
);

