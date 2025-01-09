using Application.Services.Interfaces;
using Persistence.Repositories.Interfaces;


namespace Application.Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Domain.Entities.Category> GetCategoryByIdAsync(Guid id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task CreateCategoryAsync(Domain.Entities.Category category)
    {
        await _categoryRepository.CreateAsync(category);
    }

    public async Task UpdateCategoryAsync(Domain.Entities.Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}