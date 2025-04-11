CREATE PROCEDURE [dbo].[CusotmerById]
	@CustomerId INT = 0 
	AS
	SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId AND IsActive=1
	
