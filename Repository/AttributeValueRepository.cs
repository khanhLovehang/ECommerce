using Contracts;
using Entities.Models;

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
        public List<AttributeValue> GetListAttributeValueByProductId(Guid productId, bool trackChanges) {
            return FindByCondition(i => i.ProductId.Equals(productId), trackChanges).ToList();
        }
        #endregion
    }
}
