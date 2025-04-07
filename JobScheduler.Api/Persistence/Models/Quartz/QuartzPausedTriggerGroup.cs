using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_paused_trigger_grps")]
public class QuartzPausedTriggerGroup
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
}
