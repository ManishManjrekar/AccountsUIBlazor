﻿using System;
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
		public static string AllCustomer => "SELECT * FROM [Customer] (NOLOCK)";

		public static string CustomerById => "SELECT * FROM [Customer] (NOLOCK) WHERE [CustomerId] = @CustomerId";

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
           ,[Url]
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
           ,@Url
           ,@IsActive)";

		public static string UpdateCustomer =>
			@"UPDATE [Customer] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Email] = @Email, 
				[PhoneNumber] = @PhoneNumber
            WHERE [CustomerId] = @CustomerId";

		public static string DeleteCustomer => "DELETE FROM [Customer] WHERE [CustomerId] = @CustomerId";
	}
}
