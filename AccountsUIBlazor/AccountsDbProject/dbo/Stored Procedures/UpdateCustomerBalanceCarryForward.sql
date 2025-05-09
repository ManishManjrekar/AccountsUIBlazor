CREATE PROCEDURE [dbo].[UpdateCustomerBalanceCarryForward]
    @CustomerBalanceCarryForwardId INT,
    @CustomerId INT,
    @CustomerName NVARCHAR(100),
    @Amount DECIMAL(18,2),
    @CreatedDate DATETIME,
    @ModifiedDate DATETIME,
    @IsActive BIT,
    @CreatedBy NVARCHAR(50),
    @ModifiedBy NVARCHAR(50),
    @LoggedInUser NVARCHAR(50),
    @Comments NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
UPDATE [dbo].[CustomerBalanceCarryForward] SET  [CustomerId] = @CustomerId,[CustomerName] = @CustomerName,[Amount] = @Amount,
			[CreatedDate] = @CreatedDate,[ModifiedDate] = @ModifiedDate,[IsActive] = @IsActive,[CreatedBy] = @CreatedBy,   
			[ModifiedBy] = @ModifiedBy,[LoggedInUser] = @LoggedInUser,[Comments] = @Comments
			WHERE [CustomerBalanceCarryForwardId] = @CustomerBalanceCarryForwardId;
        
END;       
      
