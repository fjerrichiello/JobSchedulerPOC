using Common.Events.Wires;
using Common.Messaging;
using Common.Verifiers;
using Common.Verifiers.Rules;
using FluentValidation;

namespace JobScheduler.Api.EventHandlers.WireCompleted;

public class WireCompletedVerifier : MessageVerifier<WireCompletedEvent, EventMetadata, WireCompletedUnverifiedData>
{
    protected override void ValidationRules()
    {
    }
}