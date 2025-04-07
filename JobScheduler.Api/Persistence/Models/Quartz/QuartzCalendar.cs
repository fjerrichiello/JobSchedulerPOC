using System.ComponentModel.DataAnnotations.Schema;

namespace JobScheduler.Api.Persistence.Models.Quartz;

[Table("qrtz_calendars")]
public class QuartzCalendar
{
    [Column("sched_name")]
    public string SchedName { get; set; } = string.Empty;
    [Column("calendar_name")]
    public string CalendarName { get; set; } = string.Empty;
    [Column("calendar")]
    public byte[] Calendar { get; set; } = null!;
}
