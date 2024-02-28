using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.ProductExceptions
{
    public class ProductCollectionBadRequest : BadRequestException
    {
        public ProductCollectionBadRequest() : base("Product collection sent from a client is null.")
        {

        }
    }
}
