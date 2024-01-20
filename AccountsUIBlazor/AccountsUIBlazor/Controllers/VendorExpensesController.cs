using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountsUIBlazor.Data;
using AccountsUIBlazor.Pages;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountsUIBlazor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VendorExpensesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public VendorExpensesController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

       
        [HttpPost]
        [Route("AddVendorExpenses")]
        public async Task<IActionResult> AddVendorExpenses(UIVendorExpenses uiVendorExpenses)
        {
          
            var apiResponse = new ApiResponse<string>();
            AccountApi.Core.VendorExpenses vendorExpensesData = _IMapper.Map<AccountApi.Core.VendorExpenses>(uiVendorExpenses);
            vendorExpensesData.ExpensesName = uiVendorExpenses.VendorExpensesTypes.ToString();

            try
            {
                vendorExpensesData.IsActive = true;
                vendorExpensesData.ModifiedDate = DateTime.Now;
                vendorExpensesData.LoggedInUser = "System";
                var data = await _unitOfWork.VendorExpenses.AddAsync(vendorExpensesData);

                //TODO:- need to put transaction here........
                //if the commissionAmount need to insert in commisionAgent Earned table 
                if (vendorExpensesData.ExpensesName.Equals("CommissionAmount"))
                {
                    AccountApi.Core.CommissionEarned commissionEarned = _IMapper.Map<AccountApi.Core.CommissionEarned>(uiVendorExpenses);
                    commissionEarned.IsActive = true;
                    commissionEarned.ModifiedDate = DateTime.Now;
                    commissionEarned.LoggedInUser = "System";
                    var res = await _unitOfWork.CommissionEarned.AddAsync(commissionEarned);


                }
               

                apiResponse.Success = true;
                //UIStockIn stockinDataresults = _IMapper.Map<UIVendorExpenses>(data);
                apiResponse.Result = "success";
               
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return Ok(apiResponse);
        }

        [HttpPut]
        public async Task<ApiResponse<UIStockIn>> Update(UIStockIn uIStockIn)
        {
            var apiResponse = new ApiResponse<UIStockIn>();

            try
            {
                AccountApi.Core.StockIn stockinData = _IMapper.Map<AccountApi.Core.StockIn>(uIStockIn);
                var data = await _unitOfWork.StockIn.UpdateAsync(stockinData);
                apiResponse.Success = true;

                UIStockIn stockinDataresults = _IMapper.Map<UIStockIn>(data);
                apiResponse.Result = stockinDataresults;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpDelete]
        public async Task<ApiResponse<string>> Delete(int id)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Vendor.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            //catch (SqlException ex)
            //{
            //    apiResponse.Success = false;
            //    apiResponse.Message = ex.Message;
            //    Logger.Instance.Error("SQL Exception:", ex);
            //}
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpGet]
        [Route("GetStockInAsPerPaymentNotCompleted")]
        public async Task<List<UISalesStockInData>> GetStockInAsPerPaymentNotCompleted()
        {
            List<UISalesStockInData> sales = new List<UISalesStockInData>();
            try
            {
                var data = await _unitOfWork.StockIn.GetStockInAsPerPaymentNotCompleted();
                sales = _IMapper.Map<List<UISalesStockInData>>(data);

            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return sales;
        }

        [HttpGet()]
        [Route("GetVendorExpensesByStockInId")]
        public async Task<List<UIVendorExpenses>> GetVendorExpensesByStockInId(int stockInId)
        {
            List <UIVendorExpenses> results = new List<UIVendorExpenses>();
            try
            {
                var data = await _unitOfWork.VendorExpenses.GetVendorExpensesByStockInId(stockInId);
                results = _IMapper.Map<List<UIVendorExpenses>>(data);
                return results;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }
            return results;
        }

        [HttpGet()]
        [Route("GetCalculateCommissionPercenage_By_StockId")]
        public async Task<UIVendorExpenses_CommissionPercentage> GetCalculateCommissionPercenage_By_StockId(int stockInId)
        {
            UIVendorExpenses_CommissionPercentage results = new UIVendorExpenses_CommissionPercentage();
            try
            {
                //1. Get sum of Sales Amount for a stockId.
                var Sales_Sum = await _unitOfWork.Sales.GetSales_Sum_Per_StockInId(stockInId);

                //2. Get the Commission Percentage value for this application 
                var CommissionPercentage = await _unitOfWork.CommissionAgentPercentage.GetCommissionPercentage_Active();


                //3. Get the TotalCommissionAmount = Total Sales Amount * CommissionPercentage/100
                var CommissionValue = await _unitOfWork.Sales.GetCommission_for_Sales_AsPer_PercentageValue(CommissionPercentage, stockInId);
                results.Sales_Sum = Sales_Sum;
                results.CommissionPercentage = CommissionPercentage;
                results.CommissionValue = CommissionValue;
                return results;

            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }
            return results;
        }


    }
}
