using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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

        /// <summary>
        /// Lấy all sản phẩm
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await _repository.Product.GetAllProducts(productParameters, trackChanges);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products); // Use auto mapper
            return productsDto;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        public async Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges)
        {
            var product = await _repository.Product.GetProduct(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductDto> CreateProductAsync(ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Product>(product);

            _repository.Product.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return productToReturn;
        }

        #endregion
    }
}
