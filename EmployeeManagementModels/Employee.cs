using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementModels
{
   
        [Table("Employee", Schema = "configuration")]
        public class Employee
        {
            [Column("Id")]
            public virtual int Id { get; set; }

            [Column("Name")]
            public virtual string Name { get; set; }

            [Column("Designation")]
            public virtual string? Designation { get; set; }

            [Column("Department")]
            public virtual string? Department { get; set; }


        }
}