using Shared.RequestFeatures;
using Attribute = Entities.Models.Attribute;

namespace Contracts
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<Attribute>> GetAllAttributes(RequestParameters attributeParameters, bool trackChanges);

        Task<Attribute?> GetAttribute(Guid attributeId, bool trackChanges);

        void CreateAttribute(Attribute attribute);
    }
}
