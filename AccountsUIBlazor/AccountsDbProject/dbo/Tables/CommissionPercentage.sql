CREATE TABLE [dbo].[CommissionPercentage] (
    [CommissionPercentageId] INT           IDENTITY (1, 1) NOT NULL,
    [CommissionPercentage]             INT       NOT NULL,
    [IsActive] BIT NULL, 
    CONSTRAINT [PK_CommissionPercentage] PRIMARY KEY CLUSTERED ([CommissionPercentageId] ASC)
);

