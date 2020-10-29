using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.ResponseDTO
{
    public class ServiceResponse
    {
        public bool status { get; set; }
        public object data { get; set; }
        public string response { get; set; }
    }
}
