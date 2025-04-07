using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_simple_triggers")]
public class QuartzSimpleTrigger
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("trigger_name")]
    public string TriggerName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
    [Column("repeat_count")]
    public long RepeatCount { get; set; }
    [Column("repeat_interval")]
    public long RepeatInterval { get; set; }
    [Column("times_triggered")]
    public long TimesTriggered { get; set; }

    public QuartzTrigger QuartzTrigger { get; set; } = null!;
}