namespace JobScheduler.Api.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    Task CompleteAsync();
}