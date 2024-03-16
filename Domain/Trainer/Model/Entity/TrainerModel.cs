using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ggsport.Domain.Schedule.Model.Entity;

namespace ggsport.Domain.Trainer.Model.Entity;

[Table("trainer")]
public class TrainerModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("last_name")]
    public required string LastName { get; set; }

    [Required]
    [Column("first_name")]
    public required string FirstName { get; set; }

    [Required]
    [Column("patronymic")]
    public required string Patronymic { get; set; }

    [Required]
    [Column("position")]
    public required string Position { get; set; }

    public List<ScheduleTrainer> ScheduleTrainers { get; set; } = [];

    public List<ScheduleModel> Schedules { get; set; } = [];

}
