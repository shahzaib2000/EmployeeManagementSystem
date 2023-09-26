using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementModels;
using EmployeeManagementDAL;


namespace EmployeeManagementBL.Interface
{
    public interface EmployeeServiceInterface
    {
        public List<EmployeeManagementModels.Employee> GetEmployees();

        public void AddEmployeeToList(Employee employeetoadd);

        public Employee GetEmployeeByIdService(int id);


        public void updateEmployeeInList(int id, Employee emp) { }

        public void deleteEmployeeByIdService(int id) { }

    }
}
