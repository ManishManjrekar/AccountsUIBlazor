using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
using AccountsUIBlazor.Data;
using AccountsUIBlazor.Pages;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountsUIBlazor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerBalanceCarryForwardController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;


        /// <summary>
        /// Initialize StockInController by injecting an object type of IUnitOfWork
        /// </summary>
        public CustomerBalanceCarryForwardController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        public async Task<List<UICustomerBalanceCarryForward>> GetAll()
        {
            List<UICustomerBalanceCarryForward> results = new List<UICustomerBalanceCarryForward>();

            try
            {
                var data = await _unitOfWork.CustomerPaymentReceived.GetAllAsync();
                results = _IMapper.Map<List<UICustomerBalanceCarryForward>>(data);
               
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

        // this method is used for showing all records of Carry forward records for a given customer
        [HttpGet()]
        [Route("GetCarrryForwardDataByCustomerId")]
        public async  Task<MasterCustomerBalanceCarryForwardGridData> GetCarrryForwardDataByCustomerId(int id)
        {
            MasterCustomerBalanceCarryForwardGridData results = new MasterCustomerBalanceCarryForwardGridData();
            try
            {
                var data = await _unitOfWork.CustomerBalanceCarryForward.GetCarrryForwardDataByCustomerId(id);
                var res = _IMapper.Map<List<UICustomerBalanceCarryForwardGridData>> (data);
                results.CarryForwardAmountList = res;
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
        [Route("AddCustomerBalanceCarryForward")]
        public async Task<string> AddCustomerBalanceCarryForward(UICustomerBalanceCarryForward uiCustomerBalanceCarryForward)
        {
            AccountApi.Core.CustomerBalanceCarryForward customerBalanceCarryForward = _IMapper.Map<AccountApi.Core.CustomerBalanceCarryForward>(uiCustomerBalanceCarryForward);
            try
            {
                var data = await _unitOfWork.CustomerBalanceCarryForward.AddAsync(customerBalanceCarryForward);
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

        


    }
}
