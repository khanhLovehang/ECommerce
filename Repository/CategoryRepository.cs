using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.RequestFeatures;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        //public async Task<IEnumerable<Category>> GetAllCategorys(bool trackChanges)
        //{
        //    return await FindAll(trackChanges).OrderBy(i => i.CreatedDate).ToListAsync();
        //}

        public async Task<IEnumerable<Category>> GetAllCategorysAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(i => i.CreatedDate)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges) =>
            await FindByCondition(i => i.CategoryId.Equals(categoryId), trackChanges).SingleOrDefaultAsync();

        public void CreateCategory(Category category) => Create(category);

        public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.CategoryId), trackChanges).ToListAsync();

        public void DeleteCategory(Category category) => Delete(category);
    }
}
