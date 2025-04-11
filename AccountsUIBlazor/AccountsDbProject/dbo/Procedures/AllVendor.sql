CREATE PROCEDURE [dbo] .[GetActiveVendors]
AS
BEGIN
    SELECT * FROM [dbo].[Vendor] WITH (NOLOCK) WHERE IsActive = 1;
END;