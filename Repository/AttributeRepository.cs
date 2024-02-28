using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
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
        public async Task<IEnumerable<Attribute>> GetAllAttributesAsync(AttributeParameters attributeParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(i => i.CreatedDate)
                .Skip((attributeParameters.PageNumber - 1) * attributeParameters.PageSize)
                .Take(attributeParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Attribute> GetAttributeAsync(int attributeId, bool trackChanges) =>
            await FindByCondition(i => i.AttributeId.Equals(attributeId), trackChanges).SingleOrDefaultAsync();

        public void CreateAttribute(Attribute attribute) => Create(attribute);

        public async Task<IEnumerable<Attribute>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.AttributeId), trackChanges).ToListAsync();

        public void DeleteAttribute(Attribute attribute) => Delete(attribute);

        #endregion

    }
}
