using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ggsport.Authentication.Model.Dto;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
