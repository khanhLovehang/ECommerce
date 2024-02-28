using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.CategoryExceptions
{
    public class CategoryCollectionBadRequest : BadRequestException
    {
        public CategoryCollectionBadRequest() : base("Category collection sent from a client is null.")
        {

        }
    }
}
