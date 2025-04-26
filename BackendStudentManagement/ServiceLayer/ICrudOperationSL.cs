using BackendStudentManagement.CommonLayer.Model;

namespace BackendStudentManagement.ServiceLayer
{
    public interface ICrudOperationSL
    {

        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
    }
}
