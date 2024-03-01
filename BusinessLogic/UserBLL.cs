

using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Response;
using Microsoft.AspNetCore.Identity;

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

        public async Task<UserManagerResponse> LoginUserAsync(Login model)
        {
           // var user = await _userDAL.checkUserByEmail(model.Email);
            if ("user" == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email Address",
                    isSuccess = false,
                };
            }

            
            Claim[] claims = new[]
            {
                new Claim("Email", model.Email),
                //new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "BBD Admin")
                
            };
            //var roles = await _userDAL.getUserRoles(user);
           // var claimsWithRoles = roles.Select(role => new Claim(ClaimTypes.Role, role));
            //var allClaims = claims.Concat(claimsWithRoles);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
          //      claims: allClaims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenString,
                isSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

      

        public async Task<User> getUser(string email)
        {
            return _userDAL.getUserByEmail(email);

        }
    }
}
