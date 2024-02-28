using AutoMapper;
using Contracts.Manager;
using Service.Contracts;
using Service.Contracts.Manager;

namespace Service.Manager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAttributeService> _attributeService;
        private readonly Lazy<IAttributeValueService> _attributeValueService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IReviewService> _reviewService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
            _attributeService = new Lazy<IAttributeService>(() => new AttributeService(repositoryManager, logger, mapper));
            _attributeValueService = new Lazy<IAttributeValueService>(() => new AttributeValueService(repositoryManager, logger, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, logger, mapper));
        }

        public IUserService UserService => _userService.Value;
        public IProductService ProductService => _productService.Value;
        public IAttributeService AttributeService => _attributeService.Value;
        public IAttributeValueService AttributeValueService => _attributeValueService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IReviewService ReviewService => _reviewService.Value;
    }
}
