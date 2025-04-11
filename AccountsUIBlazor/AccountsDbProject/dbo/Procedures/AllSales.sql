CREATE PROCEDURE [dbo].[AllSales]
AS
BEGIN
    SELECT * FROM [Sales] (NOLOCK) WHERE isActive = 1;
END
