namespace MT799Service.Repositories
{
    using MT799Service.Models;

    public interface IMessageRepository
    {
        Task AddAsync(Message message, CancellationToken cancellationToken = default);
    }
}