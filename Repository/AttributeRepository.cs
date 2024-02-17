using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Attribute = Entities.Models.Attribute;

namespace Repository
{
    public class AttributeRepository : RepositoryBase<Attribute>, IAttributeRepository
    {
        #region properties
        #endregion

        #region constructor
        public AttributeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        #endregion

        #region methods
        public async Task<IEnumerable<Attribute>> GetAllAttributes(RequestParameters attributeParameters, bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(i => i.AttributeName).ToListAsync();
        }

        public async Task<Attribute?> GetAttribute(Guid id, bool trackChanges)
        {
            return await FindByCondition(i => i.AttributeId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateAttribute(Attribute attribute) => Create(attribute);

        #endregion

    }
}
