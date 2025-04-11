
CREATE PROCEDURE [dbo].[DeleteCustomer]
@CustomerId INT
AS
BEGIN
Update [dbo].[Customer] SET isActive=0  WHERE [CustomerId] = @CustomerId;
END;