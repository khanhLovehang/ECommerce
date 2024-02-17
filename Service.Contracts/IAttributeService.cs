using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IAttributeService
    {
        Task<IEnumerable<AttributeDto>> GetAllAttributesAsync(RequestParameters attributeParameters, bool trackChanges);
        Task<AttributeDto> GetAttributeAsync(Guid AttributeId, bool trackChanges);
        Task<AttributeDto> CreateAttributeAsync(AttributeForCreationDto attribute);

    }
}
