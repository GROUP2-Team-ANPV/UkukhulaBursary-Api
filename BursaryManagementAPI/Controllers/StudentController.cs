using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using System;
using System.Threading.Tasks;

namespace BursaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBLL _uploadDocumentBLL;

        public StudentController(StudentBLL uploadDocumentBLL)
        {
            _uploadDocumentBLL = uploadDocumentBLL;
        }

        [HttpPost("{requestID}/UploadDocument")]
        public async Task<ActionResult> UploadDocument(int requestID, [FromForm] BusinessLogic.Models.UploadDocument uploadDocument)
        {
            try
            {
                return await _uploadDocumentBLL.UploadDocument(requestID, uploadDocument);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading document: {ex.Message}");
            }
        }
    }
}
