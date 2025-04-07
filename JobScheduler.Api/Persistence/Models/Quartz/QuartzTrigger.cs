using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_triggers")]
public class QuartzTrigger
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("trigger_name")]
    public string TriggerName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
    [Column("job_name")]
    public string JobName { get; set; } = string.Empty;
    [Column("job_group")]
    public string JobGroup { get; set; } = string.Empty;
    [Column("description")]
    public string? Description { get; set; }
    [Column("next_fire_time")]
    public long? NextFireTime { get; set; }
    [Column("prev_fire_time")]
    public long? PrevFireTime { get; set; }
    [Column("priority")]
    public int? Priority { get; set; }
    [Column("trigger_state")]
    public string TriggerState { get; set; } = string.Empty;
    [Column("trigger_type")]
    public string TriggerType { get; set; } = string.Empty;
    [Column("start_time")]
    public long StartTime { get; set; }
    [Column("end_time")]
    public long? EndTime { get; set; }
    [Column("calendar_name")]
    public string? CalendarName { get; set; }
    [Column("misfire_instr")]
    public short? MisfireInstr { get; set; }
    [Column("job_data")]
    public byte[]? JobData { get; set; }

    public QuartzBlobTrigger QuartzBlobTrigger { get; set; } = null!;
    public QuartzCronTrigger QuartzCronTrigger { get; set; } = null!;
    public QuartzSimpleTrigger QuartzSimpleTrigger { get; set; } = null!;
    public QuartzSimpropTrigger QuartzSimpropTrigger { get; set; } = null!;
    public QuartzJobDetail QuartzJobDetail { get; set; } = null!;
}