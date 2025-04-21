CREATE PROCEDURE [dbo].[DeleteVendorExpenses]
@VendorExpensesId INT
AS
BEGIN
SET NOCOUNT ON;
      UPDATE [VendorExpenses] SET IsActive = 0 WHERE [VendorExpensesId] = @VendorExpensesId;
END      
        
       