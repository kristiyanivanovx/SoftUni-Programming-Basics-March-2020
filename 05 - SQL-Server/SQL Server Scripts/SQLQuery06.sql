-- subqueries and joins exercise

use SoftUni

-- 1
select top(5) e.EmployeeID, e.JobTitle, e.AddressId, a.AddressText
from Employees as e
join Addresses as a on a.AddressID = e.AddressID 
order by a.AddressID

select * 
from Employees

select * 
from Addresses

-- 2

select top(50) e.FirstName, e.LastName, t.Name, a.AddressText
from Employees as e
join Addresses as a on a.AddressID = e.AddressID
join Towns as t on t.TownID = a.TownID
order by e.FirstName, e.LastName 

-- 3
--select top(50) e.FirstName, e.LastName, t.Name, a.AddressText
select e.EmployeeID, e.FirstName, e.LastName, d.Name as DepartmentName
from Employees as e
join Departments as d on e.DepartmentID = d.DepartmentID
where d.Name like '%Sales%'
order by e.EmployeeID

-- 4
select top(5) e.EmployeeID, e.FirstName, e.Salary, d.Name as DepartmentName
from Employees as e
join Departments as d on e.DepartmentID = d.DepartmentID
where e.Salary > 15000
order by d.DepartmentID

-- 5
select top(3) e.EmployeeID, e.FirstName
from Employees as e
left join EmployeesProjects as ep on ep.EmployeeID = e.EmployeeID
where ep.EmployeeID is null
order by e.EmployeeID

-- 6
select FirstName, LastName, HireDate, d.Name as DeptName
from Employees as e
join Departments as d on e.DepartmentID = d.DepartmentID
where e.HireDate > '1.1.1999' and d.Name in ('Finance', 'Sales')
order by e.HireDate

-- 7
select top(5) e.EmployeeID, e.FirstName, p.Name
from Employees as e
join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
where p.StartDate > CONVERT(datetime, '13.08.2002', 104) and p.EndDate is null
order by e.EmployeeID

-- 8
select e.EmployeeID, 
		e.FirstName,
		case
			when DATEPART(YEAR, p.StartDate) >= 2005 then NULL
			else p.Name
		end as ProjectName
from Employees as e
join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
where e.EmployeeID = 24 
order by e.EmployeeID

-- 9
select emp.EmployeeID, emp.FirstName, emp.LastName, emp.ManagerID
from Employees as emp
join Employees as mng on mng.EmployeeId = emp.ManagerID
order by EmployeeID 

-- 10
select top(50) emp.EmployeeID, emp.FirstName + ' ' + emp.LastName as EmployeeName, 
	mng.FirstName + ' ' + mng.LastName, dep.Name
from Employees as emp
join Employees as mng on mng.EmployeeId = emp.ManagerID
join Departments as dep on dep.DepartmentID = emp.DepartmentID
order by emp.EmployeeID 

-- 11
select top(1) e.DepartmentID, avg(Salary) as AverageSalary
from Employees as e
join Departments as d on d.DepartmentID = e.DepartmentID
group by e.DepartmentID
order by AverageSalary 

-- 12 // geography
use Geography

select c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
from Countries as c
join MountainsCountries as mc on mc.CountryCode = c.CountryCode
join Mountains as m on m.Id = mc.MountainId
join Peaks as p on p.MountainId = mc.MountainId
where p.Elevation > 2835 and c.CountryName like '%Bulgaria%'
order by p.Elevation desc

-- 13
select c.CountryCode, COUNT(*) 
from Countries as c
join MountainsCountries as mc on mc.CountryCode = c.CountryCode
where mc.CountryCode in ('bg', 'ru', 'us')
group by c.CountryCode

-- 14
select top(5) CountryName, RiverName
from Countries as c
left join CountriesRivers as cr on cr.CountryCode = c.CountryCode
left join Rivers as r on r.Id = cr.RiverId
where c.ContinentCode = 'AF'
order by CountryName

-- 15
select ContinentCode, CurrencyCode, Total
from (
	select ContinentCode, CurrencyCode, COUNT(CurrencyCode) as Total,
		DENSE_RANK() over(partition by ContinentCode order by Count(CurrencyCode) desc)
			as Ranked
		from Countries
	group by ContinentCode, CurrencyCode
) as k
	where Ranked = 1 and Total > 1
order by ContinentCode

-- 16
select COUNT(*)
from Countries as c
left join MountainsCountries as mc on mc.CountryCode = c.CountryCode
where mc.MountainId is null

-- 17
select top(5)
	CountryName, 
	max(p.Elevation) as HighestPeak,
	max(r.Length) as LongestRiver

	from Countries as c
	left join MountainsCountries as mc on mc.CountryCode = c.CountryCode
	left join Mountains as m on m.Id = mc.MountainId
	left join Peaks as p on p.MountainId = m.Id
	left join CountriesRivers as cr on cr.CountryCode = c.CountryCode
	left join Rivers as r on r.Id = cr.RiverId
group by CountryName
order by HighestPeak desc, LongestRiver desc, CountryName

-- 18
select top(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange from (
select  CountryName, 
		ISNULL(p.PeakName, '(no highest peak)') as PeakName, 
		ISNULL(m.MountainRange, '(no mountain)') as MountainRange,
		ISNULL(MAX(p.Elevation), 0) as HighestPeak,
		DENSE_RANK() over 
			(partition by CountryName order by MAX(p.Elevation) desc) as Ranked
	from Countries as c
	left join MountainsCountries as mc on mc.CountryCode = c.CountryCode
	left join Mountains as m on m.Id = mc.MountainId
	left join Peaks as p on p.MountainId = m.Id
group by CountryName,  p.PeakName, m.MountainRange) as k
where Ranked = 1 
order by CountryName, PeakName
