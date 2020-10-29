using RestAPIwithAuth0.Data.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{
    public class EmployeeRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        [EnumDataType(typeof(MonthEnum))]
        public string Month { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeTypeEnum))]
        public string EmployeeType { get; set; }
        [Required]
        public double MonthlyWage { get; set; }
        [Required]
        public double NetPay { get; set; }
    }
}
