using JobScheduler.Api.Domain.Models;

namespace JobScheduler.Api.Persistence.Repositories;

public interface IBookRepository
{
    Task<Book?> GetAsync(int id);

    Task AddAsync(Book book);
}