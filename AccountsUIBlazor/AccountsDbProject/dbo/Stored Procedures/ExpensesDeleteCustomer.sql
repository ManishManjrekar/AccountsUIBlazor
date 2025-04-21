CREATE PROCEDURE [dbo].[ExpensesDeleteCustomer]
	@CustomerId INT
AS
BEGIN
SET NOCOUNT ON;
Update [dbo].[Customer] SET isActive=0  WHERE [CustomerId] = @CustomerId;
END;