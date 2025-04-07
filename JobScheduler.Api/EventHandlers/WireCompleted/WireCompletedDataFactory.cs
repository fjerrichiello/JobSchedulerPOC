using Common.DataFactory;
using Common.Events.Wires;
using Common.Messaging;

namespace JobScheduler.Api.EventHandlers.WireCompleted;

public class WireCompletedDataFactory()
    : IDataFactory<WireCompletedEvent, EventMetadata, WireCompletedUnverifiedData, WireCompletedVerifiedData>
{
    public async Task<WireCompletedUnverifiedData> GetUnverifiedDataAsync(
        MessageContainer<Common.Events.Wires.WireCompletedEvent, EventMetadata> container)
    {
        return new();
    }

    public WireCompletedVerifiedData GetVerifiedData(WireCompletedUnverifiedData unverifiedData)
    {
        return new(Random.Shared.Next(1000000).ToString());
    }
}