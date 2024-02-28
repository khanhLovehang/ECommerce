using AutoMapper;
using Entities.Exceptions;
using Service.Contracts;
using Shared.RequestFeatures;
using Attribute = Entities.Models.Attribute;
using Contracts.Manager;
using Shared.DataTransferObjects.AttributeDto;
using Entities.Exceptions.AttributeExceptions;

namespace Service
{
    internal sealed class AttributeService : IAttributeService
    {
        #region properties

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public AttributeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get all Attribute
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AttributeDto>> GetAllAttributesAsync(AttributeParameters attributeParameters, bool trackChanges)
        {
            var attributes = await _repository.Attribute.GetAllAttributesAsync(attributeParameters, trackChanges);

            var attributesDto = _mapper.Map<IEnumerable<AttributeDto>>(attributes); // Use auto mapper

            return attributesDto;
        }

        /// <summary>
        /// Get Attribute detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="AttributeNotFoundException"></exception>
        public async Task<AttributeDto> GetAttributeAsync(int id, bool trackChanges)
        {
            var attribute = await GetAttributeAndCheckIfItExists(id, trackChanges);

            var attributeDto = _mapper.Map<AttributeDto>(attribute);

            return attributeDto;
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public async Task<AttributeDto> CreateAttributeAsync(AttributeForCreationDto attribute)
        {
            var attributeEntity = _mapper.Map<Attribute>(attribute);

            _repository.Attribute.CreateAttribute(attributeEntity);

            await _repository.SaveAsync();

            var attributeToReturn = _mapper.Map<AttributeDto>(attributeEntity);

            return attributeToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="IdParametersBadRequestException"></exception>
        /// <exception cref="CollectionByIdsBadRequestException"></exception>
        public async Task<IEnumerable<AttributeDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var attributeEntities = await _repository.Attribute.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != attributeEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var attributesToReturn = _mapper.Map<IEnumerable<AttributeDto>>(attributeEntities);

            return attributesToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttributeCollection"></param>
        /// <returns></returns>
        /// <exception cref="AttributeCollectionBadRequest"></exception>
        public async Task<(IEnumerable<AttributeDto> attributes, string ids)> CreateAttributeCollection(IEnumerable<AttributeForCreationDto> attributeCollection)
        {
            if (attributeCollection is null)
                throw new AttributeCollectionBadRequest();

            var attributeEntities = _mapper.Map<IEnumerable<Attribute>>(attributeCollection);

            foreach (var attribute in attributeEntities)
            {
                _repository.Attribute.CreateAttribute(attribute);
            }

            await _repository.SaveAsync();

            var attributeCollectionToReturn = _mapper.Map<IEnumerable<AttributeDto>>(attributeEntities);

            var ids = string.Join(",", attributeCollectionToReturn.Select(c => c.AttributeId));

            return (attributes: attributeCollectionToReturn, ids: ids);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="AttributeNotFoundException"></exception>
        public async Task DeleteAttributeAsync(int attributeId, bool trackChanges)
        {
            var attribute = await GetAttributeAndCheckIfItExists(attributeId, trackChanges);

            _repository.Attribute.DeleteAttribute(attribute);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeId"></param>
        /// <param name="attributeForUpdate"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="AttributeNotFoundException"></exception>
        public async Task UpdateAttributeAsync(int attributeId, AttributeForUpdateDto attributeForUpdate, bool trackChanges)
        {
            var attribute = await GetAttributeAndCheckIfItExists(attributeId, trackChanges);

            _mapper.Map(attributeForUpdate, attribute);

            await _repository.SaveAsync();
        }
        #endregion

        #region private methods
        private async Task<Attribute> GetAttributeAndCheckIfItExists(int id, bool trackChanges)
        {
            var Attribute = await _repository.Attribute.GetAttributeAsync(id, trackChanges);
            if (Attribute is null)
                throw new AttributeNotFoundException(id);
            return Attribute;
        }

        #endregion
    }
}
