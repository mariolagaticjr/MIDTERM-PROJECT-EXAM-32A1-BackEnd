namespace BackendStudentManagement.CommonLayer.Model
{
    public class CreateRecordRequest
    {
        public string ID { get; set;   }
        public string Username { get; set; }
        public string Subjects { get; set; }
        public string Sections { get; set; }
    }
}



    public class CreateRecordResponse
    { 
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    }

