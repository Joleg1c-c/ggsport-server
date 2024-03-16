using System.ComponentModel.DataAnnotations;

namespace ggsport.Domain.Schedule.Model.Dto;

public class ScheduleCreate
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public List<int> Trainers { get; set; } = [];

    public List<int> Clients { get; set; } = [];

    [DataType(DataType.DateTime)]
    [Required]
    public DateTime StartExercise { get; set; }

    [DataType(DataType.DateTime)]
    [Required]
    public DateTime EndExercise { get; set; }

    [Required]
    public int ExerciseId { get; set; }
}
