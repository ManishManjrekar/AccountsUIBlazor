using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountAPIGateway.Data;
using AccountAPIGateway.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountAPIGateway.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CommissionAgentPercentageController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public CommissionAgentPercentageController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

       
        [HttpPost]
        [Route("AddCommissionPercentage")]
        public async Task<IActionResult> AddCommissionPercentage(UICommissionAgentPercentage uiCommissionPercentage)
        {
          
            var apiResponse = new ApiResponse<string>();
            AccountApi.Core.CommissionAgentPercentage commissionPercentage = _IMapper.Map<AccountApi.Core.CommissionAgentPercentage>(uiCommissionPercentage);
            try
            {
                commissionPercentage.IsActive = true;
                var data = await _unitOfWork.CommissionAgentPercentage.AddAsync(commissionPercentage);
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

        [HttpPut]
        public async Task<ApiResponse<UICommissionAgentPercentage>> Update(UICommissionAgentPercentage uiCommissionPercentage)
        {
            var apiResponse = new ApiResponse<UICommissionAgentPercentage>();

            try
            {
                AccountApi.Core.CommissionAgentPercentage commissionPercentage = _IMapper.Map<AccountApi.Core.CommissionAgentPercentage>(uiCommissionPercentage);
                var data = await _unitOfWork.CommissionAgentPercentage.UpdateAsync(commissionPercentage);
                apiResponse.Success = true;

                UICommissionAgentPercentage stockinDataresults = _IMapper.Map<UICommissionAgentPercentage>(data);
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
                var data = await _unitOfWork.CommissionAgentPercentage.DeleteAsync(id);
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

        [HttpGet()]
        [Route("GetAllCommissionPercentage")]
        public async Task<List<UICommissionAgentPercentage>> GetAllCommissionPercentage()
        {
            List <UICommissionAgentPercentage> results = new List<UICommissionAgentPercentage>();
            try
            {
                var data = await _unitOfWork.CommissionAgentPercentage.GetAllCommissionPercentage();
                results = _IMapper.Map<List<UICommissionAgentPercentage>>(data);
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
