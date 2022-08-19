using FlixNTix.Data.Base_Repositories;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;

namespace FlixNTix.Data.Repositories;

public class TheaterService : EntityBaseRespository<Theater>, ITheaterService
{
    public TheaterService(ApplicationDbContext context) : base(context) 
    { 
    }
}
