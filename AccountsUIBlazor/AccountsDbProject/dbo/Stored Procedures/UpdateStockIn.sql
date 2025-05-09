CREATE PROCEDURE [dbo].[UpdateStockIn]
    @StockInId INT,
    @Quantity INT,
    @VendorId INT,
    @LoadName NVARCHAR(100),
    @IsPaymentDone BIT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [StockIn]SET [Quantity] = @Quantity,[VendorId] = @VendorId,[LoadName] = @LoadName,[IsPaymentDone] = @IsPaymentDone
    WHERE [StockInId] = @StockInId;
END


