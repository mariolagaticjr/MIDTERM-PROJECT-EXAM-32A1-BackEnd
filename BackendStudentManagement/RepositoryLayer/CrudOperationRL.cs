using System.Data.SqlClient;
using System.Runtime.InteropServices.Marshalling;
using BackendStudentManagement.CommonLayer.Model;

namespace BackendStudentManagement.RepositoryLayer
{


    public class CrudOperationRL : ICrudOperationRL
    {

        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Sucessful";
            try
            {
                string SqlQuery = "Insert Into CrudOperationTable (Username, Subjects, Sections) values (@Username, @Subjects, @Sections)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Username", request.Username);
                    sqlCommand.Parameters.AddWithValue("@Subjects", request.Subjects);
                    sqlCommand.Parameters.AddWithValue("@Sections", request.Sections);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status == 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Succesful";
            try
            {
                string SqlQuery = "SELECT Username, Subjects, Sections FROM CrudOperationTable;";

                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while(await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.Username = sqlDataReader["Username"] != DBNull.Value ? sqlDataReader["Username"].ToString() : string.Empty;
                                dbData.Subjects = sqlDataReader["Subjects"] != DBNull.Value ? sqlDataReader["Subjects"].ToString() : string.Empty;
                                dbData.Sections = sqlDataReader["Sections"] != DBNull.Value ? sqlDataReader["Sections"].ToString() : string.Empty;
                                response.readRecordData.Add(dbData);
                            }    
                        }
                    }    
                }


            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }


        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Succesful";

            try
            {
                string SqlQuery = "Update CrudOperationTable Set Username = @Username,  Subjects = @Subjects, Sections = @Sections Where ID = @ID";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Username", request.Username);
                    sqlCommand.Parameters.AddWithValue("@Subjects", request.Subjects);
                    sqlCommand.Parameters.AddWithValue("@Sections", request.Sections);
                    sqlCommand.Parameters.AddWithValue("@ID", request.ID);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

 
    }
}

