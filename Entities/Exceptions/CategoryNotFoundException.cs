using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId)
            : base($"The Category with id: {categoryId} doesn't exist in the database.")
        {

        }
    }
}
