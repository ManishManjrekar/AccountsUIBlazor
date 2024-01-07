CREATE TABLE [dbo].[CustomerBalanceCarryForward]
(
	[CustomerBalanceCarryForwardId] INT NOT NULL IDENTITY PRIMARY KEY,
    [CustomerId]            INT           NOT NULL,
    [CustomerName]      NVARCHAR (Max)   NULL,
    [Amount]        INT           NULL,
    [CreatedDate]       DATETIME         CONSTRAINT [DF_CustomerBalanceCarryForward_createdDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]      DATETIME         CONSTRAINT [DF_CustomerBalanceCarryForward_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         NVARCHAR (50)    NULL,
    [ModifiedBy]        NVARCHAR (50)    NULL,
    [LoggedInUser]      NVARCHAR (500)   NULL,
    [TypeOfTransaction]      NVARCHAR (50)   NULL,
    [Comments]      NVARCHAR (Max)   NULL,
    [IsActive] BIT NULL, 
    CONSTRAINT [PK_CustomerBalanceCarryForward] PRIMARY KEY CLUSTERED ([CustomerBalanceCarryForwardId] ASC)
);
