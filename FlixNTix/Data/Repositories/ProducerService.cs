using FlixNTix.Data.Base_Repositories;
using FlixNTix.Data.Interfaces;
using FlixNTix.Models;

namespace FlixNTix.Data.Repositories;

public class ProducerService : EntityBaseRespository<Producer>, IProducerService
{
    public ProducerService(ApplicationDbContext context) : base(context)
    {
    }
}
