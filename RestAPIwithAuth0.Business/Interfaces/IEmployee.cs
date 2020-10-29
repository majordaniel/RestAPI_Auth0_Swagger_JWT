using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Interfaces
{
   public interface IEmployee
    {
         Task<ServiceResponse> AddEmployee(Employee model);
         Task<ServiceResponse> EditEmployee(Employee model);
         Task<ServiceResponse> GetEmployee(int Id);
         Task<ServiceResponse> GetAllEmployees();
         Task<ServiceResponse> RemoveEmployee(Employee model);
    }
}
