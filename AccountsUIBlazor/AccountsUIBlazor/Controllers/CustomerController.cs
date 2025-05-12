using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountsUIBlazor.Data;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountsUIBlazor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
       

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        //private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private static readonly ILog _log = LogManager.GetLogger(typeof(CustomerController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public CustomerController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

      /// <summary>
      /// Get customer data 
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<List<UICustomer>> GetAll()
        {
            _log.Info($"Method : {nameof(GetAll)} - Started ");

            var apiResponse = new ApiResponse<List<UICustomer>>();
            List<UICustomer> customerList = new List<UICustomer>();
            try
            {
                _log.Info($"Method : {nameof(GetAll)} - try block Started ");
                var data = await _unitOfWork.Customers.GetAllAsync();
                customerList = _IMapper.Map<List<UICustomer>>(data);
                apiResponse.Success = true;
                apiResponse.Result = customerList;              
                _log.Info($"Method : {nameof(GetAll)} - try block Completed ");
            }
            catch (SqlException ex)
            {
                _log.Error($"Method : {nameof(GetAll)} SQL Error : {ex.Message}");
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;               
            }
            catch (Exception ex)
            {
                _log.Error($"Method : {nameof(GetAll)} Error : message {ex.Message}");
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;               
            }
            _log.Info($"Method : {nameof(GetAll)} - Completed ");

            return customerList;
        }

        [HttpGet]
        [Route("GetAllCustomerNames")]
        public async Task<List<UICustomerNames>> GetAllCustomerNames()
        {
            var customerNames = new List<UICustomerNames>();
            try
            {
                var data = await _unitOfWork.Customers.GetAllAsync();
                customerNames = _IMapper.Map<List<UICustomerNames>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Exception:", ex);
            }
            return customerNames;
        }

        [HttpGet("{id}")]
        public async  Task<ApiResponse<UICustomer>> GetById(int id)
        {

            var apiResponse = new ApiResponse<UICustomer>();

            try
            {
                var data = await _unitOfWork.Customers.GetByIdAsync(id);
                UICustomer customer = _IMapper.Map<UICustomer>(data);
                apiResponse.Success = true;
                apiResponse.Result = customer;
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

        [HttpPost]
        //[Route("AddCustomer")]
        public async Task<IActionResult> Add(UICustomer Customer)
        {
          
            var apiResponse = new ApiResponse<string>();
            Customer customer = _IMapper.Map<Customer>(Customer);
            customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.Customers.AddAsync(customer);
                //UICustomer customerdata = _IMapper.Map<UICustomer>(data);
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

        [HttpPut]
        public async Task<ApiResponse<UICustomer>> Update(UICustomer Customer)
        {
            var apiResponse = new ApiResponse<UICustomer>();
            Customer customerdata = _IMapper.Map<Customer>(Customer);
            try
            {
                var data = await _unitOfWork.Customers.UpdateAsync(customerdata);
                UICustomer customerUI = _IMapper.Map<UICustomer>(data);
                apiResponse.Success = true;
                apiResponse.Result = customerUI;
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
                var data = await _unitOfWork.Customers.DeleteAsync(id);
                //UICustomer customerdata = _IMapper.Map<UICustomer>(data);
                apiResponse.Success = true;
                apiResponse.Result = data.ToString();
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
        [Route("GetDuplicateOrNot")]
        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {

            // var apiResponse = new ApiResponse<AccountApi.Core.StockIn>();

            try
            {

                var data = await _unitOfWork.Customers.GetDuplicateOrNot(firstName, lastName);
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
