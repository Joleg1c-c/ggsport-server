using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Authentication.Model.Entity;

[Table("user")]
public class UserModel
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("password")]
    public required string Password { get; set; }

    [Required]
    [Column("email")]
    public required string Email { get; set; }

    [DefaultValue("false")]
    [Required]
    [Column("is_email_confirmed")]
    public bool IsEmailConfirmed { get; set; }

    [Column("role_id")]
    [Required]
    public int RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    [Required]
    public RoleModel Role { get; set; }
}
