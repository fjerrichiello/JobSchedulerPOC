using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_simprop_triggers")]
public class QuartzSimpropTrigger
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("trigger_name")]
    public string TriggerName { get; set; } = string.Empty;
    [Column("trigger_group")]
    public string TriggerGroup { get; set; } = string.Empty;
    [Column("str_prop_1")]
    public string? StrProp1 { get; set; }
    [Column("str_prop_2")]
    public string? StrProp2 { get; set; }
    [Column("str_prop_3")]
    public string? StrProp3 { get; set; }
    [Column("int_prop_1")]
    public int? IntProp1 { get; set; }
    [Column("int_prop_2")]
    public int? IntProp2 { get; set; }
    [Column("long_prop_1")]
    public long? LongProp1 { get; set; }
    [Column("long_prop_2")]
    public long? LongProp2 { get; set; }
    [Column("dec_prop_1")]
    public decimal? DecProp1 { get; set; }
    [Column("dec_prop_2")]
    public decimal? DecProp2 { get; set; }
    [Column("bool_prop_1")]
    public bool? BoolProp1 { get; set; }
    [Column("bool_prop_2")]
    public bool? BoolProp2 { get; set; }
    [Column("time_zone_id")]
    public string? TimeZoneId { get; set; }

    public QuartzTrigger QuartzTrigger { get; set; } = null!;
}