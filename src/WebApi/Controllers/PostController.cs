using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _postService.GetAllPostsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _postService.GetPostByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        await _postService.CreatePostAsync(dto);
        return Created("", null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Post post)
    {
        post.id = id;
        await _postService.UpdatePostAsync(post);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }
}