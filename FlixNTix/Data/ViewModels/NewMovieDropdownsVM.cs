using FlixNTix.Data.Repositories;
using FlixNTix.Models;

namespace FlixNTix.Data.ViewModels;

public class NewMovieDropdownsVM
{
    public NewMovieDropdownsVM()
    {
        Producers = new List<Producer>();
        Theaters = new List<Theater>();
        Actors = new List<Actor>();
    }
    public List<Producer> Producers {get; set;}
    public List<Theater> Theaters {get; set;}
    public List<Actor> Actors {get; set;}

}
