namespace BackendStudentManagement.CommonLayer.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<ReadRecordData>  readRecordData { get; set; }
    }


    public class ReadRecordData
    {
        public string Username { get; set; }
        public string Subjects { get; set; }
        public string Sections { get; set; }
    }
}
