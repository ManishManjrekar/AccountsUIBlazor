CREATE PROCEDURE [dbo].[SalesById]
    @SalesId INT
AS
BEGIN
    SELECT * FROM [Sales] (NOLOCK) WHERE [SalesId] = @SalesId AND isActive = 1;   
END
