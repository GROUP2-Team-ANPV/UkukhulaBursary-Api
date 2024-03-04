using BusinessLogic;
using DataAccess.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BursaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityAdminController : ControllerBase
    {
        private readonly UniversityAdminBLL _UniversityAdminBLL;


        public UniversityAdminController(UniversityAdminBLL StudentFundRequestBLL)
        {
            _UniversityAdminBLL = StudentFundRequestBLL;

        }

        [HttpGet("GetAllStudents")]
        [Authorize]
        public ActionResult<IEnumerable<GetAllStudents>> GetAllStudents()
        {
            try
            {
                var requests = _UniversityAdminBLL.GetAllStudents();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving student fund requests: {ex.Message}");
            }
        }
        [HttpGet("GetStudentsByUniversityID")]
        [Authorize]
        public ActionResult<IEnumerable<GetAllStudents>> GetAllStudents(int universityID)
        {
            try
            {
                var students = _UniversityAdminBLL.GetStudentsByUniversityID(universityID);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving students: {ex.Message}");
            }
        }
        [HttpGet("GetUniversityAndTheirStudents")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult<UniversityDTO> GetUniversityAndTheirStudents(int universityID)
        {
            try
            {
                var university = _UniversityAdminBLL.GetUniversityAndTheirStudents(universityID);
                return Ok(university);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving students: {ex.Message}");
            }
        }

        [HttpGet("GetStudentByID")]
        [Authorize]
        public ActionResult<IEnumerable<GetAllStudents>> GetStudentsByID(int studentID)
        {
            try
            {
                var student = _UniversityAdminBLL.GetStudentByID(studentID);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound($"Student with ID {studentID} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving students: {ex.Message}");
            }
        }



        [HttpPost("StudentFundRequest")]
        [Authorize(Roles = Roles.UniversityAdmin)]
        public ActionResult Create([FromBody] StudentFundRequest newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _UniversityAdminBLL.Create(newRequest);
                return Ok(new { message = "Student fund request created successfully!", status = "success" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating student fund request");
            }
        }

        [HttpGet("GetAllFundRequests")]
        [Authorize]
        public ActionResult<IEnumerable<FundRequest>> GetAllFundRequests()
        {
            try
            {
                var requests = _UniversityAdminBLL.GetAllFundRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving student fund requests: {ex.Message}");
            }
        }
        [HttpGet("GetFundRequestByID")]
        [Authorize]
        public ActionResult<IEnumerable<FundRequest>> GetFundRequestByID(int FundID)
        {
            try
            {
                var requests = _UniversityAdminBLL.GetFundRequestByID(FundID);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving student fund requests: {ex.Message}");
            }
        }


        [HttpPut("UpdateFundRequest/{FundRequestID}")]
        [Authorize]
        public ActionResult UpdateFundRequest(int FundRequestID, [FromBody] UpdateFundRequest updatedRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _UniversityAdminBLL.UpdateFundRequest(FundRequestID, updatedRequest);
                return Ok(new { message = "Student fund request successfully!", status = "success" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Student fund request not found!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating student fund request: {ex.Message}");
            }
        }

        [HttpGet("GetDocumentByFundRequestID")]
        [Authorize]
        public ActionResult<IEnumerable<GetDocument>> GetDocumentByFundRequestID(int FundID)
        {
            try
            {
                var requests = _UniversityAdminBLL.GetDocumentByFundRequestID(FundID);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving documents: {ex.Message}");
            }
        }

        [HttpGet("GetUniversityAmount")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult<IEnumerable<UniversityAmount>> GetUniversityAmount()
        {
            try
            {
                var requests = _UniversityAdminBLL.GetUniversityAmounts();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving documents: {ex.Message}");
            }
        }


        [HttpDelete("DeleteFundRequest/{FundRequestID}")]
        [Authorize(Roles = Roles.UniversityAdmin)]
        public ActionResult DeleteFundRequest(int FundRequestID)
        {
            try
            {
                var deleted = _UniversityAdminBLL.DeleteFundRequest(FundRequestID);

                if (deleted)
                {
                    return Ok("Student fund request deleted successfully!");
                }
                else
                {
                    return NotFound("Student fund request not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting student fund request: {ex.Message}");
            }
        }





    }
}