CREATE PROCEDURE[dbo].[UpdateCustomerPaymentReceived]
    @CustomerPaymentId INT,
    @CustomerId INT,
    @CustomerName NVARCHAR(100),
    @AmountPaid DECIMAL(18,2),
    @PaymentDate DATETIME,
    @ModifiedDate DATETIME,
    @IsActive BIT,
    @CreatedBy NVARCHAR(50),
    @ModifiedBy NVARCHAR(50),
    @LoggedInUser NVARCHAR(50),
    @TypeOfTransaction NVARCHAR(50),
    @Comments NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [CustomerPaymentReceived] 
    SET [CustomerId] = @CustomerId,
        [CustomerName] = @CustomerName, 
        [AmountPaid] = @AmountPaid, 
        [PaymentDate] = @PaymentDate, 
        [ModifiedDate] = @ModifiedDate,
        [IsActive] = @IsActive, 
        [CreatedBy] = @CreatedBy, 
        [ModifiedBy] = @ModifiedBy,
        [LoggedInUser] = @LoggedInUser,
        [TypeOfTransaction] = @TypeOfTransaction,
        [Comments] = @Comments
    WHERE [CustomerPaymentId] = @CustomerPaymentId;
END;