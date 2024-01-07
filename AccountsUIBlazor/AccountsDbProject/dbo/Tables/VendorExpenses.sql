CREATE TABLE [dbo].[VendorExpenses] (
    [VendorExpensesId] INT NOT NULL IDENTITY PRIMARY KEY,
    [StockInId]    BIGINT           NULL,
    [ExpenseId]    BIGINT           NULL,
    [Amount]       BIGINT           NULL,
    [createdBy]    NVARCHAR (500)   NULL,
    [modifiedDate] DATETIME         CONSTRAINT [DF_VendorExpenses_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [createdDate]  DATETIME         CONSTRAINT [DF_VendorExpenses_createdDate] DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (500)   NULL,
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_VendorExpenses_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

