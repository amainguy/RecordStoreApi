using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data
{
    public interface IUnitOfWork
    {
        IRecordRepository Records { get; }
        IArtistRepository Artists { get; }
        void SaveChanges();
    }
}
