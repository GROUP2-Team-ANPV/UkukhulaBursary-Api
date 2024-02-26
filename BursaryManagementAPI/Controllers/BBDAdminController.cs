using BusinessLogic;
using BusinessLogic.Models;
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
    public class BBDAdminController : ControllerBase
    {
        private readonly BBDAdminBLL _BBDAdminBLL;
        

        public BBDAdminController(BBDAdminBLL BBDAdminBLL)
        {            
            _BBDAdminBLL = BBDAdminBLL;
            
        }

        [HttpGet("GetAllUniversities")]
        public ActionResult<IEnumerable<GetAllUniversities>> GetAllRequests()
        {
            try
            {
                var requests = _BBDAdminBLL.GetAllRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving universities: {ex.Message}");
            }
        }

        [HttpGet("GetUniversityByID")]
        public ActionResult<IEnumerable<GetAllUniversities>> GetAllUniversityByID(int UniversityID)
        {
            try
            {
                var requests = _BBDAdminBLL.GetAllUniversityByID(UniversityID);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving universities: {ex.Message}");
            }
        }

        [HttpPost("AddUniversity")]
        public ActionResult Create([FromBody] AddUniversityAndUser newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _BBDAdminBLL.AddUniversity(newRequest);
                return Ok("Student fund request created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating student fund request: {ex.Message}");
            }
        }
        [HttpPost("AddUniversityUser")]
        public ActionResult AddUniversityUser([FromBody] AddUniversityUser newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _BBDAdminBLL.AddUniversityUser(newRequest);
                return Ok("User created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating university user: {ex.Message}");
            }
        }

        //[Authorize(Roles = Roles.BBDAdmin)]
        [HttpPost("{applicationId}/approve")]
        public ActionResult ApproveApplication(int applicationId)
        {
            try
            {
                _BBDAdminBLL.ApproveApplication(applicationId);
                return Ok("Application approved successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error approving application: {ex.Message}");
            }
        }

        //[Authorize(Roles = Roles.BBDAdmin)]
        [HttpPost("{applicationId}/reject")]
        public ActionResult RejectApplication(int applicationId, string comment)
        {
            try
            {
                _BBDAdminBLL.RejectApplication(applicationId, comment);
                return Ok("Application rejected successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error rejecting application: {ex.Message}");
            }
        }
    }
}