using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountsUIBlazor.Data;
using AccountsUIBlazor.Pages;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountsUIBlazor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class StockInController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public StockInController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        [Route("GetAllStockIns")]
        public async Task<List<UIStockIn>> GetAllStockIns()
        {
            var stockInList = new List<UIStockIn>();
            try
            {
                var data = await _unitOfWork.StockIn.GetAllAsync();
                stockInList = _IMapper.Map<List<UIStockIn>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                
                Logger.Instance.Error("Exception:", ex);
            }

            return stockInList;
        }

        [HttpGet]
        [Route("GetVendorNames")]
        public async Task<List<VendorNames>> GetVendorList()
        {
            var vendorNames = new List<VendorNames>();
            try
            {
                 var data = await _unitOfWork.Vendor.GetAllAsync();
                vendorNames = _IMapper.Map<List<VendorNames>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
             
                Logger.Instance.Error("Exception:", ex);
            }
            return vendorNames;
        }

        [HttpPost]
        [Route("PostStockInsAsPerVendorId")]
        public async Task<List<UISalesStockInData>> PostStockInsAsPerVendorId(UIVendorCalenderModel UiCalenderModel)
        {
            List<UISalesStockInData> stockInData = new List<UISalesStockInData>();

            try
            {
                var data = await _unitOfWork.StockIn.GetStockInDataAsperDates(
                   UiCalenderModel.FromDate.ToString("yyyy-MM-dd"),
                    UiCalenderModel.ToDate.ToString("yyyy-MM-dd"), UiCalenderModel.VendorId);
                stockInData = _IMapper.Map<List<UISalesStockInData>>(data);

                

            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return stockInData;
        }

        [HttpPost]
        [Route("PostStockInsAsPerDates")]
        public async Task<List<UISalesStockInData>> PostStockInsAsPerDates(UICalenderModel uICalenderModel)
        {
            List<UISalesStockInData> sales = new List<UISalesStockInData>();
            try
            {
                var data = await _unitOfWork.StockIn.GetStockInAsperDates(
                    uICalenderModel.FromDate.ToString("yyyy-MM-dd"),
                    uICalenderModel.ToDate.ToString("yyyy-MM-dd"));
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

        [HttpGet]
        [Route("GetVendorLoadCount")]
        public async Task<int> GetVendorLoadCount(int vendorid,string createdDate)
        {

           // var apiResponse = new ApiResponse<AccountApi.Core.StockIn>();

            try
            {
                 
                 var data = await _unitOfWork.StockIn.GetVendorLoadCount(vendorid, createdDate);
                return data+1;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return 0;
        }

        [HttpPost]
        [Route("AddStockIn")]
        public async Task<IActionResult> Add(UIStockIn stockin)
        {
          
            var apiResponse = new ApiResponse<UIStockIn>();
            AccountApi.Core.StockIn stockinData = _IMapper.Map<AccountApi.Core.StockIn>(stockin);
            //Vendor.IsActive = true;

            try
            {
                var data = await _unitOfWork.StockIn.AddAsync(stockinData);
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


        [HttpGet]
        [Route("GetDuplicateOrNot")]
        public async Task<bool> GetDuplicateOrNot(int vendorid, string createdDate,string loadName)
        {

            // var apiResponse = new ApiResponse<AccountApi.Core.StockIn>();

            try
            {

                var data = await _unitOfWork.StockIn.GetDuplicateOrNot(vendorid, createdDate, loadName);
                return data;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return false;
        }
    }
}
