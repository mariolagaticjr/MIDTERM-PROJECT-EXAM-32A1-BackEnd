using BackendStudentManagement.CommonLayer.Model;

namespace BackendStudentManagement.RepositoryLayer
{
    public interface ICrudOperationRL
    {

        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
    }
}
