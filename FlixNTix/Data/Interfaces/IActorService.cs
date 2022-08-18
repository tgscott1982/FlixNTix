﻿using FlixNTix.Models;

namespace FlixNTix.Data.Interfaces;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAll();
    Actor GetById(int id);
    void Add(Actor actor);
    Actor Update(int id, Actor newActor);
    void Delete(int id);
}
