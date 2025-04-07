using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_scheduler_state")]
public class QuartzSchedulerState
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("instance_name")]
    public string InstanceName { get; set; } = string.Empty;
    [Column("last_checkin_time")]
    public long LastCheckinTime { get; set; }
    [Column("checkin_interval")]
    public long CheckinInterval { get; set; }
}
