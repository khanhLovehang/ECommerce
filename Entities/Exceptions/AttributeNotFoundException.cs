using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AttributeNotFoundException : NotFoundException
    {
        public AttributeNotFoundException(Guid attributeId)
            : base($"The Attribute with id: {attributeId} doesn't exist in the database.")
        {

        }
    }
}
