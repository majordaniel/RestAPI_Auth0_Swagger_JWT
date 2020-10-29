using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{

    public class LoginRequest
    {

        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string audience { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string client_secret { get; set; }
    }
}
