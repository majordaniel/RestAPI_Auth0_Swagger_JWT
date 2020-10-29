using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{
   public class SignUpRequestModel
    {

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
