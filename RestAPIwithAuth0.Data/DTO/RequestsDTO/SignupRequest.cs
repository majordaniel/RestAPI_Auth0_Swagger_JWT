using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{
    public class SignupRequest
    {

        public string client_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string connection { get; set; }
    }
}
