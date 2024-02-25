using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System.ComponentModel.Design;

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
        public async Task<PagedList<AttributeValue>> GetAttributeValuesAsync(Guid productId, AttributeValueParameters attributeValueParameters, bool trackChanges)
        {
            //Filter + Search
            var attributeValues = await FindByCondition(i => i.ProductId.Equals(productId) &&
                                                             (attributeValueParameters.AttributeId == -1 || attributeValueParameters.AttributeId == null || i.AttributeId.Equals(attributeValueParameters.AttributeId)) &&
                                                             (attributeValueParameters.Value == null || i.Value.Equals(attributeValueParameters.Value)) &&
                                                             (attributeValueParameters.SearchTerm == null || i.Value.Contains(attributeValueParameters.SearchTerm.Trim().ToLower()))
                                                             , trackChanges)
               
                .Sort(attributeValueParameters.OrderBy)
                .ToListAsync();

            return PagedList<AttributeValue>.ToPagedList(attributeValues, attributeValueParameters.PageNumber, attributeValueParameters.PageSize);

        }

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
