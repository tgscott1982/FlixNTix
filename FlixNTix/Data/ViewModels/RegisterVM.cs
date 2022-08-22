using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Data.ViewModels;

public class RegisterVM
{
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name Is Required")]
    public string FullName { get; set; }

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email Address Is Required")]
    public string EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name ="Confirm Password")]
    [Required(ErrorMessage = "Confirm Password Field Is Required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage ="Passwords Do Not Match")]
    public string ConfirmPassword { get; set; }
}
