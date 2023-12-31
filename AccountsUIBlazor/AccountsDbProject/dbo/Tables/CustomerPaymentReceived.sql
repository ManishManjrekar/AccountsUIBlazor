CREATE TABLE [dbo].[CustomerPaymentReceived] (
    [CustomerPaymentId] INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]            INT           NULL,
    [CustomerName]      NVARCHAR (Max)   NULL,
    [AmountPaid]        INT           NULL,
    [PaymentDate]       DATETIME         CONSTRAINT [DF_CustomerPayments_createdDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]      DATETIME         CONSTRAINT [DF_CustomerPayments_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         NVARCHAR (50)    NULL,
    [ModifiedBy]        NVARCHAR (50)    NULL,
    [LoggedInUser]      NVARCHAR (500)   NULL,
    [TypeOfTransaction]      NVARCHAR (50)   NULL,
    [Comments]      NVARCHAR (Max)   NULL,
    [IsActive] BIT NULL, 
    CONSTRAINT [PK_CustomerPayments] PRIMARY KEY CLUSTERED ([CustomerPaymentId] ASC)
);

