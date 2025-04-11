CREATE PROCEDURE [dbo].[GetCommissionEarned_Between_Dates]
    @fromDate DATE,
    @toDate DATE
AS
BEGIN
    SELECT * 
    FROM [dbo].[CommissionEarned] as c WHERE CONVERT(DATE, c.CreatedDate) BETWEEN @fromDate AND @toDate  AND c.IsActive = 1;
END
