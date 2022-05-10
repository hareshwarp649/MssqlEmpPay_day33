﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33MssqlEmpPayADO5
{
    internal class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-C7TGR0I;Initial Catalog=Address_Book_System;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModal employeeModel = new EmployeeModal();
                using (this.connection)
                {
                    string query = @"SELECT EmployeeID,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country
                                    FROM Employee_payroll";
                    //Define Sql Command Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();


                    //check if there are records

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                            employeeModel.BasicPay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                            employeeModel.StartDate = dr.GetDateTime(11);
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);

                            //display retieved record

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.BasicPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    //Close Data Reader
                    dr.Close();
                    this.connection.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModal model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //UC - 3 and 4 
        public void Update(EmployeeModal model)
        {
            string query = @"Update Employee_payroll Set BasicPay=3000000.00 Where EmployeeName='Terisa'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EmployeeModal employeeModel = new EmployeeModal();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeeModel.EmployeeName = dr.GetString(1);
                    employeeModel.BasicPay = dr.GetDouble(6);
                    //display retieved record

                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.BasicPay);
                    Console.WriteLine("\n");
                }
            }

        }
        //UC - 5
        public void Retrieve(EmployeeModal model)
        {
            string query = @"Select * From Employee_payroll Where StartDate Between '1894-06-23' And '2022-04-07'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EmployeeModal employeeModel = new EmployeeModal();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeeModel.EmployeeID = dr.GetInt32(0);
                    employeeModel.EmployeeName = dr.GetString(1);
                    employeeModel.PhoneNumber = dr.GetString(2);
                    employeeModel.Address = dr.GetString(3);
                    employeeModel.Department = dr.GetString(4);
                    employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                    employeeModel.BasicPay = dr.GetDouble(6);
                    employeeModel.Deductions = dr.GetDouble(7);
                    employeeModel.TaxablePay = dr.GetDouble(8);
                    employeeModel.Tax = dr.GetDouble(9);
                    employeeModel.NetPay = dr.GetDouble(10);
                    employeeModel.StartDate = dr.GetDateTime(11);
                    employeeModel.City = dr.GetString(12);
                    employeeModel.Country = dr.GetString(13);
                    //display retieved record

                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.BasicPay);
                    Console.WriteLine("\n");
                }
            }
            this.connection.Close();

        }

    }
}