CREATE PROCEDURE [dbo].[UpdateCustomerPayment]
    @CustomerPaymentId INT,
    @CustomerId INT,
    @CustomerName NVARCHAR(255),
    @AmountPaid DECIMAL(18,2),
    @PaymentDate DATETIME,
    @ModifiedDate DATETIME,
    @IsActive BIT,
    @CreatedBy NVARCHAR(255),
    @ModifiedBy NVARCHAR(255),
    @LoggedInUser NVARCHAR(255),
    @TypeOfTransaction NVARCHAR(255),
    @Comments NVARCHAR(MAX)
AS
BEGIN
UPDATE [dbo].[CustomerPaymentReceived] SET [CustomerId] = @CustomerId, [CustomerName] = @CustomerName,[AmountPaid] = @AmountPaid, [PaymentDate] = @PaymentDate,   
        [ModifiedDate] = @ModifiedDate,[IsActive] = @IsActive, [CreatedBy] = @CreatedBy,[ModifiedBy] = @ModifiedBy,[LoggedInUser] = @LoggedInUser,
        [TypeOfTransaction] = @TypeOfTransaction,[Comments] = @Comments WHERE [CustomerPaymentId] = @CustomerPaymentId;
END;
       
    
       
        