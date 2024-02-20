using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
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

        /// <summary>
        /// Get all product
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
        /// Get product detail
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        public async Task<ProductDto> GetProductAsync(Guid id, bool trackChanges)
        {
            var product = await _repository.Product.GetProduct(id, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(id);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        /// <summary>
        /// Add product
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="IdParametersBadRequestException"></exception>
        /// <exception cref="CollectionByIdsBadRequestException"></exception>
        public async Task<IEnumerable<ProductDto>> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var productEntities = await _repository.Product.GetByIds(ids, trackChanges);

            if (ids.Count() != productEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return companiesToReturn;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCollection"></param>
        /// <returns></returns>
        /// <exception cref="ProductCollectionBadRequest"></exception>
        public async Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollection(IEnumerable<ProductForCreationDto> productCollection)
        {
            if (productCollection is null)
                throw new ProductCollectionBadRequest();

            var productEntities = _mapper.Map<IEnumerable<Product>>(productCollection);

            foreach (var product in productEntities)
            {
                _repository.Product.CreateProduct(product);
            }
            await _repository.SaveAsync();

            var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

            var ids = string.Join(",", productCollectionToReturn.Select(c => c.ProductId));

            return (products: productCollectionToReturn, ids: ids);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        public async Task DeleteProduct(Guid productId, bool trackChanges)
        {
            var product = await _repository.Product.GetProduct(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            await _repository.Product.DeleteProduct(product);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productForUpdate"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        public async Task UpdateProduct(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges)
        {
            var productEntity = await _repository.Product.GetProduct(productId, trackChanges);
            
            if (productEntity is null)
                throw new ProductNotFoundException(productId);

            _mapper.Map(productForUpdate, productEntity);

            await _repository.SaveAsync();
        }
        #endregion
    }
}
