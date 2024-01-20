using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CommissionEarnedQueries
    {
        public static string GetAllCommissionEarned => "SELECT * FROM [CommissionEarned] (NOLOCK) where IsActive=1";

        public static string GetAllCommissionEarned_ByStockInId => "SELECT * FROM [CommissionEarned] (NOLOCK) WHERE [StockInId] = @StockInId and IsActive=1";

        public static string GetCommissionEarned_BySelectedDate => @" SELECT * FROM [accountancy].[dbo].[CommissionEarned] as c
                                                         where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";


        public static string GetCommissionEarned_Between_Dates => @" SELECT * FROM [accountancy].[dbo].[CommissionEarned] as c
                                                         where CONVERT(DATE,c.CreatedDate) between @fromDate and @toDate and isActive=1 ";

        public static string GetCommissionEarnedSum_Between_Dates => @" SELECT sum(c.Amount) FROM [accountancy].[dbo].[CommissionEarned] as c
                                                         where CONVERT(DATE,c.CreatedDate) between @fromDate and @toDate and isActive=1 ";

        public static string GetCommissionEarnedSum_BySelectedDate => @" SELECT sum(c.Amount) FROM [accountancy].[dbo].[CommissionEarned] as c
                                                         where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";

        public static string AddCommissionEarned =>
            @"INSERT INTO [dbo].[CommissionEarned]
           ( [VendorId]
            ,[StockInId]
            ,[CommissionPercentageId]
            ,[LoadName]
            ,[VendorName]
           ,[Amount]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[LoggedInUser]
           ,[Comments]
           ,[IsActive]
)
           
     VALUES
           (@VendorId
            ,@StockInId
            ,@LoadName
            ,@VendorName
            ,@CommissionPercentageId
           ,@Amount
           ,@CreatedDate
           ,@ModifiedDate
           ,@LoggedInUser
           , @Comments
           ,@IsActive
          )";

        public static string UpdateCommissionEarned =>
            @"UPDATE [CommissionEarned] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId,
				[CommissionPercentageId] = @CommissionPercentageId,
                [LoadName] = @LoadName
                [VendorName] = @VendorName
				[Amount] = @Amount, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments,
	            [IsActive] = @IsActive, 
            WHERE [CommissionEarnedId] = @CommissionEarnedId and IsActive=1 ";

       
        public static string DeleteCommissionEarned => "Update [CommissionEarned] set isActive=0 where [CommissionEarnedId] = @CommissionEarnedId ";
    }
}
