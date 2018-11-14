namespace RecordStore.Data.Repositories.Factories
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : class;
    }
}
