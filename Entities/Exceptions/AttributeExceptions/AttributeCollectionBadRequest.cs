using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions.Base;

namespace Entities.Exceptions.AttributeExceptions
{
    public class AttributeCollectionBadRequest : BadRequestException
    {
        public AttributeCollectionBadRequest() : base("Attribute collection sent from a client is null.")
        {

        }
    }
}
