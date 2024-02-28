using Contracts;
using Contracts.Manager;
using Repository.Context;

namespace Repository.Manager
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        #region properties
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IAttributeRepository> _attributeRepository;
        private readonly Lazy<IAttributeValueRepository> _attributeValueRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;

        #endregion

        #region constructor
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _attributeRepository = new Lazy<IAttributeRepository>(() => new AttributeRepository(repositoryContext));
            _attributeValueRepository = new Lazy<IAttributeValueRepository>(() => new AttributeValueRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(repositoryContext));

        }
        #endregion

        #region methods
        public IUserRepository User => _userRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public IAttributeRepository Attribute => _attributeRepository.Value;
        public IAttributeValueRepository AttributeValue => _attributeValueRepository.Value;
        public ICategoryRepository Category => _categoryRepository.Value;
        public IReviewRepository Review => _reviewRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        #endregion

    }
}
