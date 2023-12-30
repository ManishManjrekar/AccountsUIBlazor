using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class StockInQueries
    {
		public static string AllStockIn => "SELECT * FROM [StockIn] (NOLOCK)";

		public static string StockInById => "SELECT * FROM [StockIn] (NOLOCK) WHERE [StockInId] = @StockInId";

		public static string AddStockIn =>
            @"INSERT INTO [dbo].[StockIn]
           ([LoadName]
           ,[VendorId]
           ,[Quantity]
           ,[isActive]
           ,[IsPaymentDone]
           ,[VendorName]
           ,[CreatedBy]
           ,[ModifiedDate]
           ,[CreatedDate]
          )
          
     VALUES
           (@LoadName
           ,@VendorId
           ,@Quantity
           ,@isActive
           ,@IsPaymentDone
           ,@VendorName
           ,@CreatedBy
           ,@ModifiedDate
           ,@CreatedDate
          )";

		public static string UpdateStockIn =>
            @"UPDATE [StockIn] 
            SET [Quantity] = @Quantity, 
				[VendorId] = @VendorId, 
				[LoadName] = @LoadName, 
				[IsPaymentDone] = @IsPaymentDone
            WHERE [StockInId] = @StockInId";

        public static string GetStockInAsPerVendorId => @"SELECT * FROM[accountancy].[dbo].[StockIn] as s
                                             where s.VendorId = @VendorId and s.CreatedDate between @fromDate and @toDate";
        public static string GetStockInAsPerDates => @"SELECT * FROM[accountancy].[dbo].[StockIn] as s
                                             where s.CreatedDate between @fromDate and @toDate";
        public static string GetVendorLoadCount => @"SELECT count(*) FROM [accountancy].[dbo].[StockIn] as s
                                                   where s.VendorId = @VendorId and s.CreatedDate = @createdDate";


        public static string DeleteStockIn => "Update FROM [StockIn] WHERE [StockInId] = @StockInId where isActive=0";
	}
}
