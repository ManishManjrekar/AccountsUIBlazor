CREATE PROCEDURE [dbo].[AddSales]
    @VendorId INT,
    @StockInId INT,
    @CustomerId INT,
    @Quantity INT,
    @Price DECIMAL(18, 2),
    @TotalAmount DECIMAL(18, 2),
    @Type NVARCHAR(50),
    @CreatedDate DATETIME,
    @ModifiedDate DATETIME,
    @CreatedBy NVARCHAR(50),
    @IsActive BIT,
    @LoggedInUser NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[Sales]([VendorId],[StockInId],[CustomerId],[Quantity],[Price],[TotalAmount],[Type],[CreatedDate],[ModifiedDate]
                            ,[CreatedBy],[IsActive],[LoggedInUser])
                            VALUES(@VendorId,@StockInId,@CustomerId,@Quantity,@Price,@TotalAmount,@Type,@CreatedDate,@ModifiedDate,@CreatedBy
                            ,@IsActive,@LoggedInUser);
END

