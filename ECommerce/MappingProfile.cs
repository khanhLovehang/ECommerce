using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AttributeValueDto;
using Shared.DataTransferObjects.CategoryDto;
using Shared.DataTransferObjects.ProductDto;

namespace ECommerce
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //the ForCtorParam method to specify the name of the parameter in the constructor that AutoMapper needs to map to
            //CreateMap<Company, CompanyDto>()
            //.ForCtorParam("FullAddress",
            //opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<User, UserDto>();

            //Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();

            //AttributeValue
            CreateMap<AttributeValue, AttributeValueDto>();
            CreateMap<AttributeValueForCreationDto, AttributeValue>();
            //The ReverseMap method is also going to configure this rule to execute reverse mapping if we ask for it.
            CreateMap<AttributeValueForUpdateDto, AttributeValue>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
