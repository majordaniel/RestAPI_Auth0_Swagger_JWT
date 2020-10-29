using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.ResponseDTO
{
  public  class EmployeesResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
