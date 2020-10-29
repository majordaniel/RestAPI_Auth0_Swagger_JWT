using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Interfaces
{
    public interface IAuth
    {

        Task<ServiceResponse> Login(LoginModel data);
        Task<ServiceResponse> SignUp(SignUpRequestModel data);
    }
}
