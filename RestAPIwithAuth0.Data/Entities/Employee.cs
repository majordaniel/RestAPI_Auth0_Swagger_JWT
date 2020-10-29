using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestAPIwithAuth0.Data.Entities
{
 public   class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string EmployeeNo { get; set; }
        public string Month { get; set; }
        public string EmployeeType { get; set; }
        public double MonthlyWage { get; set; } = 0;
        public double NetPay { get; set; } = 0;
    }
}
