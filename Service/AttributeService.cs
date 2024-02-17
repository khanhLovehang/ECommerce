using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Attribute = Entities.Models.Attribute;

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
        /// Lấy all sản phẩm
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AttributeDto>> GetAllAttributesAsync(RequestParameters AttributeParameters, bool trackChanges)
        {
            var Attributes = await _repository.Attribute.GetAllAttributes(AttributeParameters, trackChanges);
            var AttributesDto = _mapper.Map<IEnumerable<AttributeDto>>(Attributes); // Use auto mapper
            return AttributesDto;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm
        /// </summary>
        /// <param name="AttributeId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="AttributeNotFoundException"></exception>
        public async Task<AttributeDto> GetAttributeAsync(Guid AttributeId, bool trackChanges)
        {
            var Attribute = await _repository.Attribute.GetAttribute(AttributeId, trackChanges);

            if (Attribute is null)
                throw new AttributeNotFoundException(AttributeId);

            var AttributeDto = _mapper.Map<AttributeDto>(Attribute);
            return AttributeDto;
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="Attribute"></param>
        /// <returns></returns>
        public async Task<AttributeDto> CreateAttributeAsync(AttributeForCreationDto attribute)
        {
            var attributeEntity = _mapper.Map<Attribute>(attribute);

            _repository.Attribute.CreateAttribute(attributeEntity);
            await _repository.SaveAsync();

            var attributeToReturn = _mapper.Map<AttributeDto>(attributeEntity);

            return attributeToReturn;
        }

        #endregion
    }
}
