namespace JobScheduler.Api.Domain.Models;

public record BookCount(Guid Id, string AuthorId, int Count)
{
};