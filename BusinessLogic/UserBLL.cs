

using DataAccess;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic
{
    public class UserBLL
    {
        private UserDAL _userDAL;
        private IConfiguration _configuration;
        public UserBLL(UserDAL userDAL, IConfiguration configuration)
        {
            _configuration = configuration;
            _userDAL = userDAL;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(string email)
        {
            LoginDetailsDTO user = _userDAL.getUserByEmail(email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email Address",
                    isSuccess = false,
                };
            }


            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.FirstName ),
               new Claim (ClaimTypes.Surname, user.LastName),
               new Claim(ClaimTypes.Role , user.RoleType),
                (user.UniverisityID != null) ? new Claim(ClaimTypes.GroupSid, user.UniverisityID.ToString()):new Claim(ClaimTypes.GroupSid, "0")


            };
          

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenString,
                isSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

        
        public async Task<LoginDetailsDTO> getUser(string email)
        {
            return _userDAL.getUserByEmail(email);

        }
    }
}
