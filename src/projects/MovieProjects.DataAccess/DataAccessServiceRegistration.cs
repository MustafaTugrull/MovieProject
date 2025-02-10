using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;

namespace MovieProject.DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessDepencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IDirectoryRepository, DirectorRepository>();
        services.AddScoped<IMovieArtistRepository, MovieArtistRepository>();


        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        });

        return services;
    }
}
