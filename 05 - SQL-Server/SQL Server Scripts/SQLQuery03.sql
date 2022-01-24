-- crud

select *
from Employees 
where FirstName = 'DavID'
order by FirstName, LastName ASC;

select [Name] from Departments; --3

select * from Departments; --2

select FirstName, LastName, Salary
from Employees; --4

select FirstName, MiddleName, LastName
from Employees; --5

select FirstName + '.' + LastName + '@uni.edu' as Email
from Employees; --6

select distinct Salary
from Employees; --7

select *
from Employees 
where JobTitle like 'Sales Representative';  --8

select *
from Employees 
where Salary between 20000 and 30000; --9

select FirstName + ' ' + MiddleName + ' ' + LastName as FullName
from Employees 
where MiddleName is not null 
	and Salary in (25000, 14000, 12500, 23600); --10

select FirstName, LastName
from Employees 
where ManagerID is null; --11

select *
from Employees 
where Salary > 50000 --12

select top(5) *
from Employees 
order by Salary desc --13

select *
from Employees 
where DepartmentID != 4 --14

-- 285 no marketing , 293 all, 8 marketing

select *
from Employees 
order by Salary desc, FirstName asc, LastName desc, MiddleName asc --15

create view V_EmployeesSalaries as
select FirstName, LastName, Salary
from Employees --16

go

select * from V_EmployeesSalaries

create view V_EmployeeNameJobTitle as
select FirstName + ' ' + ISNULL(MiddleName, '')  + ' ' + LastName as FullName, JobTitle
from Employees
where MiddleName is not null

select * from V_EmployeesSalaries
--17

select distinct JobTitle 
from Employees --18

select top(10) * 
from Projects 
order by StartDate asc --19

select top(7) * 
from Employees 
order by HireDate desc --20


UPDATE Employees
set Salary *= 1.12
where DepartmentID in (1,2,4,11)
--21

select *
from Employees
where JobTitle 
like ('%engineering%', 
'%tool design%', 
'%marketing%' or '%information services%')


select PeakName
from Peaks 
order by PeakName asc --22

select CountryName, [Population]
from Countries
where ContinentCode = 'EU'
order by [Population] desc, CountryName desc --23


select CountryName, CountryCode, CurrencyCode,
case
	when CurrencyCode = 'EUR' then 'Euro'
	else 'Not Euro'
end as Currency
from Countries
order by CountryName --24


select [Name]
from Characters
order by [Name] asc
--25