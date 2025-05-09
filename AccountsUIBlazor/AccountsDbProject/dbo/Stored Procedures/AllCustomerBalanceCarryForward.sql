CREATE PROCEDURE [dbo].[AllCustomerBalanceCarryForward]
AS
BEGIN
SET NOCOUNT ON;

SELECT * FROM [dbo].[CustomerBalanceCarryForward] (NOLOCK)
END;
