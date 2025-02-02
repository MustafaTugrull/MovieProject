using Core.DataAccess.Repositories;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Abstracts;

public interface IDirectoryRepository : IRepository<Director, long>
{
    List<Director> GetAllByNameContains(string name);
}
