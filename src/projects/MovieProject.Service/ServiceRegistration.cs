﻿using Microsoft.Extensions.DependencyInjection;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Artist;
using MovieProject.Service.BusinessRules.Categories;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.BusinessRules.Users;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MovieProject.Service;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ICloudinaryHelper, CloudinaryHelper>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<MovieBusinessRules>();
        services.AddScoped<ArtistBusinessRules>();
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICategoryMapper, CategoryAutoMapper>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<UserBusinessRules>();

        return services;
    }
}
