using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestAPIwithAuth0.Business.Helpers;
using RestAPIwithAuth0.Business.Interfaces;
using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Implementations
{
    public class AuthService : IAuth
    {

        /// <summary>
        /// Property Declaration
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IConfiguration _config;
        IAudit _audit;


        /// <summary>
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)
        /// </summary>
        public AuthService(IConfiguration config,

            IAudit audit
            )
        {
            _config = config;
            _audit = audit;
        }
        public async Task<ServiceResponse> Login(LoginModel data)
        {

            try
            {

                var TokenParameters = new LoginResDto();

                var _tokenGen = new TokenGenerator(_config);

                var dataToAPI = new LoginRequest
                {
                    audience = _config["Auth0:audience"],
                    client_id = _config["Auth0:client_id"],
                    client_secret = _config["Auth0:client_secret"],
                    grant_type = _config["Auth0:grant_type"],
                    username = data.UserName,
                    password = data.Password

                };
                var URi = _config["Auth0:domain"];

                if (data != null)
                {

                    #region Irrlv


                    //using (var httpClient = new HttpClient())
                    //{

                    //    //HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    //    //response = await client.PutAsync(requestUri, content);

                    //    StringContent content = new StringContent(JsonConvert.SerializeObject(dataToAPI), Encoding.UTF8, "application/json");
                    //  var   resp = await httpClient.PostAsync($"https://{URi}/oauth/token", content);

                    //}

                    #endregion
                    var httpClient = new HttpClient();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dataToAPI), Encoding.UTF8, "application/json");
                    var resp = await httpClient.PostAsync($"https://{URi}/oauth/token", content);
                    httpClient.Dispose();
                    var tokenString1 = "";
                    ServiceResponse tokenString = new ServiceResponse();

                    if (resp.IsSuccessStatusCode)
                    {
                        tokenString1 = _tokenGen.GenerateJSONWebToken();
                        tokenString = _tokenGen.CreateAccessToken(data);
                    }
                    else
                    {
                        tokenString = new ServiceResponse
                        {

                            data = null,
                            response = "No Token",
                            status = false
                        };
                    }

                    // TokenParameters.Response = tokenString;
                    TokenParameters.expires_in = DateTime.Now.AddMinutes(120).ToString();
                    TokenParameters.token = tokenString1;
                }


                return new ServiceResponse
                {
                    response = "The Sign In was Successful",
                    data = TokenParameters,
                    status = true

                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse { status = false, response = ex.Message };
            }
        }

        public async Task<ServiceResponse> SignUp(SignUpRequestModel data)
        {

            try
            {


                var signupresp = new SignUpResDto();
                var dataForSignUp = new SignupRequest
                {
                    client_id = _config["Auth0:client_id"],
                    connection = _config["Auth0:connection"],
                    email = data.Email,
                    password = data.Password


                };
                var URi = _config["Auth0:domain"];
                if (data != null)
                {
                    var httpClient = new HttpClient();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dataForSignUp), Encoding.UTF8, "application/json");
                    var resp = await httpClient.PostAsync($"https://{URi}/dbconnections/signup ", content);
                    httpClient.Dispose();


                    if (resp.IsSuccessStatusCode)
                    {
                        signupresp.status = true;
                        signupresp.response = "Profile Created";

                    }
                    else
                    {
                        signupresp.status = false;
                        signupresp.response = "Profile not Created";
                    }
                }

                return new ServiceResponse
                {
                    response = $"The Sign Up Operation was completed with response {signupresp.response} ",
                    data = signupresp,
                    status = signupresp.status

                };


            }
            catch (Exception ex)
            {
                return new ServiceResponse { status = false, response = ex.Message };
            }

        }
    }
}
