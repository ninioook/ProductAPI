using AutoMapper;
using ProductAPI.Commands;
using ProductAPI.Dtos;
using ProductAPI.Entities;
using ProductAPI.Models;

namespace ProductAPI.AutoMapppers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddProductModel, AddProductCommand>();
            CreateMap<UpdateProductModel, UpdateProductCommand>();
            CreateMap<AddProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}