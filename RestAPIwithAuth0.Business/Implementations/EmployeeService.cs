using Microsoft.EntityFrameworkCore;
using RestAPIwithAuth0.Business.Interfaces;
using RestAPIwithAuth0.Data.Configs;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Implementations
{
   public class EmployeeService :IEmployee
    {

        ApplicationDbContext _dbContext;
        IAudit _auditService;
        public EmployeeService(ApplicationDbContext dbContext,
            IAudit auditService
            )
        {
            _dbContext = dbContext;
            _auditService = auditService;
        }

        public async Task<ServiceResponse> AddEmployee(Employee model)
        {
            int count = 0;

            if (model.Id == 0)
            {
                model = (await _dbContext.Employees.AddAsync(model)).Entity;
                count = await _dbContext.SaveChangesAsync();
            }
            return new ServiceResponse { data = model, status = count > 0 ? true : false, response = count > 0 ? "Education Inserted Successfully" : "Employee Creation failed" };

        }

        public async Task<ServiceResponse> EditEmployee(Employee model)
        {
            int count = 0;
            if (model.Id>0)
            {
                
                    model = _dbContext.Update(model).Entity;
                    count = await _dbContext.SaveChangesAsync();
                
            }
            return new ServiceResponse { data = model, status = count > 0 ? true : false, response = count > 0 ? "Employee Updated Successfully" : "Employee Update failed" };

        }

        public async Task<ServiceResponse> GetAllEmployees()
        {
            var AllEmployees = await _dbContext.Employees.ToListAsync();


            return new ServiceResponse { data = AllEmployees == null ? new List<Employee>() : AllEmployees, status = true };

        }

        public async Task<ServiceResponse> GetEmployee(int Id)
        {
            var Empl = await _dbContext.Employees.FirstOrDefaultAsync(x=>x.Id ==Id);
            return new ServiceResponse { data = Empl == null ? new Employee() : Empl, status = true };

        }

        public async Task<ServiceResponse> RemoveEmployee(Employee model)
        {
            int count = 0;
            model =  _dbContext.Remove(model).Entity;
            count = await _dbContext.SaveChangesAsync();


            return new ServiceResponse { data = model, status = count > 0 ? true : false, response = count > 0 ? "Employee Updated Successfully" : "Employee Update failed" };

        }
    }
}
