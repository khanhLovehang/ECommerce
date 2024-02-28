using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class CategoryService : ICategoryService
    {
        #region properties

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get all Category
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryDto>> GetAllCategorysAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var Categorys = await _repository.Category.GetAllCategorysAsync(categoryParameters, trackChanges);

            var CategorysDto = _mapper.Map<IEnumerable<CategoryDto>>(Categorys); // Use auto mapper

            return CategorysDto;
        }

        /// <summary>
        /// Get Category detail
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="CategoryNotFoundException"></exception>
        public async Task<CategoryDto> GetCategoryAsync(int id, bool trackChanges)
        {
            var Category = await GetCategoryAndCheckIfItExists(id, trackChanges);

            var CategoryDto = _mapper.Map<CategoryDto>(Category);
            return CategoryDto;
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category)
        {
            var CategoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(CategoryEntity);
            await _repository.SaveAsync();

            var CategoryToReturn = _mapper.Map<CategoryDto>(CategoryEntity);

            return CategoryToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="IdParametersBadRequestException"></exception>
        /// <exception cref="CollectionByIdsBadRequestException"></exception>
        public async Task<IEnumerable<CategoryDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var CategoryEntities = await _repository.Category.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != CategoryEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(CategoryEntities);

            return companiesToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryCollection"></param>
        /// <returns></returns>
        /// <exception cref="categoryCollectionBadRequest"></exception>
        //public async Task<(IEnumerable<CategoryDto> categories, string ids)> CreatecategoryCollection(IEnumerable<CategoryForCreationDto> categoryCollection)
        //{
        //    if (categoryCollection is null)
        //        throw new CategoryCollectionBadRequest();

        //    var categoryEntities = _mapper.Map<IEnumerable<Category>>(categoryCollection);

        //    foreach (var category in categoryEntities)
        //    {
        //        _repository.Category.CreateCategory(category);
        //    }

        //    await _repository.SaveAsync();

        //    var categoryCollectionToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);

        //    var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.CategoryId));

        //    return (categories: categoryCollectionToReturn, ids: ids);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="CategoryNotFoundException"></exception>
        public async Task DeleteCategoryAsync(int categoryId, bool trackChanges)
        {
            var Category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            _repository.Category.DeleteCategory(Category);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="CategoryForUpdate"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="CategoryNotFoundException"></exception>
        public async Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdate, bool trackChanges)
        {
            var Category = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            _mapper.Map(categoryForUpdate, Category);

            await _repository.SaveAsync();
        }
        #endregion

        #region private methods
        private async Task<Category> GetCategoryAndCheckIfItExists(int id, bool trackChanges)
        {
            var Category = await _repository.Category.GetCategoryAsync(id, trackChanges);
            if (Category is null)
                throw new CategoryNotFoundException(id);
            return Category;
        }

        #endregion
    }
}
