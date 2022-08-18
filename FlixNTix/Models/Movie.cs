using FlixNTix.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixNTix.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }

    //movie to actor relationship
    public List<Actor_Movie> Actors_Movies { get; set; }

    //movie to theater relationship
    public int TheaterId { get; set; }
    [ForeignKey("TheaterId")]

    public Theater Theater { get; set; }

    //move to producer relationship
    public int ProducerId { get; set; }
    [ForeignKey("ProducerId")]

    public Producer Producer { get; set; }
}
