using System.Text.Json;
using Common.Events.Wires;
using Common.Events.WireTimeout;
using Common.Messaging;
using Quartz;

namespace Common.Jobs.Quartz;

public class WireTimeoutJob(IEventPublisher _eventPublisher) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var messageContainer =
            JsonSerializer.Deserialize<MessageContainer<WireCompletedEvent, EventMetadata>>(MessageContainer) ??
            throw new NullReferenceException();

        await _eventPublisher.PublishAsync(messageContainer, [new WireTimedOutEvent(WireNumber)]);
    }

    public string WireNumber { private get; set; }

    public string MessageContainer { private get; set; }
}