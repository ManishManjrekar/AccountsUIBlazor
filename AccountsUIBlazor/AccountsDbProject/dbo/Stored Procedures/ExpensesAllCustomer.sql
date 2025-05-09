CREATE PROCEDURE [dbo].[ExpensesAllCustomer]
	AS
BEGIN
SET NOCOUNT ON;
 SELECT * FROM [Customer] (NOLOCK) WHERE IsActive = 1;
END;
