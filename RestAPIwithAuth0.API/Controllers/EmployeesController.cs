using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPIwithAuth0.Business.Helpers;
using RestAPIwithAuth0.Business.Interfaces;
using RestAPIwithAuth0.Data.Configs;
using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.DTO.ResponseDTO;
using RestAPIwithAuth0.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIwithAuth0.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        IEmployee _employee;
        IMapper _mapper;

        public EmployeesController(ApplicationDbContext dbContext,
            IEmployee employee,
            IMapper mapper
            )
        {
            _dbContext = dbContext;
            _employee = employee;
            _mapper = mapper;
        }

        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(typeof(APIResponse<List<EmployeesResponseModel>>), 200)]
        [ProducesResponseType(typeof(APIResponse), 400)]
        [Authorize]
       // [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllEmplyees()
        {
            try
            {
                var result = await _employee.GetAllEmployees();

                return Ok(new APIResponse { data = result.data, message = "Employees Retrieved Successfully" });
            }
            catch (AppException ex)
            {
                return BadRequest(new APIResponse { data = ex.Message });
            }

        }

        [HttpPut("CreateEmployee")]
        [ProducesResponseType(typeof(APIResponse<EmployeesResponseModel>), 200)]
        [ProducesResponseType(typeof(APIResponse), 400)]
        //[Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> CreateEmployee(EmployeeRequestModel model)
        {
            try
            {
                var modelToCreate = _mapper.Map<Employee>(model);

                var result = await _employee.AddEmployee(modelToCreate);

                return Ok(new APIResponse { data = result.data, message = "Employee Created Successfully" });
            }
            catch (AppException ex)
            {
                return BadRequest(new APIResponse { data = ex.Message });
            }

        }


    }
}
