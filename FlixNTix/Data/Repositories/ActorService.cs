using FlixNTix.Data.Base_Repositories;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixNTix.Data.Repositories;

public class ActorService : EntityBaseRespository<Actor>, IActorService
{

    public ActorService(ApplicationDbContext context) : base(context) { }


}
