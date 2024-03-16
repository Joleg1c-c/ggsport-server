using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Authentication.Model.Entity;

[Table("role")]
public class RoleModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }
}
