using ggsport.Domain.Trainer.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Domain.Schedule.Model.Entity;

[Table("schedule_trainer")]
public class ScheduleTrainer
{
    [Column("schedule_id")]
    public int ScheduleId { get; set; }
 
    [Column("trainer_id")]
    public int TrainerId { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public ScheduleModel Schedule { get; set; } = null!;

    [ForeignKey(nameof(TrainerId))]
    public TrainerModel Trainer { get; set; } = null!;

}
