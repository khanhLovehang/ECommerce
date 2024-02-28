using Shared.DataTransferObjects.AttributeDto;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IAttributeService
    {
        Task<IEnumerable<AttributeDto>> GetAllAttributesAsync(AttributeParameters attributeParameters, bool trackChanges);
        Task<AttributeDto> GetAttributeAsync(int id, bool trackChanges);
        Task<AttributeDto> CreateAttributeAsync(AttributeForCreationDto attribute);
        Task<IEnumerable<AttributeDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<AttributeDto> attributes, string ids)> CreateAttributeCollection
                (IEnumerable<AttributeForCreationDto> companyCollection);
        Task DeleteAttributeAsync(int attributeId, bool trackChanges);
        Task UpdateAttributeAsync(int attributeId, AttributeForUpdateDto attributeForUpdate, bool trackChanges);
    }
}
