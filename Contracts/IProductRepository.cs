using Entities.Models;
using Shared.RequestFeatures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(ProductParameters productParameters, bool trackChanges);

        Task<Product> GetProduct(Guid id, bool trackChanges);

        void CreateProduct(Product product);
        Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        Task DeleteProduct(Product product);

    }
}
