using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Models;

public class Theater
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Theater Logo")]
    public string Logo { get; set; }

    [Display(Name = "Theater Name")]
    public string Name { get; set; }

    [Display(Name = "Theater Description")]
    public string Description { get; set; }

    //theater to movie relationship

    public List<Movie> Movies { get; set; }

}
