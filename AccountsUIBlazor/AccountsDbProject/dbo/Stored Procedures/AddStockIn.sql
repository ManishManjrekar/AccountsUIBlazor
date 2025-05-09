CREATE PROCEDURE[dbo].[AddStockIn]
    @LoadName NVARCHAR(100),
    @VendorId INT,
    @Quantity INT,
    @isActive BIT,
    @IsPaymentDone BIT,
    @VendorName NVARCHAR(100),
    @CreatedBy NVARCHAR(100),
    @ModifiedDate DATETIME,
    @CreatedDate DATETIME
AS
BEGIN
SET NOCOUNT ON;
     INSERT INTO [dbo].[StockIn]([LoadName],[VendorId],[Quantity],[isActive],[IsPaymentDone],[VendorName],[CreatedBy],[ModifiedDate],[CreatedDate])
    VALUES(@LoadName,@VendorId,@Quantity,@isActive,@IsPaymentDone,@VendorName,@CreatedBy,@ModifiedDate,@CreatedDate);
END
