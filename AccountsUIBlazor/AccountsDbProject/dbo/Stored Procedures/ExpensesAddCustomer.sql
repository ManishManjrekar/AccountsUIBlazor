CREATE PROCEDURE [dbo].[ExpensesAddCustomer]
	@FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @NickName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Mobile NVARCHAR(15),
    @ReferredBy NVARCHAR(MAX),      
    @CreatedBy NVARCHAR(500),
    @ModifiedDate DATETIME,
    @CreatedDate DATETIME,
    @ModifiedBy INT,
    @IsActive INT
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[Customer]( [FirstName], [MiddleName], [NickName], [LastName],[Mobile], [ReferredBy], [CreatedBy],[ModifiedDate],
                [CreatedDate],[ModifiedBy], [IsActive])VALUES
				(@FirstName, @MiddleName, @NickName, @LastName,@Mobile, @ReferredBy, @CreatedBy, @ModifiedDate, 
                @CreatedDate,@ModifiedBy, @IsActive)
                END;