using Common.Messaging;

namespace Common.Events.WireTimeout;

[MessageTags("Timeout")]
public record WireTimedOutEvent(string WireNumber) : Message;