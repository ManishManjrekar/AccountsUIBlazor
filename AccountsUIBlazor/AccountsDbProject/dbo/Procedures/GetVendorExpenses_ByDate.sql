CREATE PROCEDURE [dbo].[GetVendorExpensesByCreatedDate]
@CreatedDate DATE
AS
BEGIN
     SELECT * FROM [dbo].[VendorExpenses] AS c WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate AND c.IsActive = 1;
END
