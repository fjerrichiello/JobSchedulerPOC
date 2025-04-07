using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_job_details")]
public class QuartzJobDetail
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("job_name")]
    public string JobName { get; set; } = string.Empty;
    [Column("job_group")]
    public string JobGroup { get; set; } = string.Empty;
    [Column("description")]
    public string? Description { get; set; }
    [Column("job_class_name")]
    public string JobClassName { get; set; } = string.Empty;
    [Column("is_durable")]
    public bool IsDurable { get; set; }
    [Column("is_nonconcurrent")]
    public bool IsNonconcurrent { get; set; }
    [Column("is_update_data")]
    public bool IsUpdateData { get; set; }
    [Column("requests_recovery")]
    public bool RequestsRecovery { get; set; }
    [Column("job_data")]
    public byte[]? JobData { get; set; }

    public ICollection<QuartzTrigger> QuartzTriggers { get; set; } = null!;
}
