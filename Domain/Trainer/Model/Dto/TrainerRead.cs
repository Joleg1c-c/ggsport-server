using ggsport.Domain.Schedule.Model.Dto;

namespace ggsport.Domain.Trainer.Model;

public class TrainerRead
{
    public int Id { get; set; }

    public required string LastName { get; set; }

    public required string FirstName { get; set; }

    public required string Patronymic { get; set; }

    public required string Position { get; set; }

    public List<ScheduleRead> Schedules { get; set; } = [];

}
