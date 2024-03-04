using BusinessLogic;
using DataAccess.Models;
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
        [Authorize]
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



        [HttpPost("AddUniversity")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult Create([FromBody] AddUniversityAndUser newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _BBDAdminBLL.AddUniversity(newRequest);
                
                return Ok(new { message = "University created successfully!", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $" Error adding University: {ex.Message}");
            }
        }
        [HttpPost("AddUniversityUser")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult AddUniversityUser([FromBody] AddUniversityUser newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _BBDAdminBLL.AddUniversityUser(newRequest);
                return Ok(new { message = "University user added successfully!", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating university user: {ex.Message}");
            }
        }

        [HttpGet("GetUniversityUsers")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult<IEnumerable<GetUsers>> GetUniversityUsers()
        {
            try
            {
                var requests = _BBDAdminBLL.GetUniversityUsers();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving users: {ex.Message}");
            }
        }

        [HttpGet("GetUserByUniversityID")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult<IEnumerable<GetUsers>> GetUserByUniversityID(int UniversityID)
        {
            try
            {
                var requests = _BBDAdminBLL.GetUserByUniversityID(UniversityID);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving universities: {ex.Message}");
            }
        }


        [HttpPost("{applicationId}/approve")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult ApproveApplication(int applicationId)
        {
            try
            {
                _BBDAdminBLL.ApproveApplication(applicationId);
                 return Ok(new { message = "application approved successfully!", status = "success" });
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error approving application: {ex.Message}");
            }
        }

        
        [HttpPost("{applicationId}/reject")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult RejectApplication(int applicationId, string comment)
        {
            try
            {
                _BBDAdminBLL.RejectApplication(applicationId, comment);
                return Ok(new { message = "Application rejected successfully", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error rejecting application: {ex.Message}");
            }
        }


        [HttpGet("GetAllBBDFunds")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult<IEnumerable<BBDFund>> BBDFund()
        {
            try
            {
                var requests = _BBDAdminBLL.BBDFund();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving universities: {ex.Message}");
            }
        }

        [HttpPut("{applicationId}/UpdateStatus")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult UpdateStatus(int applicationId, [FromBody] DataAccess.Models.UpdateStatus updateStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _BBDAdminBLL.UpdateStatus(applicationId, updateStatus.status, updateStatus.comment);
                return Ok(new { message = "status updated successfully!", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating status: {ex.Message}");
            }
        }


        [HttpPut("UpdateUniversityFunds")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult AllocateFunds()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _BBDAdminBLL.AllocateFunds();
                return Ok(new { message = "Fund allocated successfully!", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating status: {ex.Message}");
            }
        }



        [HttpPost("AllocateUniversityFund")]
        [Authorize(Roles = Roles.BBDAdmin)]
        public ActionResult AllocateUniversityFund([FromBody] AllocateFunds newRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _BBDAdminBLL.AllocateUniversityFunds(newRequest);
                return Ok(new { message = "funds loaded successfully!", status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error loading: {ex.Message}");
            }
        }


    }
}