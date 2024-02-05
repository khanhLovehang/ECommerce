using Shared.DataTransferObjects;


namespace Service.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts(bool trackChanges);
        ProductDto GetProduct(Guid productId, bool trackChanges);
        ProductDto CreateProduct(ProductForCreationDto company);

    }
}
