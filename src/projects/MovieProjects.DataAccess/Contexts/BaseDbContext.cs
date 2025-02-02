using Microsoft.EntityFrameworkCore;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Contexts;

public sealed class BaseDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AO5K0VF;Initial Catalog=Movie_Project_Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<MovieArtist> MovieArtists { get; set; }
    public DbSet<Movie> Movies { get; set; }
}
