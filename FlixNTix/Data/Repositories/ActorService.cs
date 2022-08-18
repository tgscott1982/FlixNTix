using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Data.Repositories;

public class ActorService : IActorService
{
    private readonly ApplicationDbContext _context;

    public ActorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Actor actor)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task <IEnumerable<Actor>> GetAll()
    {
        var result = await _context.Actors.ToListAsync();
        return result;
    }

    public Actor GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Actor Update(int id, Actor newActor)
    {
        throw new NotImplementedException();
    }
}
