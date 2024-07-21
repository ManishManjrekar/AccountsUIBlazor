using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountAPIGateway.Data;
using AccountAPIGateway.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountAPIGateway.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VendorPaymentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;


        /// <summary>
        /// Initialize StockInController by injecting an object type of IUnitOfWork
        /// </summary>
        public VendorPaymentController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        public async Task<ApiResponse<List<VendorPayments>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<VendorPayments>>();

            try
            {
                var data = await _unitOfWork.VendorPayment.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
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
        [Route("GetVendorList")]
        public async Task<IActionResult> GetVendorList()
        {

            //var apiResponse = new ApiResponse<List<VendorPayment>>();
            //UIStockIn vendorNames = new UIStockIn();
            //Vendor.IsActive = true;
            var Result = new List<VendorList>();
            try
            {
                 Result = new List<VendorList> { new VendorList { VendorId=1, VendorName="ven"},
                    new VendorList { VendorId = 2, VendorName = "ven1" } };

                //  var data = await _unitOfWork.Vendor.GetAllAsync();
                //var names = _IMapper.Map<List<VendorNames>>(data);
                
                //apiResponse.Success = true;
               // apiResponse.Result = names.ToList();

            }
            catch (Exception ex)
            {
               // apiResponse.Success = false;
              //  apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            //catch (Exception ex)
            //{
            //    apiResponse.Success = false;
            //    apiResponse.Message = ex.Message;
            //    Logger.Instance.Error("Exception:", ex);
            //}

            return Ok(Result);
        }

        [HttpGet("{id}")]
        public async  Task<ApiResponse<VendorPayments>> GetById(int id)
        {

            var apiResponse = new ApiResponse<VendorPayments>();

            try
            {
                var data = await _unitOfWork.VendorPayment.GetByIdAsync(id);
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
        [Route("AddVendorPayment")]
        public async Task<string> AddVendorPayment(UIVendorPayment UIVendorPayment)
        {
          
            VendorPayments vendorPayment = _IMapper.Map<VendorPayments>(UIVendorPayment);
            vendorPayment.TypeOfTransaction = UIVendorPayment.TypeOfTransaction.ToString();

            try
            {
                var data = await _unitOfWork.VendorPayment.AddAsync(vendorPayment);
               
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("exception:", ex);
            }
            return "success";
        }

        [HttpPut]
        public async Task<ApiResponse<string>> Update(UIVendorPayment vendorPayment)
        {
            var apiResponse = new ApiResponse<string>();
            VendorPayments vendorpayment = _IMapper.Map<VendorPayments>(vendorPayment);
            try
            {
                var data = await _unitOfWork.VendorPayment.UpdateAsync(vendorpayment);
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
                var data = await _unitOfWork.VendorPayment.DeleteAsync(id);
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
        [Route("GetVendorPaymentAsPerStockInId")]
        public async Task<List<UIVendorPaymentDto>> GetVendorPaymentAsPerStockInId(int stockInId)
        {
            var results = new List<UIVendorPaymentDto>();
            try
            {
                var data = await _unitOfWork.VendorPayment.GetVendorPaymentAsPerStockInId(stockInId);
                results = _IMapper.Map<List<UIVendorPaymentDto>>(data);
               
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
        [Route("GetVendorPaymentDetails")]
        public async Task<VendorPaymentMaster> GetVendorPaymentDetails(int stockInId)
        {
            VendorPaymentMaster results = new VendorPaymentMaster();
            try 
            {
                //Sales Details as per StockInId
                var salesDetails = await _unitOfWork.Sales.GetSalesDataAsPerStockInId(stockInId);
                results.SalesDetailsList = _IMapper.Map<List<SalesDetailsDto>>(salesDetails);

                var vendorPaymentDetails= await _unitOfWork.VendorPayment.GetVendorPaymentAsPerStockInId(stockInId);
                results.VendorPaymentList = _IMapper.Map<List<UIVendorPaymentDto>>(vendorPaymentDetails);

                results.TotalSalesAmount = results.SalesDetailsList.Select(p => p.TotalAmount).Sum();
                results.TotalVendorPaymentPaid = results.VendorPaymentList.Select(p => p.AmountPaid).Sum();
                results.BalanceAmount = results.SalesDetailsList.Select(p => p.TotalAmount).Sum() - results.VendorPaymentList.Select(p => p.AmountPaid).Sum();
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
