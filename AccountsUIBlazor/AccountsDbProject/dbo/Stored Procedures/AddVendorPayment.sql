CREATE PROCEDURE [dbo].[AddVendorPayment]
@VendorId INT,
@StockInId INT,
@TypeOfTransaction NVARCHAR(50),
@AmountPaid BIGINT,
@CreatedDate DATETIME,
@ModifiedDate DATETIME,
@LoggedInUser NVARCHAR(500),
@Comments NVARCHAR(MAX),
@IsActive BIT
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[VendorPayments] ([VendorId] ,[StockInId] ,[TypeOfTransaction],[AmountPaid],[CreatedDate],[ModifiedDate]
				,[LoggedInUser],[Comments] ,[IsActive]) VALUES
                (@VendorId,@StockInId ,@TypeOfTransaction,@AmountPaid,@CreatedDate,@ModifiedDate,@LoggedInUser ,@Comments,@IsActive)
END;            
          