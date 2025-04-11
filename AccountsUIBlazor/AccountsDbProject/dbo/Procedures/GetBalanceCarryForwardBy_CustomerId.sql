CREATE PROCEDURE [dbo].[GetBalanceCarryForwardBy_CustomerId]
@CustomerID INT
AS
BEGIN
SELECT * FROM [dbo].[CustomerBalanceCarryForward] as c where c.CustomerId = @CustomerId and c.IsActive=1
END;

