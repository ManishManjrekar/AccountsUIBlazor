CREATE PROCEDURE [dbo].[CheckDuplicateCustomerName]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50)
AS
BEGIN
   SELECT COUNT(c.CustomerId) AS CustomerCount FROM [dbo].[Customer] AS c WHERE c.FirstName = @FirstName  AND c.LastName = @LastName  AND c.IsActive = 1;
END;