using RecordStore.Data;

namespace RecordStore.Services.Implementations
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
