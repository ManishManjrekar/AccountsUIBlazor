using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class SalesQueries
    {
		public static string AllSales => "SELECT * FROM [Sales] (NOLOCK) where isActive=1";

		public static string SalesById => "SELECT * FROM [Sales] (NOLOCK) WHERE [SalesId] = @SalesId and isActive=1";

		public static string AddSales =>
            @"INSERT INTO [dbo].[Sales]
           ([VendorId]
           ,[StockInId]
           ,[CustomerId]
           ,[Quantity]
           ,[Price]
           ,[TotalAmount]
           ,[Type]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[CreatedBy]
           ,[IsActive]
           ,[LoggedInUser]
            )
     VALUES
           (@VendorId
           ,@StockInId
           ,@CustomerId
           ,@Quantity
           ,@Price
           ,@TotalAmount
           ,@Type
           ,@CreatedDate
           ,@ModifiedDate
           ,@CreatedBy
           ,@IsActive
           ,@LoggedInUser
           )";

		public static string UpdateSales =>
          @"UPDATE [Sales] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId, 
				[CustomerId] = @CustomerId,
                [Quantity] = @Quantity, 
				[Price] = @Price,
                [TotalAmount] = @TotalAmount, 
				[Type] = @Type,
                [CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [CreatedBy] = @CreatedBy, 
				[IsActive] = @IsActive,
				[LoggedInUser] = @LoggedInUser
            WHERE [SalesId] = @SalesId and isActive=1";

        public static string DeleteSales => "Update FROM [Sales] WHERE [SalesId] = @SalesId where isActive=0";

        public static string GetSalesDataAsPerStockInId => @"SELECT s.SalesId,s.createdDate,s.Price, s.Quantity, s.TotalAmount,c.FirstName as CustomerName,
            v.FirstName as VendorName, si.LoadName
            FROM [accountancy].[dbo].[Sales] as s
             inner join Customer as c on s.CustomerId = c.CustomerId
            inner join Vendor as v on v.VendorId = s.VendorId
             inner join StockIn as si on s.StockInId = si.StockInId
              where s.StockInId =  @StockInId and s.isActive=1";

        public static string GetSalesDataAsPerCustomerId => @"SELECT s.SalesId,s.createdDate,s.Price, s.Quantity, s.TotalAmount,c.FirstName as CustomerName,
            v.FirstName as VendorName, si.LoadName
            FROM [accountancy].[dbo].[Sales] as s
             inner join Customer as c on s.CustomerId = c.CustomerId
            inner join Vendor as v on v.VendorId = s.VendorId
             inner join StockIn as si on s.StockInId = si.StockInId
              where s.CustomerId =  @CustomerId and s.isActive=1";

    }
}
