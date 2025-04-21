CREATE PROCEDURE [dbo].[ExpensesCusotmerById]
	@CustomerId INT = 0 
	AS
	SET NOCOUNT ON;
	SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId AND IsActive=1
	
