namespace MT799Service.Services;

public interface IMT799WorkerService
{
    Task CreateRecords(CancellationToken cancellationToken = default, params string[] fileText);
}