using FlixNTix.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Models;

public class Producer : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Photo")]
    [Required(ErrorMessage ="Profile Picture is Required")]
    public string? ProfilePictureURL { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is Required")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Full Name must be between 6 and 50 characters long")]

    public string? FullName { get; set; }

    [Display(Name = "Bio")]
    [Required(ErrorMessage = "Biography is Required")]
    
    public string? Bio { get; set; }

    //producer to movie relationship

    public List<Movie>? Movies { get; set; }
}
