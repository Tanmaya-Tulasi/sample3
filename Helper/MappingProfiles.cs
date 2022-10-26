using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderDto>();
          
            CreateMap<ProductDto, Product>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<OrderDto, Order>();
           
            CreateMap<Product, ProductDto>();
            CreateMap<Customer, CustomerDto>();
           
        }
    }
}
