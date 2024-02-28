using Entities.Models;
using Shared.RequestFeatures;
using Attribute = Entities.Models.Attribute;

namespace Contracts
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<Attribute>> GetAllAttributesAsync(AttributeParameters attributeParameters, bool trackChanges);
        Task<Attribute> GetAttributeAsync(int id, bool trackChanges);
        void CreateAttribute(Attribute attribute);
        Task<IEnumerable<Attribute>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteAttribute(Attribute attribute);
    }
}
