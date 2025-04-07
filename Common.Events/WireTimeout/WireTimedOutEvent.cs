using Common.Messaging;

namespace Common.Events.WireTimeout;

public record WireTimedOutEvent(string WireNumber): Message;