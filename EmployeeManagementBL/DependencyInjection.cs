using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagementDAL.Interface;
using EmployeeManagementDAL;
//using EmployeeManagementDAL.EmployeeRepo;

namespace EmployeeManagementBL
{
    public static class Injection
    {
        public static void DependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<EmployeeRepoInterface, EmployeeRepo>();

        }
    }
}
