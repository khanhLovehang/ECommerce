using Entities;
using Shared.DataTransferObjects;


namespace Service.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
    }
}
