using FlixNTix.Data.Base_Interfaces;
using FlixNTix.Data.ViewModels;
using FlixNTix.Models;

namespace FlixNTix.Data.Interfaces;

public interface IMovieService : IEntityBaseRepository<Movie> 
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
    Task AddNewMovieAsync(NewMovieVM data);
    Task UpdateMovieAsync(NewMovieVM data);
}
