using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        #region properties
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IAttributeRepository> _attributeRepository;
        private readonly Lazy<IAttributeValueRepository> _attributeValueRepository;

        #endregion

        #region constructor
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _attributeRepository = new Lazy<IAttributeRepository>(() => new AttributeRepository(repositoryContext));
            _attributeValueRepository = new Lazy<IAttributeValueRepository>(() => new AttributeValueRepository(repositoryContext));

        }
        #endregion

        #region methods
        public IUserRepository User => _userRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public IAttributeRepository Attribute => _attributeRepository.Value;
        public IAttributeValueRepository AttributeValue => _attributeValueRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        #endregion

    }
}
