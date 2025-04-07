using Common.Messaging;

namespace JobScheduler.Api.Commands.Authors;

[FailedMessageTags("General", "Author", "Added")]
public record AddAuthorCommand(string FirstName, string LastName) : Message;