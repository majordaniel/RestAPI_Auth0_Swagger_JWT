using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.ResponseDTO
{
    public class LoginResDto
    {
       // public ServiceResponse Response { get; set; }
        public string expires_in { get; set; }
        public string token { get; set; }


    }
}
