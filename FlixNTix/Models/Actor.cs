using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Photo")]
    public string ProfilePictureURL { get; set; }

    [Display(Name = "Full Name")]

    public string FullName { get; set; }

    [Display(Name = "Bio")]

    public string Bio { get; set; }

    //actor to movie relationship

    public List<Actor_Movie> Actors_Movies { get; set; }

}
