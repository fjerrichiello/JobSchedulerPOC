using Common.Messaging;

namespace Common.Events.Wires;

public record WireCompletedEvent(string WireNumber) : Message;