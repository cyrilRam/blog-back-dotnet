
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPostRepositories
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> GetByIdAsync(Guid id);
    Task CreateAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
}