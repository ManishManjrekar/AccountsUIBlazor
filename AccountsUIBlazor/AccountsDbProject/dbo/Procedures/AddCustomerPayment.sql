    CREATE PROCEDURE [dbo].[AddCustomerPayment]
    @CustomerId INT,
    @CustomerName NVARCHAR(100),
    @TypeOfTransaction NVARCHAR(50),
    @AmountPaid DECIMAL(18,2),
    @PaymentDate DATETIME,
    @ModifiedDate DATETIME,
    @IsActive BIT,
    @CreatedBy NVARCHAR(50),
    @ModifiedBy NVARCHAR(50),
    @LoggedInUser NVARCHAR(50),
    @Comments NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO [dbo].[CustomerPaymentReceived]
           ([CustomerId],[CustomerName],[TypeOfTransaction],[AmountPaid] ,[PaymentDate],[ModifiedDate],[IsActive],[CreatedBy]
            ,[ModifiedBy],[LoggedInUser] ,[Comments])             
     VALUES
           (@CustomerId,@CustomerName,@TypeOfTransaction,@AmountPaid ,@PaymentDate,@ModifiedDate ,@IsActive,@CreatedBy,@ModifiedBy
           ,@LoggedInUser,@Comments);
      END;      
          

