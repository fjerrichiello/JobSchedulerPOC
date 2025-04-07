using Common.Models.Authors;

namespace JobScheduler.Api.CommandHandlers.Authors.AddAuthor;

public record AddAuthorUnverifiedData(IAuthorLike? Author, string? FirstName, string? LastName)
    : IAuthorCommandData<IAuthorLike>;