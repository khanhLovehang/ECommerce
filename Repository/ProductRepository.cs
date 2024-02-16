using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        //public async Task<IEnumerable<Product>> GetAllProducts(bool trackChanges)
        //{
        //    return await FindAll(trackChanges).OrderBy(i => i.CreatedDate).ToListAsync();
        //}

        public async Task<IEnumerable<Product>> GetAllProducts(ProductParameters productParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(i => i.IsVisibility == true)
                .OrderBy(i => i.CreatedDate)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Product?> GetProduct(Guid productId, bool trackChanges)
        {
            return await FindByCondition(i => i.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateProduct(Product product) => Create(product);

    }
}
