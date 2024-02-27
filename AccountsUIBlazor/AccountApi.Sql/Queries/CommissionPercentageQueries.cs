using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CommissionPercentageQueries
	{
		public static string AllCommissionPercentage => "SELECT * FROM [CommissionPercentage] (NOLOCK) where isActive=1";

        public static string GetCommissionPercentage_Active => "SELECT CommissionPercentage FROM [CommissionPercentage] (NOLOCK) where isActive=1";

        public static string CommissionPercentageById => "SELECT * FROM [CommissionPercentage] (NOLOCK) WHERE [CommissionPercentageId] = @CommissionPercentageId and isActive=1";
        public static string GetAllCommissionPercentageData => "SELECT * FROM [CommissionPercentage] (NOLOCK) WHERE isActive=1";


        public static string AddCommissionPercentage =>
            @"INSERT INTO [dbo].[CommissionPercentage]
           ([CommissionPercentage]
           ,[IsActive])
     VALUES
           (@CommissionPercentage
           ,@IsActive)";

		public static string UpdateCommissionPercentage =>
            @"UPDATE [CommissionPercentage] 
            SET [CommissionPercentage] = @CommissionPercentage, 
				[IsActive] = @IsActive, 
            WHERE [CommissionPercentageId] = @CommissionPercentageId and isActive=1";

		public static string DeleteCommissionPercentage => "Update [CommissionPercentage] set isActive=0 WHERE [CommissionPercentageId] = @CommissionPercentageId";
    }
}
