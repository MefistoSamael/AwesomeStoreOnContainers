using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions
{
    internal interface ITypeRepository
    {
        Task<string> CreateCategoryAsync(Category product);

        Task<string> UpdateCategoryAsync(Category product);

        Task DeleteCategoryAsync(Category product);


        Task<Category> GetCategoryByIdAsync(string id);

        Task<IEnumerable<Category>> GetPaginatedCategoriesAsync();

    }
}
