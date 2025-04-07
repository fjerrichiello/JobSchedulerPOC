using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_locks")]
public class QuartzLock
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("lock_name")]
    public string LockName { get; set; } = string.Empty;
}
