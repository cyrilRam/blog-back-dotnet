using Application.Interfaces.Repositories;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PostRepository : IPostRepositories
    {
        private readonly AppDbContext  _dbContext;

        public PostRepository(AppDbContext  dbContext)
        {
            _dbContext = dbContext;
        }

        // Récupère tous les posts
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dbContext.Set<Post>()
                .Include(p => p.Category) // Inclure la catégorie dans la requête pour éviter les appels séparés
                .ToListAsync();
        }

        // Récupère un post par son ID
        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Post>()
                .Include(p => p.Category) // Inclure la catégorie dans la requête
                .FirstOrDefaultAsync(p => p.id == id);
        }

        // Crée un nouveau post
        public async Task CreateAsync(Post post)
        {
            await _dbContext.Set<Post>().AddAsync(post);
            await _dbContext.SaveChangesAsync(); // Sauvegarde dans la base de données
        }

        // Met à jour un post existant
        public async Task UpdateAsync(Post post)
        {
            _dbContext.Set<Post>().Update(post);
            await _dbContext.SaveChangesAsync(); // Sauvegarde les modifications dans la base de données
        }

        // Supprime un post par son ID
        public async Task DeleteAsync(Guid id)
        {
            var post = await GetByIdAsync(id);
            if (post != null)
            {
                _dbContext.Set<Post>().Remove(post);
                await _dbContext.SaveChangesAsync(); // Supprime le post de la base de données
            }
        }
    }
}
