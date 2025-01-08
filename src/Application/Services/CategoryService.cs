﻿using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

using Domain.Entities;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task CreateCategoryAsync(Category category)
    {
        await _categoryRepository.CreateAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}