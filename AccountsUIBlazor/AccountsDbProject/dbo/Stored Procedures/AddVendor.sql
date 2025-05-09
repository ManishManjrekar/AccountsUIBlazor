CREATE PROCEDURE [dbo].[AddVendor]
		   @FirstName NVARCHAR(50),
           @MiddleName NVARCHAR(50),
           @LastName NVARCHAR(50),
           @Mobile NVARCHAR(50),
           @ModifiedDate DATETIME,
           @CreatedDate DATETIME,
           @CreatedBy NVARCHAR(50),
           @ModifiedBy NVARCHAR(50),
           @IsActive BIT,
           @ElectronicPaymentId NVARCHAR(50),
           @ReferredBy NVARCHAR(50),
           @Address NVARCHAR(50),
           @City NVARCHAR(50),
           @State NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
   INSERT INTO [dbo].[Vendor]([FirstName],[MiddleName],[LastName],[Mobile],[ModifiedDate],[CreatedDate],[CreatedBy],[ModifiedBy],
           [IsActive],[ElectronicPaymentId],[ReferredBy],[Address],[City],[State])
     VALUES
           (@FirstName,@MiddleName,@LastName,@Mobile,@ModifiedDate ,@CreatedDate ,@CreatedBy ,@ModifiedBy ,@IsActive,@ElectronicPaymentId
			,@ReferredBy,@Address,@City,@State)
	END;
          
          
           
           
           
             
           
           
           
           
          
           

