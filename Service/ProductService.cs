using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        #region properties

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region methods
        public IEnumerable<ProductDto> GetAllProducts(bool trackChanges)
        {
            var products = _repository.Product.GetAllProducts(trackChanges);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products); // Use auto mapper
            return productsDto;
        }

        public ProductDto GetProduct(Guid productId, bool trackChanges)
        {
            var product = _repository.Product.GetProduct(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public ProductDto CreateProduct(ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Product>(product);

            _repository.Product.CreateProduct(productEntity);
            _repository.Save();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return productToReturn;
        }

        #endregion
    }
}
