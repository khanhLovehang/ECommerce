using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ProductCollectionBadRequest : BadRequestException
    {
        public ProductCollectionBadRequest() : base("Product collection sent from a client is null.")
        {

        }
    }
}
