using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Core.Entities;
using AccountApi.Logging;
using Accounts.Apis.Controllers;
using AccountsUIBlazor.Controllers;
//using AccountsUIBlazor.Data;
//using AccountsUIBlazor.Pages;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Accounts.Models.ApiResponse;

namespace AccountsUIBlazor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommissionAgentExpensesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public CommissionAgentExpensesController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        [Route("AddCommissionAgentExpenses")]
        //[Route("Add")]
        public async Task<IActionResult> AddCommissionAgentExpenses(UICommissionAgentExpenses uiCommissionAgentExpenses)
        {

            var apiResponse = new ApiResponse<string>();
            AccountApi.Core.Entities.CommissionAgentExpenses CommissionAgentExpensesData = _IMapper.Map<AccountApi.Core.Entities.CommissionAgentExpenses>(uiCommissionAgentExpenses);
            CommissionAgentExpensesData.ExpensesName = uiCommissionAgentExpenses.CommissionAgentExpensesTypes.ToString();

            try
            {
                CommissionAgentExpensesData.IsActive = true;
                CommissionAgentExpensesData.ModifiedDate = DateTime.Now;
                //CommissionAgentExpensesData.LoggedInUser = "System";
                var data = await _unitOfWork.CommissionAgentExpenses.AddAsync(CommissionAgentExpensesData);

                apiResponse.Success = true;
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

        [HttpGet()]
        [Route("GetAllAsync")]
        public async Task<List<UICommissionAgentExpenses>> GetAllAsync()
        {
            List<UICommissionAgentExpenses> results = new List<UICommissionAgentExpenses>();
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.GetAllAsync();

                results = _IMapper.Map<List<UICommissionAgentExpenses>>(data);
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

        [HttpGet]
        [Route("GetCommissionAgentExpenses")]
        public async Task<List<UICommissionAgentExpenses>> GetAll()
        {
            var apiResponse = new ApiResponse<List<UICommissionAgentExpenses>>();
            List<UICommissionAgentExpenses> CommissionAgentExpensesList = new List<UICommissionAgentExpenses>();
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.GetAllAsync();
                CommissionAgentExpensesList = _IMapper.Map<List<UICommissionAgentExpenses>>(data);
                apiResponse.Success = true;
                apiResponse.Result = CommissionAgentExpensesList;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return CommissionAgentExpensesList;
        }

        [HttpGet()]
        [Route("GetByIdAsync")]
        public async Task<List<UICommissionAgentExpenses>> GetByIdAsync(int stockInId)
        {
            List<UICommissionAgentExpenses> results = new List<UICommissionAgentExpenses>();
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.GetByIdAsync(stockInId);

                results = _IMapper.Map<List<UICommissionAgentExpenses>>(data);
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


        [HttpPut]
        public async Task<ApiResponse<UICommissionAgentExpenses>> Update(UICommissionAgentExpenses Commission)
        {
            var apiResponse = new ApiResponse<UICommissionAgentExpenses>();
            AccountApi.Core.Entities.CommissionAgentExpenses CommissionExpensesData = _IMapper.Map<AccountApi.Core.Entities.CommissionAgentExpenses>(Commission);
            try
            {
                var data = await _unitOfWork.CommissionAgentExpenses.UpdateAsync(CommissionExpensesData);
                UICommissionAgentExpenses CommissionUI = _IMapper.Map<UICommissionAgentExpenses>(data);
                apiResponse.Success = true;
                apiResponse.Result = CommissionUI;
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
                var data = await _unitOfWork.CommissionAgentExpenses.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
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
