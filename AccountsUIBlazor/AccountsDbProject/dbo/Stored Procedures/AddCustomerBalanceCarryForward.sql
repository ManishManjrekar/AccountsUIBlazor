CREATE PROCEDURE [dbo].[AddCustomerBalanceCarryForward]
			@CustomerId INT,
            @CustomerName NVARCHAR(50),
            @Amount INT,
            @CreatedDate DATETIME,
            @ModifiedDate DATETIME,
            @IsActive BIT,
            @CreatedBy NVARCHAR(50),
            @ModifiedBy DATETIME,
            @LoggedInUser NVARCHAR(50),
            @Comments NVARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo]. CustomerBalanceCarryForward
           ([CustomerId],[CustomerName] ,[Amount],[CreatedDate],[ModifiedDate],[IsActive],[CreatedBy],[ModifiedBy],[LoggedInUser],[Comments]) VALUES
			 (@CustomerId,@CustomerName,@Amount,@CreatedDate,@ModifiedDate,@IsActive,@CreatedBy,@ModifiedBy,@LoggedInUser,@Comments);
END; 
