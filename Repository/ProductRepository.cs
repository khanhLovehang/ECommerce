using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(i => i.CreatedDate).ToList();
        }

        public Product? GetProduct(Guid productId, bool trackChanges)
        {
            return FindByCondition(i => i.ProductId.Equals(productId), trackChanges).SingleOrDefault();
        }

        public void CreateProduct(Product product) => Create(product);

    }
}
