using AutoMapper;
using EcommerceProAPI.DTOs;
using EcommerceProAPI.Models;

namespace EcommerceProAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Product
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
            CreateMap<ProductCreateDto, Product>();

            // ✅ Category
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryReadDto>();

            CreateMap<CartItemCreateDto, CartItem>();

            CreateMap<CartItem, CartItemReadDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product!.Price));

            CreateMap<OrderItem, OrderItemDto>()
                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name));

            CreateMap<Order, OrderReadDto>();

            CreateMap<RatingCreateDto, Rating>();
            CreateMap<Rating, RatingReadDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User!.UserName));

            CreateMap<Favorite, FavoriteReadDto>()
    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name))
    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product!.Price));

        }
    }
}
