
using Application.Dto;

using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(Guid id);
    Task CreatePostAsync(CreatePostDto dto);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(Guid id);
}