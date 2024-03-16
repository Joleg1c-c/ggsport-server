using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ggsport.Domain.Course;
using ggsport.Domain.Room;
using ggsport.Domain.Client;
using ggsport.Domain.Trainer.Model.Entity;

namespace ggsport.Domain.Schedule.Model.Entity;

[Table("schedule")]
public class ScheduleModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Column("room_id")]
    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public RoomModel? Room { get; set; }
    public List<ScheduleTrainer> ScheduleTrainers { get; set; } = [];

    public List<TrainerModel> Trainers { get; set; } = [];

    public List<ScheduleClient> ScheduleClients { get; set; } = [];

    public List<ClientModel> Clients { get; set; } = [];

    [Column("start_exercise")]
    public DateTime StartExercise { get; set; }

    [Column("end_exercise")]
    public DateTime EndExercise { get; set; }

    [Column("exercise_id")]
    [Required]
    public int ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public ExerciseModel Exercise { get; set; }
}
