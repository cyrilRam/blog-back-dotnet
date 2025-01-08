using Application.Dto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;


using Domain.Entities;

namespace Application.Services;

public class PostService :  IPostService
{
    private readonly IPostRepositories _postRepository;

    public PostService(IPostRepositories postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllAsync();
    }

    public async Task<Post> GetPostByIdAsync(Guid id)
    {
        return await _postRepository.GetByIdAsync(id);
    }

    public async Task CreatePostAsync(CreatePostDto dto)
    {
        var post = new Post
        {
            id = Guid.NewGuid(),
            title = dto.Title,
            content = dto.Content,
            createdDate = DateTime.UtcNow,
            categoryId = dto.CategoryId
        };

        await _postRepository.CreateAsync(post);
    }

    public async Task UpdatePostAsync(Post post)
    {
        await _postRepository.UpdateAsync(post);
    }

    public async Task DeletePostAsync(Guid id)
    {
        await _postRepository.DeleteAsync(id);
    }
}