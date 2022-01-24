-- exercise - functions and stored procedures

use SoftUni

-- 1
go
create procedure usp_GetEmployeesSalaryAbove35000 as
select FirstName, LastName
from Employees
where Salary > 35000

exec usp_GetEmployeesSalaryAbove35000

-- 2
go
create procedure usp_GetEmployeesSalaryAboveNumber (@SalaryNumber decimal(18,4)) as
select FirstName, LastName
from Employees
where Salary >= @SalaryNumber

exec usp_GetEmployeesSalaryAboveNumber 48100

-- 3
go

create procedure usp_GetTownsStartingWith (@StartingChar nvarchar(max)) as
select [Name]
from Towns
where [Name] like @StartingChar + '%'

exec usp_GetTownsStartingWith 'b'

--4
go
create procedure usp_GetEmployeesFromTown (@TownName nvarchar(max)) as
select FirstName, LastName
from Employees as e
join Addresses as a on e.AddressID = a.AddressID
join Towns as t on a.TownID = t.TownID
where t.[Name] = @TownName

exec usp_GetEmployeesFromTown 'sofia'

--5
go
create function ufn_GetSalaryLevel(@salary decimal(18,4)) 
returns nvarchar(max)
as
begin
	declare @result varchar(max)

	if (@salary < 30000)
		set @result = 'Low'
	else if (@salary  <= 50000)
		set @result = 'Average'
	else if (@salary > 50000)
		set @result = 'High'
	else 
		set @result = 'High'

	return @result;
end

go
select FirstName, dbo.ufn_GetSalaryLevel(Salary)
from Employees 

-- 6
go
create procedure usp_EmployeesBySalaryLevel(@SalaryLevel nvarchar(30)) as
	select FirstName, LastName
	from Employees
	where dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

-- 7
go
select dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
select dbo.ufn_IsWordComprised('oistmiahf', 'halves')

go
create function ufn_IsWordComprised(@setOfLetters nvarchar(max), @word nvarchar(max))
returns bit
begin
	declare @count int = 1;

	while (@count < LEN(@word))
	begin
		declare @currentLetter char(1) = substring(@word, @count, 1)
	
		if (charindex(@currentLetter, @setOfLetters) = 0)
			return 0

		set @count += 1;
	end
	return 1
end

-- 8
go
create procedure usp_DeleteEmployeesFromDepartment (@departmentId int) as
alter table Departments
alter column ManagerID int null

delete from EmployeesProjects
where EmployeeID in (select EmployeeID from Employees where DepartmentID = @departmentId)

update Employees
set ManagerID = null
where EmployeeID in (select EmployeeID from Employees where DepartmentID = @departmentId)

update Employees
set ManagerID = null
where ManagerID in (select EmployeeID from Employees where DepartmentID = @departmentId)

update Departments
set ManagerID = null
where DepartmentID = @departmentId

delete from Employees
where ManagerID = @departmentId

select count(*) from Employees Where DepartmentID = @departmentId

-- 9
go

use Bank
go

create proc usp_GetHoldersFullName as
select FirstName + ' ' + LastName as [Full Name]
from AccountHolders

go

exec usp_GetHoldersFullName

-- 10
go

select * 
from AccountHolders

go

create procedure usp_GetHoldersWithBalanceHigherThan 
	(@MoreThan decimal(15, 2))
	as
select FirstName, LastName
from Accounts as a
join AccountHolders as ah on ah.Id = a.AccountHolderId
group by FirstName, LastName
having sum(Balance) > @MoreThan
order by FirstName, LastName

go

exec usp_GetHoldersWithBalanceHigherThan 50000

-- 11
go

create function ufn_CalculateFutureValue 
	(@sum decimal(15, 2), @yearly float, @years int)
returns Decimal(15,4)
begin
	declare @Result Decimal(15,4)
	set @Result = (@sum * power((1 + @yearly), @years))
	return @Result
end

go

select dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- 12
go

create procedure usp_CalculateFutureValueForAccount
(@accountId int, @interestRate float)
as
select a.Id, ah.FirstName, ah.LastName, a.Balance, dbo.ufn_CalculateFutureValue
(a.Balance, @interestRate, 5)
from Accounts as a
join AccountHolders as ah on ah.Id = a.AccountHolderId
where a.Id = @accountId

exec usp_CalculateFutureValueForAccount 1, 0.1

-- 13
go

use Diablo

go

alter FUNCTION ufn_cashInUsersGames (@gameName VARCHAR(100))
RETURNS TABLE
AS
RETURN (SELECT SUM(k.TotalCash) AS TotalCash
	FROM (SELECT Cash AS TotalCash,
		ROW_NUMBER() OVER (ORDER BY g.Id) AS RowNumber
		FROM Games AS g
		JOIN UsersGames AS ug ON ug.GameId = g.Id
		WHERE Name = @gameName) AS k
WHERE k.RowNumber % 2 = 1)

go

SELECT * FROM ufn_CashInUsersGames('Love in a mist') 

select * from Games

drop function ufn_CashInUsersGames
--SumCash
--8585.00

-- 2 38 12
