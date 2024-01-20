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
             inner join [accountancy].[dbo].[Customer] as c on s.CustomerId = c.CustomerId
            inner join [accountancy].[dbo].[Vendor] as v on v.VendorId = s.VendorId
             inner join [accountancy].[dbo].[StockIn] as si on s.StockInId = si.StockInId
              where s.StockInId =  @StockInId and s.isActive=1";

        public static string GetSalesDataAsPerCustomerId => @"SELECT s.SalesId,s.createdDate,s.Price, s.Quantity, s.TotalAmount,c.FirstName as CustomerName,
            v.FirstName as VendorName, si.LoadName
            FROM [accountancy].[dbo].[Sales] as s
             inner join [accountancy].[dbo].[Customer] as c on s.CustomerId = c.CustomerId
            inner join [accountancy].[dbo].[Vendor] as v on v.VendorId = s.VendorId
             inner join [accountancy].[dbo].[StockIn] as si on s.StockInId = si.StockInId
              where s.CustomerId =  @CustomerId and s.isActive=1";

        public static string GetSalesDataAsPerDate => @"SELECT s.SalesId,s.createdDate,s.Price, s.Quantity, s.TotalAmount,c.FirstName as CustomerName,
            v.FirstName as VendorName, si.LoadName
            FROM [accountancy].[dbo].[Sales] as s
             inner join [accountancy].[dbo].[Customer] as c on s.CustomerId = c.CustomerId
            inner join [accountancy].[dbo].[Vendor] as v on v.VendorId = s.VendorId
             inner join [accountancy].[dbo].[StockIn] as si on s.StockInId = si.StockInId
              where CONVERT(DATE,s.CreatedDate) = @CreatedDate and s.isActive=1";

        public static string GetSales_Sum_Per_StockInId => @" SELECT sum(s.TotalAmount) FROM [accountancy].[dbo].[Sales] as s
                                                         where s.StockInId = @StockInId and isActive=1 ";

        public static string GetSales_Sum_Per_Date => @" SELECT sum(s.TotalAmount) FROM [accountancy].[dbo].[Sales] as s
                                                         where CONVERT(DATE,s.CreatedDate) = @CreatedDate and s.isActive=1 ";

        public static string GetSales_Sum_Between_Dates => @" SELECT sum(s.TotalAmount) FROM [accountancy].[dbo].[Sales] as s
                                                         where CONVERT(DATE,s.CreatedDate) between @fromDate and @toDate and s.isActive=1 ";


        public static string GetCommission_for_Sales_PercentageValue => @" SELECT sum(s.TotalAmount) * @PercentageCommission /100.0 
                                                                                      FROM [accountancy].[dbo].[Sales] as s
                                                                                      where s.StockInId = @StockInId and s.isActive=1 ";

    }
}
