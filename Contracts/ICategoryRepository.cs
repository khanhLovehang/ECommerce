using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategorysAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<Category> GetCategoryAsync(int id, bool trackChanges);
        void CreateCategory(Category category);
        Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteCategory(Category category);
    }
}
