CREATE PROCEDURE [dbo].[DeleteVendorExpenses]
@VendorExpensesId INT
AS
BEGIN
      UPDATE [VendorExpenses] SET IsActive = 0 WHERE [VendorExpensesId] = @VendorExpensesId;
END      
        
       