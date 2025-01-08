
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using BlogDotNet.Middleware;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Enregistrer le DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Ajouter les services nécessaires
builder.Services.AddControllers();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPostRepositories, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Ajouter Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurer Swagger pour la documentation API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use Exception Middleware
// app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();