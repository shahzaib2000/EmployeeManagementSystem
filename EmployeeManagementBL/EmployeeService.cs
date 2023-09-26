using EmployeeManagementModels;
using EmployeeManagementDAL;
using EmployeeManagementDAL.Interface;
using EmployeeManagementBL.Interface;

namespace EmployeeManagementBL
{
    public class EmployeeService : EmployeeServiceInterface
    {
        private EmployeeRepoInterface EmployeeRepoInstance;

        public EmployeeService(EmployeeRepoInterface employeeRepo)
        {
            this.EmployeeRepoInstance = employeeRepo;
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeRepoInstance.GetEmployees();
        }

        public void AddEmployeeToList(Employee employeetoadd)
        {
            EmployeeRepoInstance.addEmployee(employeetoadd);
        }

        public Employee GetEmployeeByIdService(int id)
        {
            return EmployeeRepoInstance.getEmployeeInfoById(id);
        }

        public void updateEmployeeInList(int id, Employee emp)
        {

            Employee employee = EmployeeRepoInstance.getEmployeeInfoById(id);

            if (employee != null)
            {
                EmployeeRepoInstance.updateEmployee(id, emp);
            }
            else
            {
                Employee newemployee = new Employee();

                newemployee.Name = emp.Name;
                newemployee.Designation = emp.Designation;
                newemployee.Department = emp.Department;

                EmployeeRepoInstance.addEmployee(newemployee);
            }
        }

        public void deleteEmployeeByIdService(int id)
        {
            EmployeeRepoInstance.delEmployeebyId(id);
        }        
    }
}