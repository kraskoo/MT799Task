namespace MT799Service.Services
{
    public interface IMT799WorkerService
    {
        Task CreateRecords(params string[] fileText);
    }
}