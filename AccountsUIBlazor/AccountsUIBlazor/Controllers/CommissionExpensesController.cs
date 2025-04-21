using Microsoft.AspNetCore.Mvc;
using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountsUIBlazor.Data;
using AccountsUIBlazor.Pages;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using AccountsUIBlazor.Controller;

namespace AccountsUIBlazor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommissionExpensesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        
        public CommissionExpensesController(IUnitOfWork unitOfWork,IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;
        }


        [HttpGet]
        [Route("GetAllCommissionAgentExpenses")]
        public async Task<List<UICommissionExpenses>> GetAll()
        {
            var apiResponse = new ApiResponse<List<UICommissionExpenses>>();
            List<UICommissionExpenses> CommissionsList = new List<UICommissionExpenses>();
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.GetAllAsync();
                CommissionsList = _IMapper.Map<List<UICommissionExpenses>>(data);
                apiResponse.Success = true;
                apiResponse.Result = CommissionsList;
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

            return CommissionsList;
        }

        [HttpGet]
        [Route("GetAllCommissionNames")]
        public async Task<List<UICommissionExpenses>> GetAllCustomerNames()
        {
            var CommissionNames = new List<UICommissionExpenses>();
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.GetAllAsync();
                CommissionNames = _IMapper.Map<List<UICommissionExpenses>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Exception:", ex);
            }
            return CommissionNames;
        }




        [HttpPost]
        [Route("AddCommissionAgentExpenses")]

        public async Task<IActionResult> AddCommissionAgentExpenses(UICommissionExpenses uiCommissionExpenses)
        {
            var apiResponse = new ApiResponse<string>();
            AccountApi.Core.Entities.CommissionAgentExpenses commissionExpensesData = _IMapper.Map<AccountApi.Core.Entities.CommissionAgentExpenses>(uiCommissionExpenses);
            commissionExpensesData.ExpensesName = uiCommissionExpenses.CommissionExpensesTyps.ToString();
            try
            {
                commissionExpensesData.IsActive = true;
                commissionExpensesData.ModifiedDate = DateTime.Now;
                commissionExpensesData.LoggedInUser = "System";
                var data = await _unitOfWork.CommissionAgentExpenses.AddAsync(commissionExpensesData);
                //TODO:- need to put transaction here........
                //if the commissionAmount need to insert in commisionAgent Earned table 
                if (commissionExpensesData.ExpensesName.Equals("CommissionAmount"))
                {
                    AccountApi.Core.CommissionEarned commissionEarned = _IMapper.Map<AccountApi.Core.CommissionEarned>(uiCommissionExpenses);

                    //commissionEarned.CommissionPercentage = uiVendorExpenses.CommissionPercentage;
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
        public async Task<ApiResponse<UICommissionExpenses>> Update(UICommissionExpenses uIStockIn)
        {
            var apiResponse = new ApiResponse<UICommissionExpenses>();

            try
            {
                AccountApi.Core.StockIn stockinData = _IMapper.Map<AccountApi.Core.StockIn>(uIStockIn);
                var data = await _unitOfWork.StockIn.UpdateAsync(stockinData);
                apiResponse.Success = true;

                UICommissionExpenses stockinDataresults = _IMapper.Map<UICommissionExpenses>(data);
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


        [HttpGet("{id}")]
        public async Task<ApiResponse<UICommissionExpenses>> GetById(int id)
        {

            var apiResponse = new ApiResponse<UICommissionExpenses>();

            try
            {
                var data = await _unitOfWork.Customers.GetByIdAsync(id);
                UICommissionExpenses Commission = _IMapper.Map<UICommissionExpenses>(data);
                apiResponse.Success = true;
                apiResponse.Result = Commission;
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

    }

}
