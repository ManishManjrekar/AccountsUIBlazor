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
    public class VendorController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;


        /// <summary>
        /// Initialize VendorController by injecting an object type of IUnitOfWork
        /// </summary>
        public VendorController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        [Route("GetAllVendor")]
        public async Task<List<UIVendor>> GetAll()
        {
            List<UIVendor> vendorList = new List<UIVendor>();

            try
            {
                var data = await _unitOfWork.Vendor.GetAllAsync();
                var sortedData = data.OrderByDescending(x => x.CreatedDate);
                vendorList = _IMapper.Map<List<UIVendor>>(sortedData);
                
            }
            catch (SqlException ex)
            {
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception:", ex);
            }

            return vendorList;
        }

        [HttpGet]
        [Route("GetAllVendorNames")]
        public async Task<List<VendorNames>> GetAllVendorNames()
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

        [HttpGet("{id}")]
        public async  Task<ApiResponse<Vendor>> GetById(int id)
        {

            var apiResponse = new ApiResponse<Vendor>();

            try
            {
                var data = await _unitOfWork.Vendor.GetByIdAsync(id);
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
        [Route("AddVendor")]
        public async Task<IActionResult> Add(UIVendor vendor)
        {
          
            var apiResponse = new ApiResponse<string>();
            Vendor Vendor = _IMapper.Map<Vendor>(vendor);
            Vendor.IsActive = true;

            try
            {
                var data = await _unitOfWork.Vendor.AddAsync(Vendor);               apiResponse.Success = true;
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

            return Ok(apiResponse);
        }

        [HttpPut]
        public async Task<ApiResponse<string>> Update(UIVendor uiVendor)
        {
            var apiResponse = new ApiResponse<string>();
            Vendor vendorData = _IMapper.Map<Vendor>(uiVendor);
            try
            {
                var data = await _unitOfWork.Vendor.UpdateAsync(vendorData);

                //UIVendor vendorDataResults = _IMapper.Map<UIVendor>(data);
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

                var data = await _unitOfWork.Vendor.GetDuplicateOrNot(firstName, lastName);
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
