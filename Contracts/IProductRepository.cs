using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(ProductParameters productParameters, bool trackChanges);

        Task<Product?> GetProduct(Guid id, bool trackChanges);

        void CreateProduct(Product product);
    }
}
