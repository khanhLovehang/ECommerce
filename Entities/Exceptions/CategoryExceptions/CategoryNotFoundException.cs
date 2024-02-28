using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.CategoryExceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId)
            : base($"The Category with id: {categoryId} doesn't exist in the database.")
        {

        }
    }
}
