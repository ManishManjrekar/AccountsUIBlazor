CREATE PROCEDURE [dbo].[GetCommissionEarned_BySelectedDate]
    @CreatedDate DATE
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[CommissionEarned] as c WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate AND c.IsActive = 1;
END
