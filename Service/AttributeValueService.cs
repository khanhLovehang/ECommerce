using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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
            var product = await _repository.Product.GetProduct(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributesValueFromDb = await _repository.AttributeValue.GetAttributeValues(productId, trackChanges);

            var attributesValueDto = _mapper.Map<IEnumerable<AttributeValueDto>>(attributesValueFromDb);

            return attributesValueDto;
        }

        public async Task<AttributeValueDto> GetAttributeValue(Guid productId, int id, bool trackChanges)
        {
            var product = await _repository.Product.GetProduct(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueFromDb = await _repository.AttributeValue.GetAttributeValue(productId, id, trackChanges);
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

            var product = await _repository.Product.GetProduct(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var attributeValueEntity = _mapper.Map<AttributeValue>(attributeValueForCreation);

            _repository.AttributeValue.CreateAttributeValueForProduct(productId, attributeValueEntity);
            await _repository.SaveAsync();

            var attributeValueToReturn = _mapper.Map<AttributeValueDto>(attributeValueEntity);

            return attributeValueToReturn;
        }

        #endregion
    }
}
