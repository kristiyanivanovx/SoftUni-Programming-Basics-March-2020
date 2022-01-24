select FirstName + ' ' + LastName as [Full Name], *
from Employees
where salary > 1000 and Salary < 40000;

select FirstName + ' ' + LastName as [Full Name], *
from Employees
where DepartmentID = 1 or 
	  DepartmentID = 2 or 
	  DepartmentID = 3 or 
	  DepartmentID = 4 or	
	  DepartmentID = 5;

select *
from Employees
where DepartmentID in (1,2,3,4,5);

select *
from Employees
where MiddleName is null;

select * from EmployeesProjects;

-----------------------------

use SoftUni;

select DepartmentID, min(Salary) as MinSalary, COUNT(*) as [RowCount]
from Employees
group by DepartmentID;