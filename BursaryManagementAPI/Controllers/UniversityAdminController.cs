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
        public ActionResult<UniversityDTO> GetUniversityAndTheirStudents(int universityID) {
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
        public ActionResult Create([FromBody] StudentFundRequest newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _UniversityAdminBLL.Create(newRequest);
                return Ok(new { message = "Student fund request created successfully!" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creating student fund request" });
            }
        }

        [HttpGet("GetAllFundRequests")]
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
        public ActionResult UpdateFundRequest(int FundRequestID, [FromBody] UpdateFundRequest updatedRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _UniversityAdminBLL.UpdateFundRequest(FundRequestID, updatedRequest);
                return Ok("Student fund request updated successfully!");
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

    }
}