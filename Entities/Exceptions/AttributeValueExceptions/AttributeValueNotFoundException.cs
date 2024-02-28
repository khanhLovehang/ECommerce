using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.AttributeValueExceptions
{
    public class AttributeValueNotFoundException : NotFoundException
    {
        public AttributeValueNotFoundException(int attributeValueId)
            : base($"Attribute value with id: {attributeValueId} doesn't exist in the database.")
        {

        }
    }
}
