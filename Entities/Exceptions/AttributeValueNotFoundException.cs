using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AttributeValueNotFoundException : NotFoundException
    {
        public AttributeValueNotFoundException(int attributeValueId)
            : base($"Attribute value with id: {attributeValueId} doesn't exist in the database.")
        {

        }
    }
}
