using Domain.Entities;
using WebApi.Dto;

namespace Application.Services.Interfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(Guid id);
    Task CreatePostAsync(CreatePostDto dto);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(Guid id);
}