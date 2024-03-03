using BusinessLogic;
using DataAccess.Models;
using DataAccess.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace BursaryManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserBLL userManager) : ControllerBase
    {
        private readonly UserBLL _userManager = userManager;


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(string email)
        {
            if (ModelState.IsValid)
            {
                UserManagerResponse result = await _userManager.LoginUserAsync(email);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }


    }
}