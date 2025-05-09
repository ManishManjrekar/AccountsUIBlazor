CREATE PROCEDURE [dbo].[GetBalanceCarryForwardBy_CustomerId]
@CustomerID INT
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [dbo].[CustomerBalanceCarryForward] as c where c.CustomerId = @CustomerId and c.IsActive=1
END;

