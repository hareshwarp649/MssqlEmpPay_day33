using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33MssqlEmpPayADO5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Employee Payroll Sql");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModal employee = new EmployeeModal();


            employee.EmployeeName = "Eren Jeager";
            employee.PhoneNumber = "8106529025";
            employee.Address = "25-4-710";
            employee.Department = "Hr";
            employee.Gender = 'M';
            employee.BasicPay = 22000;
            employee.Deductions = 1500;
            employee.TaxablePay = 200.00;
            employee.Tax = 300;
            employee.NetPay = 25000;
            employee.StartDate = DateTime.Now;
            employee.City = "Kazipet";
            employee.Country = "India";

            
            repo.Retrieve(employee);
        }
    }
}
