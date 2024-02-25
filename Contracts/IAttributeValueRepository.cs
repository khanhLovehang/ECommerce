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
        Task<PagedList<AttributeValue>> GetAttributeValuesAsync(Guid productId, AttributeValueParameters attributeValueParameters, bool trackChanges);
        Task<AttributeValue> GetAttributeValueAsync(Guid productId, int id, bool trackChanges);
        void CreateAttributeValueForProduct(Guid productId, AttributeValue attributeValue);
        void DeleteAttributeValue(AttributeValue attributeValue);

    }
}
