using Common.Events.AddAuthorCommand;
using Common.Events.Wires;
using Common.Jobs.Quartz;
using Common.Messaging;
using Common.Operations;
using JobScheduler.Api.Domain.Models;
using JobScheduler.Api.Persistence.Repositories;
using JobScheduler.Api.Persistence.UnitOfWork;

namespace JobScheduler.Api.EventHandlers.WireCompleted;

public class WireCompletedOperation(
    IWireTimeoutJobScheduler _scheduler)
    : IOperation<WireCompletedEvent, EventMetadata, WireCompletedVerifiedData>
{
    public async Task ExecuteAsync(MessageContainer<WireCompletedEvent, EventMetadata> container,
        WireCompletedVerifiedData data)
    {
        await _scheduler.ScheduleWireTimeoutJob(container, data.WireNumber);

        /*
        if(wire.Done/Fail for all){
         await _scheduler.DeleteWireTimeoutJob(data.WireNumber);
        }
        */
    }
}