CREATE PROCEDURE [dbo].[GetVendorPaymentAsPerStockInId]
@VendorId INT,
@StockInId INT,
@TypeOfTransaction NVARCHAR(50),
@AmountPaid BIGINT,
@CreatedDate DATETIME,
@ModifiedDate DATETIME,
@LoggedInUser NVARCHAR(500),
@Comments NVARCHAR(MAX),
@IsActive BIT,
@VendorPaymentId INT
AS
BEGIN
SET NOCOUNT ON;
   SELECT  vp.StockInId,vp.VendorId, vp.AmountPaid, vp.Comments, vp.CreatedDate , vp.ModifiedDate, vp.TypeOfTransaction, 
           vp.VendorPaymentId, v.FirstName as VendorName FROM [dbo].[VendorPayments] as vp
           inner join [dbo].[Vendor] as v on v.VendorId = vp.VendorId
		   inner join [dbo].[StockIn] as s on s.StockInId = vp.StockInId where vp.StockInId = @StockInId
END;            
           
           
         
           
           
          
           
          

           
           
           
           
           
           
          

           
    
          
