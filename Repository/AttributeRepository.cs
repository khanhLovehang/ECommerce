using Attribute = Entities.Models.Attribute;

namespace Repository
{
    public class AttributeRepository : RepositoryBase<Attribute>
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
        public IEnumerable<Attribute> GetAllAttributes(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(i => i.AttributeName).ToList();
        }

        public Attribute? GetAttribute(Guid id, bool trackChanges)
        {
            return FindByCondition(i => i.AttributeId.Equals(id), trackChanges).SingleOrDefault();
        }

        public void CreateAttribute(Attribute attribute) => Create(attribute);

        #endregion

    }
}
