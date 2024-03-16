using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ggsport.Authentication.Model.Dto;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    public required string PasswordConfirm { get; set; }
}
