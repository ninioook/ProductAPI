using AutoMapper;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Models;

namespace ProductAPI.AutoMappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<AddOrderModel, AddOrderCommand>();
            CreateMap<AddOrderCommand, Order>();
        }
    }
}