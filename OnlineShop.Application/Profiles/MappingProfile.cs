using AutoMapper;
using OnlineShop.Application.DTOs.Category;
using OnlineShop.Application.DTOs.Product;
using OnlineShop.Application.DTOs.User;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
