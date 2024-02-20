using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AttributeValueService : IAttributeValueService
    {
        #region properties

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public AttributeValueService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get attribute value
        /// </summary>
        /// <param name="AttributeValueId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="AttributeValueNotFoundException"></exception>
        public async Task<IEnumerable<AttributeValueDto>> GetAttributeValues(Guid productId, bool trackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributesValueFromDb = await _repository.AttributeValue.GetAttributeValuesAsync(productId, trackChanges);

            var attributesValueDto = _mapper.Map<IEnumerable<AttributeValueDto>>(attributesValueFromDb);

            return attributesValueDto;
        }

        public async Task<AttributeValueDto> GetAttributeValue(Guid productId, int id, bool trackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueFromDb = await _repository.AttributeValue.GetAttributeValueAsync(productId, id, trackChanges);
            if (attributeValueFromDb is null)
                throw new AttributeValueNotFoundException(id);

            var attributeValue = _mapper.Map<AttributeValueDto>(attributeValueFromDb);

            return attributeValue;
        }

        /// <summary>
        /// Add value for attribute and product
        /// </summary>
        /// <param name="AttributeValue"></param>
        /// <returns></returns>
        public async Task<AttributeValueDto> CreateAttributeValueForProductAsync(Guid productId, AttributeValueForCreationDto attributeValueForCreation, bool trackChanges)
        {

            var product = await _repository.Product.GetProductAsync(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueEntity = _mapper.Map<AttributeValue>(attributeValueForCreation);

            _repository.AttributeValue.CreateAttributeValueForProduct(productId, attributeValueEntity);
            await _repository.SaveAsync();

            var attributeValueToReturn = _mapper.Map<AttributeValueDto>(attributeValueEntity);

            return attributeValueToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="AttributeValueNotFoundException"></exception>
        public async Task DeleteAttributeValueForProduct(Guid productId, int id, bool trackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueForProduct = await _repository.AttributeValue.GetAttributeValueAsync(productId, id, trackChanges);

            if (attributeValueForProduct is null)
                throw new AttributeValueNotFoundException(id);

            _repository.AttributeValue.DeleteAttributeValue(attributeValueForProduct);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="attributeValueForUpdate"></param>
        /// <param name="proTrackChanges"></param>
        /// <param name="attrTrackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="AttributeValueNotFoundException"></exception>
        public async Task UpdateAttributeValueForProduct(Guid productId, int id
            , AttributeValueForUpdateDto attributeValueForUpdate, bool proTrackChanges, bool attrTrackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, proTrackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueEntity = await _repository.AttributeValue.GetAttributeValueAsync(productId, id, attrTrackChanges);
            if (attributeValueEntity is null)
                throw new AttributeValueNotFoundException(id);

            // We are mapping from the attributeValueForUpdate object 
            // (we will change just the property in a request) to the
            // attributeValueEntity — thus changing the state of the attributeValueEntity
            // object to Modified.
            _mapper.Map(attributeValueForUpdate, attributeValueEntity);

            // Because our entity has a modified state, it is enough to call the SaveAsync
            // method without any additional update actions.
            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="proTrackChanges"></param>
        /// <param name="attrTrackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="AttributeValueNotFoundException"></exception>
        public async Task<(AttributeValueForUpdateDto attributeValueToPatch, AttributeValue attributeValueEntity)> GetAttributeValueForPatch(Guid productId, int id, bool proTrackChanges, bool attrTrackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, proTrackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueEntity = await _repository.AttributeValue.GetAttributeValueAsync(productId, id, attrTrackChanges);
            if (attributeValueEntity is null)
                throw new AttributeValueNotFoundException(id);

            var attributeValueToPatch = _mapper.Map<AttributeValueForUpdateDto>(attributeValueEntity);

            return (attributeValueToPatch, attributeValueEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValueToPatch"></param>
        /// <param name="attributeValueEntity"></param>
        /// <returns></returns>
        public async Task SaveChangesForPatch(AttributeValueForUpdateDto attributeValueToPatch, AttributeValue attributeValueEntity)
        {
            _mapper.Map(attributeValueToPatch, attributeValueEntity);

            await _repository.SaveAsync();
        }

        #endregion
    }
}
