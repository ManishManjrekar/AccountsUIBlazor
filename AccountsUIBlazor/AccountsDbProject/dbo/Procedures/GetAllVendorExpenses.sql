CREATE PROCEDURE [dbo].[GetActiveVendorExpenses]
AS
BEGIN   
SELECT * FROM [dbo].[VendorExpenses] WITH (NOLOCK) WHERE IsActive = 1;
END