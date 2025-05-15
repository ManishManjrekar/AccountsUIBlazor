using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using Accounts.Models.ApiResponse;
using Accounts.Models.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommissionEarnedController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public CommissionEarnedController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        [Route("PostCommissionEarnedAsPerDate")]
        public async Task<UICommissionEarnedMaster> PostStockInsAsPerVendorId(UIVendorCalenderModel UiCalenderModel)
        {
            UICommissionEarnedMaster commissionEarnedMaster =new UICommissionEarnedMaster();

            try
            {
                var data = await _unitOfWork.CommissionEarned.GetCommisionEarnedList_ForA_Date(
                   UiCalenderModel.FromDate.ToString("yyyy-MM-dd"));

                commissionEarnedMaster.UICommissionEarnedList = _IMapper.Map<List<UICommissionEarnedGridDetails>>(data);

                commissionEarnedMaster.CommissionEarned_Sum = await _unitOfWork.CommissionEarned.GetCommisionEarnedSum_ForA_Date(
                   UiCalenderModel.FromDate.ToString("yyyy-MM-dd"));

            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return commissionEarnedMaster;
        }

        [HttpPost]
        [Route("PostCommissionEarnedBetweenDates")]
        public async Task<UICommissionEarnedMaster> PostCommissionEarned_AsPer_Between_Dates(UIVendorCalenderModel UiCalenderModel)
        {
            UICommissionEarnedMaster commissionEarnedMaster = new UICommissionEarnedMaster();
            try
            {
                var data = await _unitOfWork.CommissionEarned.GetCommisionEarnedList_Between_Dates(
                   UiCalenderModel.FromDate.ToString("yyyy-MM-dd"), UiCalenderModel.ToDate.ToString("yyyy-MM-dd"));

                commissionEarnedMaster.UICommissionEarnedList = _IMapper.Map<List<UICommissionEarnedGridDetails>>(data);
                commissionEarnedMaster.CommissionEarned_Sum = await _unitOfWork.CommissionEarned.GetCommisionEarnedSum_Between_Dates(
                                                              UiCalenderModel.FromDate.ToString("yyyy-MM-dd"), UiCalenderModel.ToDate.ToString("yyyy-MM-dd"));
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return commissionEarnedMaster;
        }

        [HttpGet("{id}")]
        public async  Task<ApiResponse<UIStockIn>> GetById(int id)
        {

            var apiResponse = new ApiResponse<UIStockIn>();

            try
            {
                var data = await _unitOfWork.StockIn.GetByIdAsync(id);
                apiResponse.Success = true;
                UIStockIn stockinData = _IMapper.Map<UIStockIn>(data);
                apiResponse.Result = stockinData;
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

      
        [HttpPut]
        public async Task<ApiResponse<UICommissionEarnedGridDetails>> Update(UICommissionEarnedGridDetails uIStockIn)
        {
            var apiResponse = new ApiResponse<UICommissionEarnedGridDetails>();

            try
            {
                AccountApi.Core.CommissionEarned commissionEarned = _IMapper.Map<AccountApi.Core.CommissionEarned>(uIStockIn);
                var data = await _unitOfWork.CommissionEarned.UpdateAsync(commissionEarned);
                apiResponse.Success = true;

                UICommissionEarnedGridDetails commissionUpdatedData = _IMapper.Map<UICommissionEarnedGridDetails>(data);
                apiResponse.Result = commissionUpdatedData;
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
                var data = await _unitOfWork.CommissionEarned.DeleteAsync(id);
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
