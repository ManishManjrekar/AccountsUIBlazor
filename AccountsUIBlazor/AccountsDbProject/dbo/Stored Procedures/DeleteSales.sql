CREATE PROCEDURE [dbo].[DeleteSales]
    @SalesId INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [Sales] SET [isActive] = 0 WHERE [SalesId] = @SalesId AND isActive = 1;
END
