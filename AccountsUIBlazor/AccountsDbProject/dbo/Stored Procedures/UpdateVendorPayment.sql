CREATE PROCEDURE [dbo].[UpdateVendorPayment]
@VendorId INT,
@StockInId INT,
@TypeOfTransaction NVARCHAR(50),
@AmountPaid BIGINT,
@CreatedDate DATETIME,
@ModifiedDate DATETIME,
@LoggedInUser NVARCHAR(500),
@Comments NVARCHAR(MAX),
@IsActive BIT,
@VendorPaymentId INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [VendorPayments] SET [VendorId] = @VendorId,[StockInId] = @StockInId,[TypeOfTransaction] = @TypeOfTransaction,
								[AmountPaid] = @AmountPaid, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate,
								[LoggedInUser] = @LoggedInUser,[Comments] = @Comments,[IsActive] = @IsActive
								WHERE [VendorPaymentId] = @VendorPaymentId and IsActive=1
END; 
