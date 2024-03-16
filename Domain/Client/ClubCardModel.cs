using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Domain.Client;

[Table("club_card")]
public class ClubCardModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [Required]
    [Column("price")]
    public required decimal Price { get; set; }
}
