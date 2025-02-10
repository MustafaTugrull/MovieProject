using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;
using MovieProject.DataAccess;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Artist;
using MovieProject.Service.BusinessRules.Categories;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency Injection Lifecycle (Yaþam Döngüsü)
//AddScoped() : Uygulama boyunca 1 tane nesne üretir. Nesnenin ömrü ise istek cevaba dönene kadar.
//AddSingleton() : Uygulama boyunca 1 tane nesne üretir.
//AddTransient() : Uygulamada her istek için ayrý bir nesne oluþturur.

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddDataAccessDepencies(builder.Configuration);
builder.Services.AddServiceDependencies();

//builder.Services.AddScoped<CategoryService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
