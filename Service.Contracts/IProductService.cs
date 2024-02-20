using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
        Task<IEnumerable<ProductDto>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollection
                (IEnumerable<ProductForCreationDto> companyCollection);
        Task DeleteProduct(Guid productId, bool trackChanges);
        Task UpdateProduct(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges);

    }
}
