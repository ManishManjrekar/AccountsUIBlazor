CREATE TABLE [dbo].[CommissionAgentExpenses] (
    [CommissionAgentExpensesId] INT           IDENTITY (1, 1) NOT NULL,
    [ExpenseId]                 INT           NULL,
    [Amount]                    INT           NULL,
    [CreatedBy]                 NVARCHAR (500)   NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_CommisionAgentExpenses_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedDate]               DATETIME         CONSTRAINT [DF_CommisionAgentExpenses_createdDate] DEFAULT (getdate()) NOT NULL,
    [StockInId]                 INT           NOT NULL,
    [ExpensesName]             NVARCHAR (500)   NULL,
    [VendorId]                 INT           NULL,
    [ElectronicPaymentId]       NVARCHAR (500)   NULL,
    [AmountPaid]   BIGINT           NULL,
    [LoggedInUser]              NVARCHAR (500)   NULL,
    [Comments]                  NVARCHAR (500)   NULL,
    [IsActive]                 BIT NULL, 
    CONSTRAINT [PK_CommisionAgentExpenses] PRIMARY KEY CLUSTERED ([CommissionAgentExpensesId] ASC)
);

