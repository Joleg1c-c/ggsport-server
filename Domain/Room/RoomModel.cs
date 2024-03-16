using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ggsport.Domain.Room;

[Table("room")]
public class RoomModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("last_name")]
    public required int Number { get; set; }

    [Required]
    [Column("size")]
    public required int Size { get; set; }
}
