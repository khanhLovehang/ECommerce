using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IAttributeValueService
    {
        Task<IEnumerable<AttributeValueDto>> GetAttributeValues(Guid productId, bool trackChanges);
        Task<AttributeValueDto> GetAttributeValue(Guid companyId, int id, bool trackChanges);
        Task<AttributeValueDto> CreateAttributeValueForProductAsync(Guid productId, AttributeValueForCreationDto attributeValue, bool trackChanges);
        Task DeleteAttributeValueForProduct(Guid productId, int id, bool trackChanges);
    }
}
