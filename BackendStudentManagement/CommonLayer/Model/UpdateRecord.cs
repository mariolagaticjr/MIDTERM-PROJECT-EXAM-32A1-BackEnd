
namespace BackendStudentManagement.CommonLayer.Model
{
    public class UpdateRecordRequest
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Subjects { get; set; }
        public string Sections { get; set; }
    }

    public class UpdateRecordResponse
    { 
    public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static implicit operator UpdateRecordResponse(UpdateRecordRequest v)
        {
            throw new NotImplementedException();
        }
    }
}
