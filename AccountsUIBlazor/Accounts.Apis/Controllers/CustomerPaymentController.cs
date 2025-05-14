using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
//using AccountsUIBlazor.Data;
//using AccountsUIBlazor.Pages;
using Accounts.Models.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Accounts.Models.ApiResponse;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerPaymentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;


        /// <summary>
        /// Initialize StockInController by injecting an object type of IUnitOfWork
        /// </summary>
        public CustomerPaymentController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        public async Task<List<UICustomerPayment>> GetAll()
        {
            List<UICustomerPayment> results = new List<UICustomerPayment>();

            try
            {
                var data = await _unitOfWork.CustomerPaymentReceived.GetAllAsync();
                results = _IMapper.Map<List<UICustomerPayment>>(data);
               
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

        

        [HttpGet("{id}")]
        public async  Task<UICustomerPayment> GetById(int id)
        {
            UICustomerPayment results = null;
            try
            {
                var data = await _unitOfWork.CustomerPaymentReceived.GetByIdAsync(id);
                results = _IMapper.Map< UICustomerPayment > (data);
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

        

        [HttpPost]
        [Route("AddCustomerPayment")]
        public async Task<string> AddCustomerPayment(UICustomerPayment UICustomerPayment)
        {
            CustomerPaymentReceived custPayment = _IMapper.Map<CustomerPaymentReceived>(UICustomerPayment);
            try
            {
                custPayment.TypeOfTransaction = UICustomerPayment.TypeOfTransaction.ToString();
               
                var data = await _unitOfWork.CustomerPaymentReceived.AddAsync(custPayment);
                //results = _IMapper.Map<List<UICustomerPayment>>(data);
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
            return "success";
        }

        [HttpPut]
        public async Task<string> Update(UICustomerPayment UICustomerPayment)
        {
            try
            {
                CustomerPaymentReceived custPayment = _IMapper.Map<CustomerPaymentReceived>(UICustomerPayment);
                var data = await _unitOfWork.CustomerPaymentReceived.UpdateAsync(custPayment);
                //results = _IMapper.Map<List<UICustomerPayment>>(data);
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

            return "success";
        }

        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            try
            {
                var data = await _unitOfWork.Vendor.DeleteAsync(id);
                //results = _IMapper.Map<List<UICustomerPayment>>(data);
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

            return "success";
        }

        //For filling the grid details for customer payments completed
        [HttpGet]
        [Route("GetCustomerPaymentReceivedByCustomerId")]
        public async Task<List<UICustomerPayment>> GetAllCustomerPaymentById(int customerId)
        {
            List<UICustomerPayment> results = new List<UICustomerPayment>();
            try
            {
                 var data = await _unitOfWork.CustomerPaymentReceived.GetCustomerPaymentReceivedByCustomerId(customerId);
                results = _IMapper.Map<List<UICustomerPayment>>(data);
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

        //For filling the grid details for customer purchases from us..
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

        [HttpGet]
        [Route("GetPendingBalanceForCustomer")]
        public async Task<UICustomerPaymentMaster> GetPendingBalanceForCustomer(int customerId)
        {
            UICustomerPaymentMaster customerPaymentMasterDto = new UICustomerPaymentMaster();
            try
            {
                customerPaymentMasterDto.CustomerPurchases = await GetSalesDataAsPerCustomerId(customerId);
                customerPaymentMasterDto.CustomerPaymentsDone  = await GetAllCustomerPaymentById(customerId);
                customerPaymentMasterDto. BalanceAmountDue = customerPaymentMasterDto.CustomerPurchases.Select(e=>e.TotalAmount).Sum() - customerPaymentMasterDto.CustomerPaymentsDone.Select(e =>e.AmountPaid).Sum();
                

                //var data = await _unitOfWork.Sales.GetSalesDataAsPerCustomerId(customerId);
                //results = _IMapper.Map<List<SalesDetailsDto>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Exception:", ex);
            }
            return customerPaymentMasterDto;
        }

        //Added
        [HttpGet]
        [Route("GetPendingBalanceForCustomerWithinDates")]
        public async Task<UICustomerPaymentMaster> GetPendingBalanceForCustomerWithinDates(int customerId, DateTime fromDate, DateTime toDate)
        {
            UICustomerPaymentMaster customerPaymentMasterDto = new UICustomerPaymentMaster();
            try
            {
                customerPaymentMasterDto.CustomerPurchases = await GetSalesDataAsPerCustomerDates(customerId, fromDate, toDate);
                customerPaymentMasterDto.CustomerPaymentsDone = await GetAllCustomerPaymentByDates(customerId, fromDate, toDate);
                customerPaymentMasterDto.BalanceAmountDue = customerPaymentMasterDto.CustomerPurchases.Select(e => e.TotalAmount).Sum() - customerPaymentMasterDto.CustomerPaymentsDone.Select(e => e.AmountPaid).Sum();


                //var data = await _unitOfWork.Sales.GetSalesDataAsPerCustomerId(customerId);
                //results = _IMapper.Map<List<SalesDetailsDto>>(data);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Exception:", ex);
            }
            return customerPaymentMasterDto;
        }

        // added
        [HttpGet]
        [Route("GetSalesDataAsPerCustomerDates")]
        public async Task<List<SalesDetailsDto>> GetSalesDataAsPerCustomerDates(int customerId, DateTime fromDate, DateTime toDate)
        {
            List<SalesDetailsDto> results = new List<SalesDetailsDto>();
            try
            {
                var data = await _unitOfWork.Sales.GetSalesDataAsPerCustomerDates(customerId, fromDate, toDate);
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

        // Added
        [HttpGet]
        [Route("GetAllCustomerPaymentByDates")]
        public async Task<List<UICustomerPayment>> GetAllCustomerPaymentByDates(int customerId, DateTime fromDate, DateTime toDate)
        {
            List<UICustomerPayment> results = new List<UICustomerPayment>();
            try
            {
                var data = await _unitOfWork.CustomerPaymentReceived.GetAllCustomerPaymentByDates(customerId, fromDate, toDate);
                results = _IMapper.Map<List<UICustomerPayment>>(data);
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
