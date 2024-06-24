using AccountApi.Core;
using AccountApi.Core.Entities;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

namespace AccountMobileAPI.UIModels
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UICustomer, Customer>().ReverseMap();
            CreateMap<UICustomerNames, Customer>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.CustomerName)).ReverseMap();

      


        }
    }
}
