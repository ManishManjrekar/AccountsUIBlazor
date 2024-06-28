using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class CustomerQueries
    {
        public static string AllCustomer => "SELECT * FROM [Customer] (NOLOCK) where IsActive=1";

        public static string CustomerById => "SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId and and IsActive=1";

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
        WHERE [CustomerId] = @CustomerId";

        public static string DeleteCustomer => "Update FROM [Customer] WHERE [CustomerId] = @CustomerId where isActive=0";

        public static string CheckDuplicateCustomerName => @" SELECT count(c.CustomerId) FROM [accountancy].[dbo].[Customer] as c
                                                   where c.FirstName = @firstName and c.LastName = @lastName and c.IsActive=1";
    }
}
