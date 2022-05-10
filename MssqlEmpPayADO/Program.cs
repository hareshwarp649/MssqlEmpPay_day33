using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MssqlEmpPayADO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Employee Payroll Sql");

            EmployeePay repo = new EmployeePay();
            EmployeeData employee = new EmployeeData();


            employee.EmployeeName = "Joseph Hitlar";
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

            //repo.AddEmployee(employee);
            repo.GetAllEmployee();



        
        }
    }
}
