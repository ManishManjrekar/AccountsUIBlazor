using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CustomerQueries
	{
		public static string AllCustomer => "SELECT * FROM [Customer] (NOLOCK) where isActive=1";

		public static string CustomerById => "SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId and isActive=1";

		public static string AddCustomer =>
            @"INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[MiddleName]
           ,[NickName]
           ,[LastName]
           ,[Mobile]
           ,[ReferredBy]
           ,[CreatedBy]
           ,[ModifiedDate]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[IsActive])
     VALUES
           (@FirstName
           ,@MiddleName
           ,@NickName
           ,@LastName
           ,@Mobile
           ,@ReferredBy
           ,@CreatedBy
           ,@ModifiedDate
           ,@CreatedDate
           ,@ModifiedBy
           ,@IsActive)";

		public static string UpdateCustomer =>
            @"UPDATE [Customer] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Mobile] = @Mobile
            WHERE [CustomerId] = @CustomerId and isActive=1";

		public static string DeleteCustomer => "Update [Customer] set isActive=0 WHERE [CustomerId] = @CustomerId";
    }
}
