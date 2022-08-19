using FlixNTix.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Models;

public class Theater:IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Theater Logo")]
    [Required(ErrorMessage = "Theater Logo is Required")]
    public string? Logo { get; set; }

    [Display(Name = "Theater Name")]
    [Required(ErrorMessage = "Theater Name is Required")]
    public string? Name { get; set; }

    [Display(Name = "Theater Description")]
    [Required(ErrorMessage = "Theater Description is Required")]
    public string? Description { get; set; }

    //theater to movie relationship

    public List<Movie>? Movies { get; set; }

}
