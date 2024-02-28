using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.RequestFeatures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async Task<IEnumerable<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(i => i.IsVisibility == true)
                .OrderBy(i => i.CreatedDate)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) => 
            await FindByCondition(i => i.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();

        public void CreateProduct(Product product) => Create(product);

        public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.ProductId), trackChanges).ToListAsync();

        public void DeleteProduct(Product product) => Delete(product);


    }
}
