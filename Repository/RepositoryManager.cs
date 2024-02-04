using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        #region properties
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IProductRepository> _productRepository;

        #endregion

        #region constructor
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));

        }
        #endregion

        #region methods
        public IUserRepository User => _userRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
        #endregion

    }
}
