using AccountApi.Core;
using AccountApi.Core.Entities;
using AutoMapper;

namespace AccountsUIBlazor.UIModels
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UICustomer, Customer>().ReverseMap();
            CreateMap<UICustomerNames, Customer>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.CustomerName)).ReverseMap();

            CreateMap<UIVendor, Vendor>().ReverseMap();
           // CreateMap<VendorNames, Vendor>().ReverseMap();
            CreateMap<VendorNames,Vendor > ()
            .ForMember(dest => dest.VendorId, opt => opt.MapFrom(src => src.VendorId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.VendorName)).ReverseMap();


            CreateMap<UISales, Sales>().ReverseMap();
            CreateMap<UISalesStockInData, StockIn> ().ReverseMap();
            CreateMap<SalesDetailsDto, SalesDetails>().ReverseMap();

            CreateMap<UISalesPostDataModel,Sales > ().ReverseMap();
            


            CreateMap<UIStockIn, UISalesStockInData>().ReverseMap();
            CreateMap<UIStockIn, StockIn>().ReverseMap();
            CreateMap<SalesDetailsDto, SalesDetails>().ReverseMap();
            CreateMap<CustomerPaymentReceived, UICustomerPayment>().ReverseMap();
            CreateMap<VendorPaymentDetails, UIVendorPaymentDto>().ReverseMap();
            CreateMap<VendorPayments, UIVendorPayment>()
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();



            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();


        }
    }
}
