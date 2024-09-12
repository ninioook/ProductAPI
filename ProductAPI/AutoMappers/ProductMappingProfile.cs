using AutoMapper;
using ProductAPI.Commands;
using ProductAPI.Models;

namespace ProductAPI.AutoMapppers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddProductModel, AddProductCommand>();
            CreateMap<UpdateProductModel, UpdateProductCommand>();
        }
    }
}