CREATE PROCEDURE [dbo].[UpdateCustomer]
    @CustomerId INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Mobile NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [dbo]. [Customer] 
    SET  [FirstName] = @FirstName, 
        [LastName] = @LastName, 
        [Email] = @Email, 
        [Mobile] = @PhoneNumber
    WHERE [CustomerId] = @CustomerId;
END;