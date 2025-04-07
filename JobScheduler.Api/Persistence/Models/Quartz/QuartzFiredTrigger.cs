using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_fired_triggers")]
public class QuartzFiredTrigger
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("entry_id")]
    public string EntryId { get; set; } = string.Empty;
    [Column("trigger_name")]
    public string TriggerName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
    [Column("instance_name")]
    public string InstanceName { get; set; } = string.Empty;
    [Column("fired_time")]
    public long FiredTime { get; set; }
    [Column("sched_time")]
    public long SchedTime { get; set; }
    [Column("priority")]
    public int Priority { get; set; }
    [Column("state")]
    public string State { get; set; } = string.Empty;
    [Column("job_name")]
    public string? JobName { get; set; }
    [Column("job_group")]
    public string? JobGroup { get; set; }
    [Column("is_nonconcurrent")]
    public bool IsNonconcurrent { get; set; }
    [Column("requests_recovery")]
    public bool? RequestsRecovery { get; set; }
}
