using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAttributeValueRepository
    {

        Task<IEnumerable<AttributeValue>> GetAttributesValue(Guid productId, bool trackChanges);
        Task<AttributeValue> GetAttributeValue(Guid productId, int id, bool trackChanges);

        void CreateAttributeValueForProduct(Guid productId, AttributeValue attributeValue);
    }
}
