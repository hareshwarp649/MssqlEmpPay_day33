create database Emp_Pay33;

(
@EmployeeName varchar(50),
@PhoneNumber varchar(12),
@Address varchar(20),
@Department varchar(20),
@Gender char,
@BasicPay float,
@Deductions float,
@TaxablePay float,
@Tax float,
@NetPay float,
@StartDate datetime ,
@City varchar(20),
@Country varchar(20)
)
as
begin 
insert into Employee_payroll values(@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay,@StartDate,@City,@Country)
End
