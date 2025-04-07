using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_cron_triggers")]
public class QuartzCronTrigger
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("trigger_name")]
    public string TriggerName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
    [Column("cron_expression")]
    public string CronExpression { get; set; } = string.Empty;
    [Column("time_zone_id")]
    public string? TimeZoneId { get; set; }

    public QuartzTrigger QuartzTrigger { get; set; } = null!;
}