using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{

    public class LoginModel
    {

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
