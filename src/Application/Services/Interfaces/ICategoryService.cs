


namespace Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Domain.Entities.Category>> GetAllCategoriesAsync();
    Task<Domain.Entities.Category> GetCategoryByIdAsync(Guid id);
    Task CreateCategoryAsync(Domain.Entities.Category category);
    Task UpdateCategoryAsync(Domain.Entities.Category category);
    Task DeleteCategoryAsync(Guid id);
}