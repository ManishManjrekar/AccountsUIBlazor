using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class VendorPaymentQueries
	{
        public static string AllVendorPayment => "SELECT * FROM [VendorPayments] (NOLOCK) where IsActive=1";

        public static string VendorPaymentById => "SELECT * FROM [VendorPayments] (NOLOCK) WHERE [VendorPaymentId] = @VendorPaymentId and IsActive=1";

        public static string GetVendorPayments_ByDate => @"SELECT * FROM [accountancy].[dbo].[VendorPayments] as c
                                                  where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";
        public static string AddVendorPayment =>
            @"INSERT INTO [dbo].[VendorPayments]
           ( [VendorId]
            ,[StockInId]
            ,[TypeOfTransaction]
           ,[AmountPaid]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[LoggedInUser]
           ,[Comments]
           ,[IsActive]
)
           
     VALUES
           (@VendorId
            ,@StockInId
            ,@TypeOfTransaction
           ,@AmountPaid
           ,@CreatedDate
           ,@ModifiedDate
           ,@LoggedInUser
           , @Comments
           ,@IsActive
          )";

        public static string UpdateVendorPayment =>
            @"UPDATE [VendorPayments] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId,
                [TypeOfTransaction] = @TypeOfTransaction
				[AmountPaid] = @AmountPaid, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments,
	            [IsActive] = @IsActive, 
            WHERE [VendorPaymentId] = @VendorPaymentId and IsActive=1 ";

        public static string GetVendorPaymentAsPerStockInId => @"SELECT  vp.StockInId,vp.VendorId, vp.AmountPaid, vp.Comments, vp.CreatedDate , vp.ModifiedDate, vp.TypeOfTransaction, 
                                                                vp.VendorPaymentId, v.FirstName as VendorName
                                                                FROM [accountancy].[dbo].[VendorPayments] as vp
                                                                inner join [accountancy].[dbo].[Vendor] as v on v.VendorId = vp.VendorId
                                                                inner join [accountancy].[dbo].[StockIn] as s on s.StockInId = vp.StockInId
                                                                where vp.StockInId = @StockInId";

        public static string DeleteVendorPayment => "Update [VendorPayments] set isActive=0 where [VendorPaymentId] = @VendorPaymentId ";
    }
}
