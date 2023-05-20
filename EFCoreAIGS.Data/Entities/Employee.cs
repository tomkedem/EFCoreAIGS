using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreproject.Data
{
    public class Employee
    {
        public Employee()
        {
            SpendingDetails = new List<SpendingDetail>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Hired { get; set; }

        [NotMapped]
        public decimal TotalSpendings { get; set; }
        public List<SpendingDetail> SpendingDetails { get; set; }
    }
}
