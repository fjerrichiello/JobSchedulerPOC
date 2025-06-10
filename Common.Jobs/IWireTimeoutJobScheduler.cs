using Common.Events.Wires;
using Common.Messaging;
using Quartz;

namespace Common.Jobs.Quartz;

public interface IWireTimeoutJobScheduler
{
    Task ScheduleWireTimeoutJob(MessageContainer<WireCompletedEvent, EventMetadata> jobDetail, string wireNumber);
    Task DeleteWireTimeoutJob(string wireNumber);
}