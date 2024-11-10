﻿/*
Deployment script for accountancy

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "accountancy"
:setvar DefaultFilePrefix "accountancy"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[CustomerPayments].[Id] is being dropped, data loss could occur.

The type for column AmountPaid in table [dbo].[CustomerPayments] is currently  BIGINT NULL but is being changed to  INT NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  INT NULL.

The type for column CustomerId in table [dbo].[CustomerPayments] is currently  BIGINT NULL but is being changed to  INT NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  INT NULL.

The type for column CustomerPaymentId in table [dbo].[CustomerPayments] is currently  BIGINT IDENTITY (1, 1) NOT NULL but is being changed to  INT IDENTITY (1, 1) NOT NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  INT IDENTITY (1, 1) NOT NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[CustomerPayments])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Vendor].[AlterNateMobileNo] is being dropped, data loss could occur.

The column [dbo].[Vendor].[NickName] is being dropped, data loss could occur.

The type for column Address in table [dbo].[Vendor] is currently  NVARCHAR (4000) NULL but is being changed to  NVARCHAR (500) NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  NVARCHAR (500) NULL.

The type for column State in table [dbo].[Vendor] is currently  NVARCHAR (4000) NULL but is being changed to  NVARCHAR (50) NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  NVARCHAR (50) NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[Vendor])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file ee653ddb-b296-4b70-8f00-5c6f847fa376';

PRINT N'Rename [dbo].[CustomerPayments].[CustId] to CustomerId';


GO
EXECUTE sp_rename @objname = N'[dbo].[CustomerPayments].[CustId]', @newname = N'CustomerId', @objtype = N'COLUMN';


GO
PRINT N'Rename refactoring operation with key ffaf3299-5ad8-441c-b40a-75b35b25ee45 is skipped, element [dbo].[CustomerPayments].[createdDate] (SqlSimpleColumn) will not be renamed to CreatedDate';


GO
PRINT N'Rename refactoring operation with key 6b5a5845-cc69-49b5-aff5-9e98d7ac7dba is skipped, element [dbo].[CustomerPayments].[modifiedDate] (SqlSimpleColumn) will not be renamed to ModifiedDate';


GO
PRINT N'Rename refactoring operation with key b9cc7a98-3bb7-41b3-b532-708a9286e23e is skipped, element [dbo].[CustomerPayments].[createdBy] (SqlSimpleColumn) will not be renamed to CreatedBy';


GO
PRINT N'Rename refactoring operation with key 149bbe0f-5cd6-4ba9-a434-d8dd13b87d82 is skipped, element [dbo].[CustomerPayments].[modifiedBy] (SqlSimpleColumn) will not be renamed to ModifiedBy';


GO
PRINT N'Rename refactoring operation with key 6d8f6c08-5f4f-4603-bcff-d41999473c40 is skipped, element [dbo].[VendorPayments].[createdDate] (SqlSimpleColumn) will not be renamed to CreatedDate';


GO
PRINT N'Rename refactoring operation with key c13c69b1-ac83-48e5-9e7e-8b090f980070 is skipped, element [dbo].[VendorPayments].[modifiedDate] (SqlSimpleColumn) will not be renamed to ModifiedDate';


GO
PRINT N'Rename refactoring operation with key e8b5a771-e90a-4104-b678-903e490a2fa2 is skipped, element [dbo].[VendorPayments].[createdBy] (SqlSimpleColumn) will not be renamed to CreatedBy';


GO
PRINT N'Rename refactoring operation with key 046cc766-cfaa-4ff4-a31e-e29b39fba289 is skipped, element [dbo].[VendorPayments].[modifiedBy] (SqlSimpleColumn) will not be renamed to ModifiedBy';


GO
PRINT N'The following operation was generated from a refactoring log file 36d22f57-79c0-46b2-b097-300d9abd171a';

PRINT N'Rename [dbo].[Vendor].[Email] to ElectronicPaymentId';


GO
EXECUTE sp_rename @objname = N'[dbo].[Vendor].[Email]', @newname = N'ElectronicPaymentId', @objtype = N'COLUMN';


GO
PRINT N'Dropping Default Constraint [dbo].[DF_CustomerPayments_createdDate]...';


GO
ALTER TABLE [dbo].[CustomerPayments] DROP CONSTRAINT [DF_CustomerPayments_createdDate];


GO
PRINT N'Dropping Default Constraint [dbo].[DF_CustomerPayments_modifiedDate]...';


GO
ALTER TABLE [dbo].[CustomerPayments] DROP CONSTRAINT [DF_CustomerPayments_modifiedDate];


GO
PRINT N'Starting rebuilding table [dbo].[CustomerPayments]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CustomerPayments] (
    [CustomerPaymentId] INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]        INT            NULL,
    [CustomerName]      NVARCHAR (MAX) NULL,
    [AmountPaid]        INT            NULL,
    [CreatedDate]       DATETIME       CONSTRAINT [DF_CustomerPayments_createdDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]      DATETIME       CONSTRAINT [DF_CustomerPayments_modifiedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         NVARCHAR (50)  NULL,
    [ModifiedBy]        NVARCHAR (50)  NULL,
    [LoggedInUser]      NVARCHAR (500) NULL,
    [TypeOfTransaction] NVARCHAR (50)  NULL,
    [Comments]          NVARCHAR (MAX) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_CustomerPayments1] PRIMARY KEY CLUSTERED ([CustomerPaymentId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CustomerPayments])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CustomerPayments] ON;
        INSERT INTO [dbo].[tmp_ms_xx_CustomerPayments] ([CustomerPaymentId], [CustomerId], [AmountPaid], [createdDate], [modifiedDate], [createdBy], [modifiedBy], [LoggedInUser])
        SELECT   [CustomerPaymentId],
                 [CustomerId],
                 [AmountPaid],
                 [createdDate],
                 [modifiedDate],
                 [createdBy],
                 [modifiedBy],
                 [LoggedInUser]
        FROM     [dbo].[CustomerPayments]
        ORDER BY [CustomerPaymentId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CustomerPayments] OFF;
    END

DROP TABLE [dbo].[CustomerPayments];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CustomerPayments]', N'CustomerPayments';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_CustomerPayments1]', N'PK_CustomerPayments', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering Table [dbo].[Vendor]...';


GO
ALTER TABLE [dbo].[Vendor] DROP COLUMN [AlterNateMobileNo], COLUMN [NickName];


GO
ALTER TABLE [dbo].[Vendor] ALTER COLUMN [Address] NVARCHAR (500) NULL;

ALTER TABLE [dbo].[Vendor] ALTER COLUMN [State] NVARCHAR (50) NULL;


GO
PRINT N'Altering Table [dbo].[VendorPayments]...';


GO
ALTER TABLE [dbo].[VendorPayments]
    ADD [TypeOfTransaction] NVARCHAR (50)  NULL,
        [Comments]          NVARCHAR (MAX) NULL;


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ee653ddb-b296-4b70-8f00-5c6f847fa376')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ee653ddb-b296-4b70-8f00-5c6f847fa376')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ffaf3299-5ad8-441c-b40a-75b35b25ee45')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ffaf3299-5ad8-441c-b40a-75b35b25ee45')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6b5a5845-cc69-49b5-aff5-9e98d7ac7dba')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6b5a5845-cc69-49b5-aff5-9e98d7ac7dba')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b9cc7a98-3bb7-41b3-b532-708a9286e23e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b9cc7a98-3bb7-41b3-b532-708a9286e23e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '149bbe0f-5cd6-4ba9-a434-d8dd13b87d82')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('149bbe0f-5cd6-4ba9-a434-d8dd13b87d82')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6d8f6c08-5f4f-4603-bcff-d41999473c40')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6d8f6c08-5f4f-4603-bcff-d41999473c40')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c13c69b1-ac83-48e5-9e7e-8b090f980070')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c13c69b1-ac83-48e5-9e7e-8b090f980070')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e8b5a771-e90a-4104-b678-903e490a2fa2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e8b5a771-e90a-4104-b678-903e490a2fa2')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '046cc766-cfaa-4ff4-a31e-e29b39fba289')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('046cc766-cfaa-4ff4-a31e-e29b39fba289')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '36d22f57-79c0-46b2-b097-300d9abd171a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('36d22f57-79c0-46b2-b097-300d9abd171a')

GO

GO
PRINT N'Update complete.';


GO