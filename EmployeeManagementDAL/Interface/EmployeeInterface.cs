using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementModels;

namespace EmployeeManagementDAL.Interface
{
    public interface EmployeeRepoInterface
    {
        public List<Employee> GetEmployees();

        public void addEmployee(Employee emp);
        public void delEmployeebyId(int id);


        public Employee getEmployeeInfoById(int id);

        public void updateEmployee(int id, Employee emp);



    }
}
