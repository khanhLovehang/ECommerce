using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.RequestFeatures.Base;

namespace Shared.RequestFeatures
{
    public class AttributeValueParameters : RequestParameters
    {
        public AttributeValueParameters() => OrderBy = "attributeId";

        public int? AttributeId { get; set; }
        public string? Value { get; set; }
        public string? SearchTerm { get; set; }
    }
}
