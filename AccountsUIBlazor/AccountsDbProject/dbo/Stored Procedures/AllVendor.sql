CREATE PROCEDURE [dbo] .[GetActiveVendors]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[Vendor] WITH (NOLOCK) WHERE IsActive = 1;
END;