using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IAttributeValueService
    {
        Task<(IEnumerable<AttributeValueDto> attributeValues, MetaData metaData)> GetAttributeValuesAsync(Guid productId, AttributeParameters attributeParameters, bool trackChanges);
        Task<AttributeValueDto> GetAttributeValueAsync(Guid companyId, int id, bool trackChanges);
        Task<AttributeValueDto> CreateAttributeValueForProductAsync(Guid productId, AttributeValueForCreationDto attributeValue, bool trackChanges);
        Task DeleteAttributeValueForProduct(Guid productId, int id, bool trackChanges);
        Task UpdateAttributeValueForProduct(Guid productId, int id
            , AttributeValueForUpdateDto attributeValueForUpdate, bool proTrackChanges, bool attrTrackChanges);
        Task<(AttributeValueForUpdateDto attributeValueToPatch, AttributeValue attributeValueEntity)> GetAttributeValueForPatch(Guid productId, int id, bool proTrackChanges, bool attrTrackChanges);
        Task SaveChangesForPatch(AttributeValueForUpdateDto attributeValueToPatch, AttributeValue attributeValueEntity);
    }
}
