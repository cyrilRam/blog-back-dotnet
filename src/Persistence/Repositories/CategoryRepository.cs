using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext  _dbContext;

    public CategoryRepository(AppDbContext  dbContext)
    {
        _dbContext = dbContext;
    }

    // Récupère toutes les catégories
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.Set<Category>().ToListAsync();
    }

    // Récupère une catégorie par son ID
    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<Category>()
            .FirstOrDefaultAsync(c => c.id == id);
    }

    // Crée une nouvelle catégorie
    public async Task CreateAsync(Category category)
    {
        await _dbContext.Set<Category>().AddAsync(category);
        await _dbContext.SaveChangesAsync(); // Sauvegarde dans la base de données
    }

    // Met à jour une catégorie existante
    public async Task UpdateAsync(Category category)
    {
        _dbContext.Set<Category>().Update(category);
        await _dbContext.SaveChangesAsync(); // Sauvegarde les modifications dans la base de données
    }

    // Supprime une catégorie par son ID
    public async Task DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            _dbContext.Set<Category>().Remove(category);
            await _dbContext.SaveChangesAsync(); // Supprime la catégorie de la base de données
        }
    }
}