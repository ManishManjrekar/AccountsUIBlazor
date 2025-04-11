CREATE PROCEDURE [dbo].[GetCommissionEarnedSum_BySelectedDate]
    @CreatedDate DATE
AS
BEGIN
    SELECT SUM(c.Amount) AS TotalCommissionEarned FROM [dbo].[CommissionEarned] as c WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate
      AND c.IsActive = 1;
END
