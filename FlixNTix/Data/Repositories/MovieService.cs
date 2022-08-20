using FlixNTix.Data.Base_Repositories;
using FlixNTix.Data.Interfaces;
using FlixNTix.Data.ViewModels;
using FlixNTix.Models;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace FlixNTix.Data.Repositories;

public class MovieService : EntityBaseRespository<Movie>, IMovieService
{
    private readonly ApplicationDbContext _context;
    public MovieService(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddNewMovieAsync(NewMovieVM data)
    {
        var newMovie = new Movie()
        {
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            ImageURL = data.ImageURL,
            TheaterId = data.TheaterId,
            StartDate = data.StartDate,
            EndDate = data.EndDate,
            MovieCategory = data.MovieCategory,
            ProducerId = data.ProducerId,
        };
        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        //add actors
        foreach(var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = newMovie.Id,
                ActorId = actorId,
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }
        await _context.SaveChangesAsync();
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

    public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
    {
        var response = new NewMovieDropdownsVM()
        {
            Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
            Theaters = await _context.Theaters.OrderBy(n => n.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
        };

        return response;


    }

    public async Task UpdateMovieAsync(NewMovieVM data)
    {
        var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

        if(dbMovie != null)
        {

            dbMovie.Name = data.Name;
            dbMovie.Description = data.Description;
            dbMovie.Price = data.Price;
            dbMovie.ImageURL = data.ImageURL;
            dbMovie.TheaterId = data.TheaterId;
            dbMovie.StartDate = data.StartDate;
            dbMovie.EndDate = data.EndDate;
            dbMovie.MovieCategory = data.MovieCategory;
            dbMovie.ProducerId = data.ProducerId;
            
            await _context.SaveChangesAsync();
        }

        //remove existing actors
        var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
        _context.Actors_Movies.RemoveRange(existingActorsDb);
        await _context.SaveChangesAsync();

        //add actors
        foreach (var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = data.Id,
                ActorId = actorId,
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }
        await _context.SaveChangesAsync();
    }
}
