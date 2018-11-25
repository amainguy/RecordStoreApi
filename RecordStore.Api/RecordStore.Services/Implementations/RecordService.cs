using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.Data;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Implementations
{
    public class RecordService : BaseService, IRecordService
    {
        public RecordService(IUnitOfWork unitOfWork) : base(unitOfWork) {}

        public async Task<IEnumerable<RecordDo>>  GetAll()
        {
            return await _unitOfWork.Records.GetAll();
        }

        public async Task<RecordDo> GetById(int id)
        {
            return await _unitOfWork.Records.Get(id);
        }

        public async Task Create(RecordDo record)
        {
            _unitOfWork.Records.Create(record);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(int id, RecordDo record)
        {
            await _unitOfWork.Records.Update(id, record);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(RecordDo record)
        {
            _unitOfWork.Records.Delete(record);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
