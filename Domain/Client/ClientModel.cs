using ggsport.Authentication.Model.Entity;
using ggsport.Domain.Schedule.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ggsport.Domain.Client;

[Table("client")]
public class ClientModel : UserModel
{

    [Column("club_card_id")]
    public required int ClubCardId { get; set; }

    [ForeignKey(nameof(ClubCardId))]
    public ClubCardModel? ClubCard { get; set; }

    public List<ScheduleClient> ScheduleClients { get; set; } = [];

    public List<ScheduleModel> Schedules { get; set; } = [];
}
