-- indices and data aggregation exercise

use Gringotts

select * 
from WizzardDeposits

-- 1
select COUnt(*)
from WizzardDeposits

-- 2
select TOP 1 PERCENT max(MagicWandSize) as LongestMagicWand
from WizzardDeposits
group by MagicWandSize
order by MagicWandSize desc

select MagicWandSize 
from WizzardDeposits
order by MagicWandSize desc

-- 3
select DepositGroup, max(MagicWandSize) as LongestMagicWand
from WizzardDeposits
group by DepositGroup
order by LongestMagicWand desc

-- 4
select top(2) DepositGroup
from WizzardDeposits
group by DepositGroup
order by avg(MagicWandSize)

-- 5
select DepositGroup, sum(DepositAmount) as TotalSum
from WizzardDeposits
group by DepositGroup

-- 6
select  DepositGroup, sum(DepositAmount) as TotalSum
from WizzardDeposits
where MagicWandCreator like '%Ollivander%'
group by DepositGroup

-- 7
select  DepositGroup, sum(DepositAmount) as TotalSum
from WizzardDeposits
where MagicWandCreator like '%Ollivander%'
group by DepositGroup
having sum(DepositAmount) < 150000
order by TotalSum desc

-- 8
select DepositGroup, MagicWandCreator, min(DepositCharge) as MinDepositCharge
from WizzardDeposits
group by DepositGroup, MagicWandCreator
order by MagicWandCreator, DepositGroup

-- 9
select Result.AgeGroup, COUNT(Result.AgeGroup)
from ( select
case 
	when Age between 0 and 10 then '[0-10]'
	when Age between 11 and 20 then '[11-20]'
	when Age between 21 and 30 then '[21-30]'
	when Age between 31 and 40 then '[31-40]'
	when Age between 41 and 50 then '[41-50]'
	when Age between 51 and 60 then '[51-60]'
	when Age >= 61 then '[61+]'
end as AgeGroup
from WizzardDeposits) as Result
group by Result.AgeGroup

-- 10
select distinct LEFT(FirstName, 1) As FirstLetter
from WizzardDeposits
where DepositGroup = 'Troll Chest'
group by LEFT(FirstName, 1)

-- 11
select DepositGroup, IsDepositExpired, AVG(DepositInterest) as AverageInterest
from WizzardDeposits
where DepositStartDate >  '01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired asc

-- 12
select SUM(Guest.DepositAmount - Host.DepositAmount) as [Difference] 
from WizzardDeposits as Host
join WizzardDeposits as Guest on Guest.Id + 1 = Host.Id

-- 13
use SoftUni

select DepartmentID, sum(Salary)
from Employees
group by DepartmentID

-- 14
select DepartmentID, min(Salary) as MinSalary
from Employees
where DepartmentID in (2, 5, 7) and HireDate > '01/01/2000'
group by DepartmentID

-- 15
select * 
into MyNewTable2
from Employees
where Salary > 30000

delete from MyNewTable2 
where ManagerID = 42

update MyNewTable2
set Salary += 5000
where DepartmentID = 1

select DepartmentID, avg(Salary)
from MyNewTable2
group by DepartmentID

-- 16
select DepartmentID, max(Salary)
from Employees
group by DepartmentID
having max(Salary) not between 30000 and 70000

-- 17
select COUNT(*)
from Employees
where ManagerID is null

-- 18
select distinct k.DepartmentID, k.Salary
	from (select DepartmentID, Salary,
	DENSE_RANK() over (partition by DepartmentID order by Salary DESC) as [Ranked]
	from Employees) as k
where k.Ranked = 3

-- 19
select top(10) FirstName, LastName, DepartmentID
from Employees as emp
where Salary > (Select avg(Salary)
				from Employees 
				where DepartmentID = emp.DepartmentID
				group by DepartmentID)
order by DepartmentID