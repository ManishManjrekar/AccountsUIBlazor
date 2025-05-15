using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Core.Entities;
using AccountApi.Logging;
//using AccountsUIBlazor.Data;
//using AccountsUIBlazor.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Accounts.Models.ApiResponse;
using Accounts.Models.UIModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : BaseApiController
    {
       

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        public SalesController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

      
        [HttpGet]
        public async Task<ApiResponse<List<Sales>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Sales>>();

            try
            {
                var data = await _unitOfWork.Sales.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
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

        [HttpGet("{id}")]
        public async  Task<ApiResponse<Sales>> GetById(int id)
        {

            var apiResponse = new ApiResponse<Sales>();

            try
            {
                var data = await _unitOfWork.Sales.GetByIdAsync(id);
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

        [HttpPost]
        [Route("AddSales")]
        public async Task<IActionResult> AddSales(UISalesPostDataModel uiSales)
        {
          
            var apiResponse = new ApiResponse<string>();
            Sales sales = _IMapper.Map<Sales>(uiSales);
            sales.Type = uiSales.Type.ToString();
           

            try
            {
                var data = await _unitOfWork.Sales.AddAsync(sales);
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

            return Ok(apiResponse);
        }

        //[HttpPost]
        //[Route("PostStockInsData")]
        //public async Task<IActionResult> PostStockInsData(UICalenderModel uICalenderModel)
        //{
        //    List<UISalesStockInData> sales = new List<UISalesStockInData>();
        //    //var apiResponse = new ApiResponse<string>();

        //    //customer.IsActive = true;

        //    try
        //    {
        //        var data = await _unitOfWork.StockIn.GetStockInDataAsperDates(
        //            uICalenderModel.FromDate.ToString(),
        //            uICalenderModel.FromDate.ToString());


        //        //sales.Add(new UISalesStockInData { LoadName = "load1", VendorId = 1, Quantity = 100, StockInId = 1 });
        //        //sales.Add(new UISalesStockInData { LoadName = "load2", VendorId = 2, Quantity = 700, StockInId = 2 });

        //        //sales = _IMapper.Map<List<UISalesStockInData>>(data);

        //        //apiResponse.Success = true;
        //        //apiResponse.Result = data;

        //    }
        //    catch (Exception ex)
        //    {
        //        //apiResponse.Success = false;
        //        //apiResponse.Message = ex.Message;
        //        Logger.Instance.Error("SQL Exception:", ex);
        //    }
        //    //catch (Exception ex)
        //    //{
        //    //    apiResponse.Success = false;
        //    //    apiResponse.Message = ex.Message;
        //    //    Logger.Instance.Error("Exception:", ex);
        //    //}

        //    return Ok(sales);
        //}

        [HttpGet]
        [Route("GetVendorId")]
        public async Task<int> GetVendorId(int id)
        {

            //var apiResponse = new ApiResponse<Sales>();
            //return 2;
            try
            {
                var data = await _unitOfWork.StockIn.GetVendorId(id);
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

            return 0;
        }
        [HttpPut]
        public async Task<ApiResponse<string>> Update(Sales sales)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Sales.UpdateAsync(sales);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            //catch (Exception ex)
            //{
            //    apiResponse.Success = false;
            //    apiResponse.Message = ex.Message;
            //    Logger.Instance.Error("Exception:", ex);
            //}

            return apiResponse;
        }

        [HttpDelete]
        public async Task<ApiResponse<string>> Delete(int id)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Customers.DeleteAsync(id);
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
        [Route("GetSalesDataAsPerStockInId")]
        public async Task<UISalesDto> GetSalesDataAsPerStockInId(int stockInId)
        {
            UISalesDto resultData = new UISalesDto();
            List<SalesDetailsDto> results = new List<SalesDetailsDto>();
            try
            {
                var Salesdata = await _unitOfWork.Sales.GetSalesDataAsPerStockInId(stockInId);
                resultData.salesDetailsList = _IMapper.Map<List<SalesDetailsDto>>(Salesdata);

                resultData.TotalStock = await _unitOfWork.StockIn.GetstockQuantity_ByStockInId(stockInId);
                resultData.TotalSalesDone = Salesdata.Select(p =>p.Quantity).Sum();
                resultData.TotalStockLeft = resultData.TotalStock - resultData.TotalSalesDone;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
              
                Logger.Instance.Error("Exception:", ex);
            }
            return resultData;
        }

        [HttpGet]
        [Route("GetSalesDataAsPerCustomerId")]
        public async Task<List<SalesDetailsDto>> GetSalesDataAsPerCustomerId(int customerId)
        {
            List<SalesDetailsDto> results = new List<SalesDetailsDto>();
            try
            {
                var data = await _unitOfWork.Sales.GetSalesDataAsPerCustomerId(customerId);
                results = _IMapper.Map<List<SalesDetailsDto>>(data);
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
