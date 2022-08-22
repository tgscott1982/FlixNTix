using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlixNTix.Models;



//personal notes for identity - inherit from 'identityuser' and implement identity using statement.
public class ApplicationUser : IdentityUser
{
    [Display(Name = "Full Name")]
    public string FullName { get; set; }
}
