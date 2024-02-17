using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto product);

    }
}
