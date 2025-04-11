CREATE PROCEDURE [dbo].[AddVendorExpenses]
    @VendorId INT,
    @StockInId INT,
    @ExpensesName NVARCHAR(255),
    @VendorName NVARCHAR(255),
    @LoadName NVARCHAR(255),
    @AmountPaid DECIMAL(18, 2),
    @CreatedDate DATETIME,
    @ModifiedDate DATETIME,
    @LoggedInUser NVARCHAR(255),
    @Comments NVARCHAR(MAX),
    @IsActive BIT
AS
BEGIN
	INSERT INTO [dbo].[VendorExpenses]([VendorId],[StockInId],[ExpensesName],[VendorName],[LoadName] ,[AmountPaid],[CreatedDate]
           ,[ModifiedDate],[LoggedInUser],[Comments] ,[IsActive])
 VALUES
           (@VendorId,@StockInId,@ExpensesName,@VendorName,@LoadName,@AmountPaid,@CreatedDate,@ModifiedDate,@LoggedInUser
           ,@Comments,@IsActive);
           
END
          
           
           
           
           
          
           
           
           
           
    