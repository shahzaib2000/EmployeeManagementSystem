using EmployeeManagementBL.Interface;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeServiceInterface employeeServiceinstance;

        public EmployeeController(EmployeeServiceInterface employeeService)
        {
            this.employeeServiceinstance = employeeService;
        }

        [Route("")]
        [HttpGet]



        public IEnumerable<Response> GetEmployees()
        {
            IEnumerable<Employee> finalemployee = employeeServiceinstance.GetEmployees();

            IEnumerable<Response> Finalresponse = finalemployee.Select(employee => new Response
            {
                Id = employee.Id,
                Name = employee.Name,
                Designation = employee.Designation,
                Department = employee.Department,
            });
            return Finalresponse;
        }

        [Route("{id}")]
        [HttpGet]

        public Response GetEmployeeById(int id)
        {
            Employee finalemployee = employeeServiceinstance.GetEmployeeByIdService(id);

            Response Finalresponse = new Response();

            Finalresponse.Id = finalemployee.Id;
            Finalresponse.Name = finalemployee.Name;
            Finalresponse.Designation = finalemployee.Designation;
            Finalresponse.Department = finalemployee.Department;
            
            return Finalresponse;
        }

        [Route("")]
        [HttpPost]

        public string AddEmployee(Request EmployeeRequest)
        {
            Employee emp = new Employee();

            emp.Name = EmployeeRequest.Name;
            emp.Designation = EmployeeRequest.Designation;
            emp.Department = EmployeeRequest.Department;

            employeeServiceinstance.AddEmployeeToList(emp);

            return "Employee added";
        }

        [Route("{id}")]
        [HttpPut]

        public string UpdateEmployee([FromRoute] int id, Request EmployeeRequest)
        {
            Employee emp = new Employee();

            emp.Id = id;
            emp.Name = EmployeeRequest.Name;
            emp.Designation = EmployeeRequest.Designation;
            emp.Department = EmployeeRequest.Department;

            employeeServiceinstance.updateEmployeeInList(id, emp);

            return "Employee details updated successfully";
        }

        [Route("{id}")]
        [HttpDelete]

        public string EmployeeDelete(int id)
        {
            employeeServiceinstance.deleteEmployeeByIdService(id);
            return "Employee with id "+ id +" has been deleted";
        }

    }
}

