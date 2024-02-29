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
    public class ConstantTablesController : ControllerBase
    {
        private readonly ConstantTablesBLL _ConstantTablesBLL;
        

        public ConstantTablesController(ConstantTablesBLL StudentFundRequestBLL)
        {
            _ConstantTablesBLL = StudentFundRequestBLL;
            
        }

        [HttpGet("GetDepartment")]
        public ActionResult<IEnumerable<ConstantTables>> Department()
        {
            try
            {
                var requests = _ConstantTablesBLL.Department();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpGet("GetGender")]
        public ActionResult<IEnumerable<ConstantTables>> Gender()
        {
            try
            {
                var requests = _ConstantTablesBLL.Gender();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $" {ex.Message}");
            }
        }

        [HttpGet("GetProvinces")]
        public ActionResult<IEnumerable<ConstantTables>> Provinces()
        {
            try
            {
                var requests = _ConstantTablesBLL.Provinces();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpGet("GetRace")]
        public ActionResult<IEnumerable<ConstantTables>> Race()
        {
            try
            {
                var requests = _ConstantTablesBLL.Race();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }


    }
}