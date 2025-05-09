using AccountApi.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Infrastructure
{
    public class Constants
    {
        //Customer Queries
        public const string GetAllCustomers = "GetAllCustomers";
        public const string CustomerById = "CustomerById";
        public const string AddCustomer = "AddCustomer";
        public const string UpdateCustomer = "UpdateCustomer";
        public const string DeleteCustomer = "DeleteCustomer";
        public const string CheckDuplicateCustomerName = "CheckDuplicateCustomerName";

        //CustomerPaymentReceived Queries
        public const string AllCustomerPaymentReceived = "AllCustomerPaymentReceived";
        public const string GetCPRByCustomerPaymentId = "GetCPRByCustomerPaymentId";
        public const string AddCustomerPayment = "AddCustomerPayment";
        public const string UpdateCustomerPayment = "UpdateCustomerPayment";
        public const string DeleteCustomerPaymentReceived = "DeleteCustomerPaymentReceived";
        public const string GetCustomerPaymentReceivedByCustomerId = "GetCustomerPaymentReceivedByCustomerId";
        public const string GetCustomerPaymentReceivedByDate = "GetCustomerPaymentReceivedByDate";

        //CustomerBalanceCarryForward Queries
        public const string AllCustomerBalanceCarryForward = "AllCustomerBalanceCarryForward";
        public const string GetBalanceCarryForwardBy_CustomerId = "GetBalanceCarryForwardBy_CustomerId";
        //public const string GetBalanceCarryForwardBy_CustomerId = "GetBalanceCarryForwardBy_CustomerId";
        public const string AddCustomerBalanceCarryForward = "AddCustomerBalanceCarryForward";
        public const string UpdateCustomerBalanceCarryForward = "UpdateCustomerBalanceCarryForward";
        public const string DeleteCustomerBalanceCarryForward = "DeleteCustomerBalanceCarryForward";
        public const string GetCustomerBalanceCarry_ByDate = "GetCustomerBalanceCarry_ByDate";

        //Vendor Queries

        //public const string AllVendor = "AllVendor";
        public const string GetActiveVendors = "GetActiveVendors";
        public const string VendorById = "VendorById";
        public const string AddVendor = "AddVendor";
        public const string UpdateVendor = "UpdateVendor";
        public const string DeleteVendor = "DeleteVendor";
        public const string CheckDuplicateVendorName = "CheckDuplicateVendorName";

        //VendorPayment Queries
        public const string AllVendorPayment = "AllVendorPayment";
        public const string VendorPaymentById = "VendorPaymentById";
        public const string AddVendorPayment = "AddVendorPayment";
        public const string UpdateVendorPayment = "UpdateVendorPayment";
        public const string DeleteVendorPayment = "DeleteVendorPayment";
        public const string GetVendorPaymentAsPerStockInId = "GetVendorPaymentAsPerStockInId";
        public const string GetVendorPayments_ByDate = "GetVendorPayments_ByDate";

        //VendorExpenses Queries
        public const string GetAllVendorExpenses = "GetAllVendorExpenses";
        public const string GetAllVendorExpenses_ByStockInId = "GetAllVendorExpenses_ByStockInId";
        public const string AddVendorExpenses = "AddVendorExpenses";
        public const string UpdateVendorExpenses = "UpdateVendorExpenses";
        public const string DeleteVendorExpenses = "DeleteVendorExpenses";
        public const string GetVendorExpenses_ByDate = "GetVendorExpenses_ByDate";
        // public const string GetAllVendorExpenses_ByStockInId = "GetAllVendorExpenses_ByStockInId";


        //Commission Agent Expenses Queries

        public const string GetAllCommissionAgentExpenses = "GetAllCommissionAgentExpenses";
        public const string GetAllCommissionAgentExpenses_ByStockInId = "GetAllCommissionAgentExpenses_ByStockInId";
        public const string AddCommissionAgentExpenses = "AddCommissionAgentExpenses";
        public const string UpdateCommissionAgentExpenses = "UpdateCommissionAgentExpenses";
        public const string DeleteCommissionAgentExpenses = "DeleteCommissionAgentExpenses";
        public const string GetCommissionAgentExpenses_ByDate = "GetCommissionAgentExpenses_ByDate";

        //Commission Agent Percentage Queries
        public const string AllCommissionPercentage = "AllCommissionPercentage";
        public const string CommissionPercentageById = "CommissionPercentageById";
        public const string AddCommissionPercentage = "AddCommissionPercentage";
        public const string UpdateCommissionPercentage = "UpdateCommissionPercentage";
        public const string DeleteCommissionPercentage = "DeleteCommissionPercentage";
        public const string GetAllCommissionPercentageData = "GetAllCommissionPercentageData";
        public const string GetCommissionPercentage_Active = "GetCommissionPercentage_Active";

        //Commission Earned Queries

        public const string GetAllCommissionEarned= "GetAllCommissionEarned";
        public const string GetAllCommissionEarned_ByStockInId = "GetAllCommissionEarned_ByStockInId";
        public const string AddCommissionEarned = "AddCommissionEarned";
        public const string UpdateCommissionEarned = "UpdateCommissionEarned";
        public const string DeleteCommissionEarned = "DeleteCommissionEarned";
        public const string GetCommissionEarned_BySelectedDate = "GetCommissionEarned_BySelectedDate";
        public const string GetCommissionEarned_Between_Dates = "GetCommissionEarned_Between_Dates";
        public const string GetCommissionEarnedSum_BySelectedDate = "GetCommissionEarnedSum_BySelectedDate";
        public const string GetCommissionEarnedSum_Between_Dates = "GetCommissionEarnedSum_Between_Dates";

        //Stock In Queries

        public const string AllStockIn = "AllStockIn";
        public const string GetVendorId_ByStockInId = "GetVendorId_ByStockInId";
        public const string StockInById = "StockInById";
        public const string AddStockIn = "AddStockIn";
        public const string UpdateStockIn = "UpdateStockIn";
        public const string DeleteStockIn = "DeleteStockIn";
        public const string GetVendorLoadCount = "GetVendorLoadCount";
        public const string GetStockInAsPerVendorId = "GetStockInAsPerVendorId";
        public const string GetStockInAsPerDates = "GetStockInAsPerDates";
        public const string GetStockInWhereIn_PaymentNotCompleted = "GetStockInWhereIn_PaymentNotCompleted";
        public const string GetStockInAsperDate = "GetStockInAsperDate";
        public const string GetstockQuantity_ByStockInId = "GetstockQuantity_ByStockInId";
        public const string GetstockQuantity_ByDate = "GetstockQuantity_ByDate";
        public const string CheckDuplicateLoadName = "CheckDuplicateLoadName";

        //Sales Queries

        public const string AllSales = "AllSales";
        public const string SalesById = "SalesById";
        public const string AddSales = "AddSales";
        public const string UpdateSales = "UpdateSales";
        public const string DeleteSales = "DeleteSales";
        public const string GetSalesDataAsPerStockInId = "GetSalesDataAsPerStockInId";
        public const string GetSalesDataAsPerCustomerId = "GetSalesDataAsPerCustomerId";
        public const string GetSalesDataAsPerDate = "GetSalesDataAsPerDate";
        public const string GetSales_Sum_Per_StockInId = "GetSales_Sum_Per_StockInId";
        public const string GetSales_Sum_Per_Date = "GetSales_Sum_Per_Date";
        public const string GetSales_Sum_Between_Dates = "GetSales_Sum_Between_Dates";
        public const string GetCommission_for_Sales_PercentageValue = "GetCommission_for_Sales_PercentageValue";


        //Expenses Types Querirs
        public const string ExpensesAllCustomer = "ExpensesAllCustomer";
        public const string ExpensesCusotmerById = "ExpensesCusotmerById";
        public const string ExpensesAddCustomer = "ExpensesAddCustomer";
        public const string ExpensesUpdateCustomer = "ExpensesUpdateCustomer";
        public const string ExpensesDeleteCustomer = "ExpensesDeleteCustomer";

    }
}
 