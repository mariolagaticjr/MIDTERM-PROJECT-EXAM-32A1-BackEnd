using BackendStudentManagement.CommonLayer.Model;
using BackendStudentManagement.RepositoryLayer;

namespace BackendStudentManagement.ServiceLayer
{
    public class CrudOperationsSL : ICrudOperationSL
    {
        public readonly ICrudOperationRL _crudOperationRL;

        public CrudOperationsSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }
   
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudOperationRL.CreateRecord(request);    
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);       
        }

 
    }
}
