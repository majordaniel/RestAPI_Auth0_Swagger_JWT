using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestAPIwithAuth0.Business.Helpers;
using RestAPIwithAuth0.Business.Interfaces;
using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;

namespace RestAPIwithAuth0.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RestAPIwithAuth0.API.Controllers.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        /// <summary>
        /// Property Declaration
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IConfiguration _config;
        IAuth _auth;


        /// <summary>
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)
        /// </summary>
        public AuthController(IConfiguration config,

            IAuth auth
            )
        {
            _config = config;
            _auth = auth;
        }




        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<LoginResDto> Login([FromBody] LoginModel data)
        {
            var response = await _auth.Login(data);

            var resp = response.data as LoginResDto;

            return resp;

        }

        [AllowAnonymous]
        [HttpPost(nameof(Signup))]
        public async Task<ServiceResponse> Signup([FromBody] SignUpRequestModel data)
        {

            var resp = await _auth.SignUp(data);


            return new ServiceResponse
            {

                data = resp.data,
                response = resp.response,
                status = resp.status

            };
        }

    }





}
