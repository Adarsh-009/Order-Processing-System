using AutoMapper;

namespace OrderProcessingSystem.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
                CreateMap<Models.Customer, DTO.CustomerDto>().ReverseMap();
                CreateMap<Models.Order, DTO.OrderDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts))
                .ReverseMap()
                .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.Products));
            CreateMap<Models.OrderProduct, DTO.OrderProductDto>().ReverseMap();
        }
    }
}
