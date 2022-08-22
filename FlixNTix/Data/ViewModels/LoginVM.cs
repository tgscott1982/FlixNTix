using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Data.ViewModels;

public class LoginVM
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email Address Is Required")]
    public string EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
