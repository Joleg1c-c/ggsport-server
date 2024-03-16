using ggsport.Domain.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Domain.Schedule.Model.Entity;

[Table("schedule_client")]
public class ScheduleClient
{
    [Column("schedule_id")]
    public int ScheduleId { get; set; }

    [Column("trainer_id")]
    public int ClientId { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public ScheduleModel Schedule { get; set; } = null!;

    [ForeignKey(nameof(ClientId))]
    public ClientModel Client { get; set; } = null!;

}
