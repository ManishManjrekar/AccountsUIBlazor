CREATE PROCEDURE [dbo].[UpdateVendorExpenses]
    @VendorExpensesId INT,
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
	UPDATE [VendorExpenses]SET [VendorId] = @VendorId,[StockInId] = @StockInId, [ExpensesName] = @ExpensesName, [VendorName] = @VendorName,
								[LoadName] = @LoadName, [AmountPaid] = @AmountPaid, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate,
								[LoggedInUser] = @LoggedInUser,[Comments] = @Comments,[IsActive] = @IsActive
								WHERE [VendorExpensesId] = @VendorExpensesId AND IsActive = 1;
								END   
