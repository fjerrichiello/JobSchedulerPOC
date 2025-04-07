using System.Text.Json;
using Common.Events.Wires;
using Common.Messaging;
using Quartz;

namespace Common.Jobs.Quartz;

public class WireTimeoutJobScheduler(ISchedulerFactory _scheduler) : IWireTimeoutJobScheduler
{
    public async Task ScheduleWireTimeoutJob(MessageContainer<WireCompletedEvent, EventMetadata> jobDetail,
        string wireNumber)
    {
        var key = GetTriggerKey(wireNumber);
        var trigger = GetTrigger(key, jobDetail, wireNumber);
        var scheduler = await _scheduler.GetScheduler();
        await scheduler.ScheduleJob(trigger);
    }

    private static TriggerKey GetTriggerKey(string wireNumber)
    {
        return new TriggerKey(wireNumber);
    }

    private ITrigger GetTrigger(TriggerKey key, MessageContainer<WireCompletedEvent, EventMetadata> jobDetail,
        string wireNumber)
    {
        var builder = TriggerBuilder.Create()
            .WithIdentity(key)
            .ForJob(JobConstants.WireTimeoutJob.Name, JobConstants.WireTimeoutJob.Group)
            .UsingJobData(JobConstants.WireTimeoutJob.JobData.WireNumber, wireNumber)
            .UsingJobData(JobConstants.WireTimeoutJob.JobData.MessageContainer, JsonSerializer.Serialize(jobDetail));

        var postingDate = DateTimeOffset.UtcNow.AddMinutes(5);

        builder.StartAt(postingDate);

        return builder.Build();
    }
}