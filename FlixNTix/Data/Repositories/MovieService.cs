using FlixNTix.Data.Base_Repositories;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Data.Repositories;

public class MovieService : EntityBaseRespository<Movie>, IMovieService
{
    private readonly ApplicationDbContext _context;
    public MovieService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDetails = _context.Movies
            .Include(t => t.Theater)
            .Include(p => p.Producer)
            .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(n => n.Id == id);

        return movieDetails;
    }
}
