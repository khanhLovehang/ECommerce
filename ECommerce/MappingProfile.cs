using AutoMapper;
using Entities;
using Shared.DataTransferObjects;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();

        }
    }
}
