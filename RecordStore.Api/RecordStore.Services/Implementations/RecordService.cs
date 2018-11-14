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
    }
}
