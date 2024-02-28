using Shared.DataTransferObjects.ProductDto;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
        Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollection
                (IEnumerable<ProductForCreationDto> productCollection);
        Task DeleteProductAsync(Guid productId, bool trackChanges);
        Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges);

    }
}
