namespace MT799Service.Services;

using MT799Service.Models;
using MT799Service.Repositories;

public class MT799WorkerService : IMT799WorkerService
{
    private readonly IMessageRepository repository;

    public MT799WorkerService(IMessageRepository repository) => this.repository = repository;

    public async Task CreateRecords(params string[] fileText)
    {
        foreach (var text in fileText)
        {
            await this.repository.AddAsync(this.ParseText(text));
        }
    }

    private Message ParseText(string text)
    {
        var lines = text.Split(Environment.NewLine);
        var transactionReferenceNumber = lines.FirstOrDefault(l => l.StartsWith(":20:"))?.Split(":20:")[1];
        var relatedReference = lines.FirstOrDefault(l => l.StartsWith(":21:"))?.Split(":21:")[1];
        var narrative = lines.FirstOrDefault(l => l.StartsWith(":79:"))?.Split(":79:")[1];
        return new Message
        {
            TransactionReferenceNumber = transactionReferenceNumber!,
            RelatedReference = relatedReference,
            Narrative = narrative!
        };
    }
}