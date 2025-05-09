CREATE PROCEDURE [dbo].[GetActiveVendorExpenses]
AS
BEGIN 
SET NOCOUNT ON;
SELECT * FROM [dbo].[VendorExpenses] WITH (NOLOCK) WHERE IsActive = 1;
END