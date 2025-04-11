CREATE PROCEDURE [dbo].[GetAllCustomers]
AS
BEGIN
 SELECT * FROM [Customer] (NOLOCK) WHERE IsActive = 1;
END;
