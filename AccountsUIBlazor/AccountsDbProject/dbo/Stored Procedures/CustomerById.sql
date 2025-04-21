CREATE PROCEDURE [dbo].[CusotmerById]
	@CustomerId INT = 0 
	AS
	BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId AND IsActive=1
	END;
	
