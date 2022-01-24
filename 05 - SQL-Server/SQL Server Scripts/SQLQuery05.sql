-- built in functions exercise

use SoftUni

-- 1
select FirstName, LastName
from Employees
where FirstName like 'sa%'

-- 2
select FirstName, LastName
from Employees
where LastName like '%ei%'

-- 3 
select FirstName , HireDate, DepartmentID
from Employees
where DepartmentID in (3, 10)
and HireDate between convert(datetime, '1994') 
and convert(datetime,  '2006') 
-- non inclusive, so its returning 1995-2005

-- 4
select FirstName, LastName, JobTitle
from Employees
where JobTitle not like '%engineer%'

-- 5 
select [Name] from Towns
where len([Name]) in (5, 6) order by [Name] asc

-- 6 
select TownID, [Name] 
from Towns
where [Name] like '[MKBE]%'
--where left(Name, 1) in ('M', 'K', 'B', 'E')
order by [Name] asc

-- 7
select TownID, [Name] 
from Towns
where [Name] not like '[RBD]%'
order by [Name] asc

-- 8
create view V_EmployeesHiredAfter2000 as
select FirstName, LastName
from Employees
where DATEPART(YEAR, HireDate) > 2000
--where HireDate > CONVERT(date, '2001')

-- 9
select FirstName, LastName
from Employees
where len(LastName) in (5)

-- 10
select EmployeeID, FirstName, LastName, Salary, 
DENSE_RANK() over (partition by Salary order by EmployeeID) as [Rank]
from Employees
where Salary between 10000 and 50000
order by Salary desc

-- 11
select * from (
	select EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() over (partition by Salary order by EmployeeID) as [Rank]
	from Employees
	where Salary between 10000 and 50000
) as Result
where [Rank] = 2
order by Salary desc

-- geography

use Geography

-- 12
select CountryName, IsoCode
from Countries
where CountryName like '%a%a%a%'
order by IsoCode

-- 13
select PeakName, RiverName,
lower(left(PeakName, len(PeakName) - 1) + RiverName) as Mix
from Peaks, Rivers
where RIGHT(PeakName, 1) = LEFT(RiverName,1)
order by Mix

-- diablo

-- 14
use Diablo

select [Name], FORMAT ([Start], 'yyyy-MM-dd') as [Start]
from Games
where DATEPART(YEAR, [Start]) between 2011 and 2012
--where [Start] between convert(date, '2011') and convert(date, '2012') 
order by [Start], [Name]

-- 15

select Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, len(Email))
as EmailProvider
from Users
order by EmailProvider, UserName


-- 16
select Username, IpAddress as [IP Address]
from Users
where IpAddress like '___.1%.%.___'
order by Username

-- 17
select [Name], 
	case
		when DATEPART(HOUR, [Start]) between 0 and 11 then 'Morning'
		when DATEPART(HOUR, [Start]) between 12 and 17 then 'Afternoon'
		when DATEPART(HOUR, [Start]) between 18 and 23 then 'Evening'
	end as [Part of the Day],
	case
		when Duration <= 3 then	'Extra Short'
		when Duration between 4 and 6 then 'Short'
		when Duration > 6  then 'Long'
		else 'Extra Long'
	end as [Duration]
from Games
order by [Name], [Duration], [Part of the Day]

------

use Orders

-- 18

select ProductName,
	OrderDate, 
	DATEADD(day, 3, OrderDate) as [Pay Due],
	DATEADD(month, 1, OrderDate) as [Delivery Due]
from Orders

-- 19 

create table People
(
	Id int primary key identity,
	[Name] varchar(50),
	Birthdate datetime2,
)

insert into People values
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

select  *, 
'2000-12-07 00:00:00.000', GETDATE(), 
DATEDIFF(year, '2000-12-07 00:00:00.000', GETDATE()) as Diff
from People

select '2000-12-07 00:00:00.000', GETDATE(), 
DATEDIFF(year, '2000-12-07 00:00:00.000', GETDATE())