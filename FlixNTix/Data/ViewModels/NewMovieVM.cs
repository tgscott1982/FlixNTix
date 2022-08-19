using FlixNTix.Data.Base;
using FlixNTix.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixNTix.Models;

public class NewMovieVM
{
    [Display(Name = "Movie name")]
    [Required(ErrorMessage ="Name is required")]

    public string Name { get; set; }

    [Display(Name = "Movie description")]
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    [Display(Name = "Price in $$")]
    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }

    [Display(Name = "Movie poster URL")]
    [Required(ErrorMessage = "Movie poster URL is required")]
    public string ImageURL { get; set; }

    [Display(Name = "Movie start date")]
    [Required(ErrorMessage = "State date is required")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Movie end date")]
    [Required(ErrorMessage = "End date is required")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Select a category")]
    [Required(ErrorMessage = "Category is required")]
    public MovieCategory MovieCategory { get; set; }

    //relationships

    [Display(Name = "Select actor(s)")]
    [Required(ErrorMessage = "Actor(s) is/are required")]
    public List<int> ActorIds { get; set; }

    [Display(Name = "Select a theater")]
    [Required(ErrorMessage = "Theater is required")]

    public int TheaterId { get; set; }

    [Display(Name = "Select producer(s)")]
    [Required(ErrorMessage = "Producer(s) is/are required")]

    public int ProducerId { get; set; }

}
