using FlixNTix.Data.Base_Interfaces;
using FlixNTix.Models;

namespace FlixNTix.Data.Interfaces;

public interface IMovieService : IEntityBaseRepository<Movie> 
{
    Task<Movie> GetMovieByIdAsync(int id);
}
