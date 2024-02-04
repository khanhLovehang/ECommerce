using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserDto(Guid UserId, string UserName, string Email);
    //public record ProductDto(Guid ProductId, string Sku, string ProductName, decimal? Price, decimal? OldPrice, int CategoryId, int BrandId, string? ShortDescription, string? Description);
}
