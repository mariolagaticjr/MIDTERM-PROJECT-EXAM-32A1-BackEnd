using BackendStudentManagement.CommonLayer.Model;
using BackendStudentManagement.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationsController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOperationSL;

            public  CrudOperationsController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpGet]
        [Route ("ReadRecord")]
        public async Task<IActionResult> ReadRecord(int ID)
        {
            ReadRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.ReadRecord();
            }catch(Exception ex)
            {

            }
            return Ok(response);    
        }
        [HttpPut]
        [Route ("UpdateRecord")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {

            }
            return Ok(response);
        }
    }
}

