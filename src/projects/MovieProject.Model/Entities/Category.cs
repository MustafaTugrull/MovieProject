using Core.DataAccess.Enitities;

namespace MovieProject.Model.Entities;

public sealed class Category : Entity<int>
{
    public Category()
    {
        Name = string.Empty;
        Movies = new HashSet<Movie>();
    }
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}





