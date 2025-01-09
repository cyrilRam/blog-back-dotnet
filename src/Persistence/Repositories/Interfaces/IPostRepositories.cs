
using Domain.Entities;

namespace Persistence.Repositories.Interfaces;

public interface IPostRepositories
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> GetByIdAsync(Guid id);
    Task CreateAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
}