CREATE TABLE [dbo].[VendorExpenses] (
    [VendorExpensesId] INT NOT NULL IDENTITY PRIMARY KEY,
    [VendorId]    INT           NULL,
    [StockInId]    INT           NULL,
    [ExpensesName]    NVARCHAR (500)   NULL,
    [LoadName]    NVARCHAR (500)   NULL,
    [AmountPaid]       BIGINT           NULL,
    [VendorName]    NVARCHAR (500)   NULL,
    [LoggedInUser]    NVARCHAR (500)   NULL,
    [Comments]    NVARCHAR (2000)   NULL,

    [ModifiedDate] DATETIME         CONSTRAINT [DF_VendorExpenses_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_VendorExpenses_createdDate] DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (500)   NULL,
    [IsActive]    BIT   NULL,

    
);

