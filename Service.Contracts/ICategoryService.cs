using Shared.DataTransferObjects.CategoryDto;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryDto>> GetAllCategorysAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<CategoryDto> GetCategoryAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category);
        Task<IEnumerable<CategoryDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<CategoryDto> categories, string ids)> CreateCategoryCollection(IEnumerable<CategoryForCreationDto> categoryCollection);
        Task DeleteCategoryAsync(int categoryId, bool trackChanges);
        Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdate, bool trackChanges);
    }
}
