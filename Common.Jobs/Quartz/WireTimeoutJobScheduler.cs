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


    public async Task DeleteWireTimeoutJob(string wireNumber)
    {
        var scheduler = await _scheduler.GetScheduler();

        var key = GetTriggerKey(wireNumber);
        var exists = await scheduler.CheckExists(key);
        if (exists)
        {
            try
            {
                await scheduler.UnscheduleJob(key);
            }
            catch (Exception ex)
            {
               //Error 
            }
        }
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

        var postingDate = DateTimeOffset.Now.AddSeconds(1);

        builder.StartAt(postingDate);

        return builder.Build();
    }
}