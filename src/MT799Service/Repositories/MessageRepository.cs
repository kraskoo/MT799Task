namespace MT799Service.Repositories;

using MT799Service.Models;

public class MessageRepository : IMessageRepository
{
    private readonly MT799Context context;

    public MessageRepository(MT799Context context) => this.context = context;

    public async Task AddAsync(Message message, CancellationToken cancellationToken = default)
    {
        await this.context.Messages.AddAsync(message, cancellationToken);
        await this.context.SaveChangesAsync(cancellationToken);
    }
}