using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Helpers
{
  public  class TokenGenerator
    {

        /// <summary>
        /// Property Declaration
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IConfiguration _config;


        /// <summary>
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)
        /// </summary>
        public TokenGenerator(IConfiguration config)
        {
            _config = config;
        }


        /// <summary>
        /// Generate Json Web Token Method
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public ServiceResponse CreateAccessToken( LoginModel loginModel)
        {
            try
            {
                DateTime now = DateTime.UtcNow;
               // List<string> role = (List<string>)await _userManager.GetRolesAsync(User);

                var claims = new[] {

                    new Claim (ClaimTypes.Role,"User"),
                    new Claim (ClaimTypes.NameIdentifier,loginModel.UserName),
                };

                int tokenExpiration = _config.GetValue<int>("Jwt:TokenExpiration");
                var IsserSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                   audience: _config["Jwt:Issuer"],
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromHours(tokenExpiration)),
                    signingCredentials: new SigningCredentials(IsserSignKey, SecurityAlgorithms.HmacSha256)
                );

                var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
                var resp = new LoginResDto
                {
                    token = encodeToken,
                     expires_in = token.ValidTo.ToShortDateString()
                };
                return new ServiceResponse { data = resp, status = true, response ="Token Generated" };
            }
            catch
            {
                return new ServiceResponse { response = "Token generation failed", status = false };
            }
        }
    }
}
