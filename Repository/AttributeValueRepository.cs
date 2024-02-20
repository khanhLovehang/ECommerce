using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AttributeValueRepository : RepositoryBase<AttributeValue>, IAttributeValueRepository
    {
        #region properties
        #endregion

        #region properties
        public AttributeValueRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        #endregion

        #region methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AttributeValue>> GetAttributeValuesAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(i => i.ProductId.Equals(productId), trackChanges).OrderBy(i => i.AttributeId).ToListAsync();

        public async Task<AttributeValue> GetAttributeValueAsync(Guid productId, int id, bool trackChanges) =>
            await FindByCondition(i => i.ProductId.Equals(productId) && i.AttributeValueId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateAttributeValueForProduct(Guid productId, AttributeValue attributeValue)
        {
            attributeValue.ProductId = productId;
            Create(attributeValue);
        }

        public void DeleteAttributeValue(AttributeValue attributeValue) => Delete(attributeValue);




        #endregion
    }
}
