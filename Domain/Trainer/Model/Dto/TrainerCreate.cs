using System.ComponentModel.DataAnnotations;

namespace ggsport.Domain.Trainer.Model;

public class TrainerCreate
{
    public int Id { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string Patronymic { get; set; }

    [Required]
    public required string Position { get; set; }
}
