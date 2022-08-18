namespace FlixNTix.Models;

public class Actor_Movie
{
    //Many to many actor to movie relationship
    public int MovieId { get; set; }
    public Movie Movie {get; set;}
    public int ActorId { get; set; }
    public Actor Actor { get; set; }


}
