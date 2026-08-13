using AutoMapper;
using Integration.OrderService.Data.Models;
using Integration.OrderService.DTOs;

namespace Integration.OrderService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
