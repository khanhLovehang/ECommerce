using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.AttributeExceptions
{
    public class AttributeNotFoundException : NotFoundException
    {
        public AttributeNotFoundException(int attributeId)
            : base($"The Attribute with id: {attributeId} doesn't exist in the database.")
        {

        }
    }
}
