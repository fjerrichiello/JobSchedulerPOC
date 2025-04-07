using JobScheduler.Api.Domain.Models;

namespace JobScheduler.Api.Persistence.Repositories;

public interface IBookRequestRepository
{
    Task AddAddBookRequestAsync(AddBookRequest addBookRequest);

    Task AddEditBookRequestAsync(EditBookRequest editBookRequest);

    Task<List<AddBookRequest>> GetAddRequests(int authorId, string title);

    Task<List<EditBookRequest>> GetEditRequests(int authorId, string title);
}