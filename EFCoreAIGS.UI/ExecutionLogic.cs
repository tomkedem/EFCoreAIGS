using EFCoreAIGS.Data;
using EFCoreproject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAIGS.UI
{
    public class ExecutionLogic
    {
        public ExecutionLogic()
        {
                
        }

        internal void Execute()
        {
            // AddNewEmployee("Natasha", "Pawker");
             ReadAllEmployees();
            //AddARangeEmployees();
            //FilterAndOrderEmployees();

            //FindAndModifyEmployeeName();
            //QueryGreeneToConsole();
            // AddSpendingDetails();
            //  PrintGreeneTotalSpendings();

            //LoadEmployeesNoTracking();
        }

        

        private void AddARangeEmployees()
        {
            var employeeList = new List<Employee>();

            var employee = new Employee
            {
                FirstName = "Janny",
                LastName = "Smith",
                Hired = DateTime.Now
            };

            employeeList.Add(employee);

            employee = new Employee
            {
                FirstName = "Joseph",
                LastName = "Smith",
                Hired = DateTime.Now
            };

            employeeList.Add(employee);

            employee = new Employee
            {
                FirstName = "Ronald",
                LastName = "Smith",
                Hired = DateTime.Now
            };

            employeeList.Add(employee);

            employee = new Employee
            {
                FirstName = "Jennifer",
                LastName = "Smith",
                Hired = DateTime.Now
            };
            employeeList.Add(employee);


            using var db = new AIGSContext();

            db.Employees.AddRange(employeeList);
            db.SaveChanges();
        }


        private void AddNewEmployee(string firstName, string lastName)
        {
            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Hired = DateTime.Now
            };

            using var db = new AIGSContext();

            db.Employees.Add(employee);
            db.SaveChanges();
        }

        private void ReadAllEmployees()
        {
            using var db = new AIGSContext();

            var allEmployees = db.Employees
                    //.Where(x => x.FirstName == "Natasha")
                    .ToList();

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.FirstName}, {employee.LastName}, EmployeeId {employee.EmployeeId}");
            }
        }

        private void FilterAndOrderEmployees()
        {
            using var db = new AIGSContext();

            var employees = db.Employees
                    .Where(x => x.FirstName.Length > 4)
                    .OrderBy(x => x.FirstName)
                    .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName}, {employee.LastName}, EmployeeId {employee.EmployeeId}");
            }
        }

        private void FindAndModifyEmployeeName()
        {
            using var db = new AIGSContext();

            var secondEmployee = db.Employees
                    .Where(x => x.FirstName.StartsWith("J"))
                    .Skip(1)
                    .OrderBy(x => x.EmployeeId)
                    .First();

            const string employeeNewName = "Greene";

            secondEmployee.LastName = employeeNewName;

            db.SaveChanges();

        }

        private void QueryGreeneToConsole()
        {
            using var db = new AIGSContext();
            const string employeeNewName = "Greene";

            var employee = db.Employees
                   .First(x => x.LastName == employeeNewName);                   
                   

            Console.WriteLine($"{employee.FirstName}, {employee.LastName}, EmployeeId {employee.EmployeeId}");
        }
        private void AddSpendingDetails()
        {
            using var db = new AIGSContext();
            const string employeeNewName = "Greene";

            var greenEmployee = db.Employees
                   .First(x => x.LastName == employeeNewName);
           

            var SpendingDetailList = new List<SpendingDetail>();

            greenEmployee.SpendingDetails.Add(new SpendingDetail
            {
                SpentOn = "PC",
                Amount = 5500               
            });

            greenEmployee.SpendingDetails.Add(new SpendingDetail
            {
                SpentOn = "Monitor",
                Amount = 1200
            });

            greenEmployee.SpendingDetails.Add(new SpendingDetail
            {
                SpentOn = "Desk",
                Amount = 1200
            });  


            db.SaveChanges();

           
        }

        private void PrintGreeneTotalSpendings()
        {
            using var db = new AIGSContext();
            const string employeeNewName = "Greene";

            var greenEmployee = db.Employees
                        .Include(x => x.SpendingDetails)   
                        .First(x => x.LastName == employeeNewName);

            greenEmployee.TotalSpendings = greenEmployee.SpendingDetails.Sum(x => x.Amount);
           
            Console.WriteLine("Total: " + greenEmployee.TotalSpendings);
        }

        private void LoadEmployeesNoTracking()
        {
            using var db = new AIGSContext();

            var employees = db.Employees.AsNoTracking().ToList();
            //var employees = db.Employees.ToList();
            foreach (var employee in employees)
            {
                employee.LastName = "Greene";
                employee.Hired = employee.Hired.AddDays(-30);
            }

            db.SaveChanges();
        }
    }
}
