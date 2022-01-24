use master
drop database WMS

create database WMS
use WMS

create table Clients 
(
	ClientId int primary key identity, 
	FirstName nvarchar(50) not null, 
	LastName nvarchar(50) not null,  
	Phone char(12) check(len(Phone) = 12) not null, 
)

create table Mechanics 
(
	MechanicId int primary key identity, 
	FirstName nvarchar(50) not null, 
	LastName nvarchar(50) not null,  
	[Address] nvarchar(255) not null, 
)

create table Models 
(
	ModelId int primary key identity, 
	[Name] nvarchar(50) unique not null,  
)

create table Jobs 
(
	JobId int primary key identity, 
	ModelId int foreign key references Models(ModelId) not null, 
	[Status] nvarchar(11) default('Pending') 
			check([Status] in ('Pending', 'In Progress', 'Finished')),  
	ClientId int foreign key references Clients(ClientId) not null, 
	MechanicId int foreign key references Mechanics(MechanicId), 
	IssueDate date not null, 
	FinishDate date, 
)

create table Orders 
(
	OrderId int primary key identity, 
	JobId int foreign key references Jobs(JobId) not null,   
	IssueDate date,  
	Delivered bit default 0,  
)

create table Vendors 
(
	VendorId int primary key identity, 
	[Name] nvarchar(50) unique not null,  
)

create table Parts 
(
	PartId int primary key identity, 
	SerialNumber nvarchar(50) unique not null,  
	[Description] nvarchar(255),  
	Price decimal(15, 2) check(Price > 0 and Price <= 9999.99) not null,  
	VendorId int foreign key references Vendors(VendorId) not null,  
	StockQty int default(0) check(StockQty >= 0),  
)

create table OrderParts 
(
	OrderId int foreign key references Orders(OrderId) not null, 
	PartId int foreign key references Parts(PartId) not null,  
	Quantity int default(1) check (Quantity > 0),  
	constraint PK_Orders_Parts primary key (OrderId, PartId),
)

create table PartsNeeded 
(
	JobId int foreign key references Jobs(JobId) not null,
	PartId int foreign key references Parts(PartId) not null, 
	Quantity int default(1) check(Quantity > 0),  
	constraint PK_Jobs_Parts primary key (JobId, PartId),
)

----------------

-- 2 insert
insert into Clients(FirstName, LastName, Phone) values
('Teri','Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma','925-615-5185'),
('Jettie', 'Mconnell','908-802-3564'),
('Lemuel', 'Latzke','631-748-6479'),
('Melodie', 'Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')

insert into Parts (SerialNumber, Description, Price, VendorId) values
('WP8182119','Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77,4),
('WPY055980', 'High Temperature Adhesive',13.94, 3)

--Assign all Pending jobs to the mechanic Ryan Harnos (look up his ID manually, there is no need to use table joins) and change their status to 'In Progress'.

select * from Mechanics where LastName = 'Harnos'
select * from Jobs where Status = 'Pending'

update Jobs
set MechanicId = 3, Status = 'In Progress'
where Status = 'Pending'

select * from Orders
select * from OrderParts

delete from OrderParts
where OrderId = 19
delete from Orders
where OrderId = 19

select m.FirstName + ' ' + m.LastName as Mechanic,
	   j.Status,
	   j.IssueDate
from Mechanics as m
join Jobs as j on j.MechanicId = m.MechanicId
order by m.MechanicId, j.IssueDate, j.JobId


select * from Clients
select * from Jobs

select c.FirstName + ' ' + c.LastName as [Client],
	datediff(day, j.IssueDate, '04/24/2017') as [Days going],
	j.Status
from [Clients] as c
join Jobs as j on j.ClientId = c.ClientId
 where j.Status in ('In Progress', 'Pending')
order by [Days going] desc, c.ClientId

-- 7

select m.FirstName + ' ' + m.LastName as Mechanic,
		AVG(datediff(day, j.IssueDate, j.FinishDate))
from Jobs as j
join Mechanics as m on j.MechanicId = m.MechanicId
group by m.MechanicId, (m.FirstName + ' ' + m.LastName)
order by m.MechanicId

-- 8 Available Mechanics

select * from Jobs
select * from Mechanics

select m.FirstName + ' ' + m.LastName as Available
from Mechanics as m
left join Jobs as j on m.MechanicId = j.MechanicId
where j.JobId is null or (
	select count(JobId)
	from Jobs 
	where Status <> 'Finished' and MechanicId = m.MechanicId
	group by MechanicId, Status
) is null
group by m.MechanicId, (m.FirstName + ' ' + m.LastName)

-- 8 v2

select m.FirstName + ' ' + m.LastName as Available
from Mechanics as m
left join Jobs as j on m.MechanicId = j.MechanicId
where j.Status = 'Finished' or j.Status is null
group by (m.FirstName + ' ' + m.LastName), m.MechanicId
order by m.MechanicId

-- 9

select j.JobId, isnull(sum(p.Price * op.Quantity), 0) as Total
from Jobs as j
left join Orders as o on o.JobId = j.JobId
left join OrderParts as op on op.OrderId = o.OrderId
left join Parts as p on p.PartId = op.PartId
where Status = 'Finished'
group by j.JobId
order by Total desc, j.JobId

select * 

-- 10

select p.PartId,
		  p.Description,
		  pn.Quantity as [Required],
		  p.StockQty as [InStock],
		  IIF(o.Delivered = 0, op.Quantity, 0)
	 from Parts as p
left join PartsNeeded as pn on pn.PartId = p.PartId
left join OrderParts as op on op.PartId = p.PartId
left join Jobs as j on j.JobId = pn.JobId
left join Orders as o on o.JobId = j.JobId
where j.Status != 'Finished' and p.StockQty 
	+ IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
	order by PartId

-- // 11
go
create or alter procedure usp_PlaceOrder
(
	@jobId int,
	@serialNumber varchar(50),
	@qty int
)
as

declare @status varchar(10) = (select Status from Jobs where JobId = @jobId)

declare @partId varchar(10) = (select PartId from Parts where SerialNumber = @serialNumber)

if (@qty <= 0)
	Throw 50012, 'Part quantity must be more than zero!', 1
else if (@status is null)
	Throw 50013, 'Job not found!', 1
else if (@status = 'Finished')
	Throw 50011, 'This job is not active!', 1
else if (@partId is null)
	Throw 50014, 'Part not found!', 1

declare @orderId int = (select o.OrderId 
						from Orders as o
						where JobId = @jobId and o.IssueDate is null)

if (@orderId is null)
begin
	insert into Orders (JobId, IssueDate) values (@jobId, null)
end

set @orderId = (select o.OrderId from Orders as o
	where o.JobId = @jobId and o.IssueDate is null)

declare @orderPartExists int = (select OrderId from OrderParts
	where OrderId = @orderId and @partId = PartId)

if (@orderPartExists is null)
begin
	insert into OrderParts (OrderId, PartId, Quantity) values
	(@orderId, @partId, @qty)
end
else 
begin
	update OrderParts
	set Quantity += @qty
	where OrderId = @orderId and PartId = @partId
end

-- test
DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH
-- end test
go

-- 12
create function udf_GetCost(@jobId int)
RETURNS decimal(15, 2)
as
begin
	declare @result Decimal(15, 2)
	set @result = (
		select sum(p.Price * op.Quantity) as TotalSum
			from Jobs as j
			join Orders as o on o.JobId = j.JobId
			join OrderParts as op on op.OrderId = o.OrderId
			join Parts as p on p.PartId = op.PartId 
		where j.JobId = @jobId
		group by j.JobId)

	if (@result is null)
		set @result = 0;
	return @result
end
go

SELECT dbo.udf_GetCost(1)
FROM 

--// -- //

-- one to one - 1
delete from Passports
delete from Persons

create table Passports 
(
	PassportID INT primary key identity(101,1),
	PassportNumber char(8) 
)

create table Persons 
(
	PersonID INT primary key identity,
	FirstName nvarchar(60),
	Salary decimal(15, 2), 
	PassportID INT unique foreign key references Passports(PassportID)
)

insert into Passports values
('A12355'),
('A12354'),
('A12357')

insert into Persons values
('Peter', 11000.00, 102),
('Tom',  61000.00, 103),
('Jerry',  91000.00, 101)

-- one to many - 2
create table Manufacturers 
(
	ManufacturerID int primary key identity,
	[Name] varchar(50) not null,
	EstablishedOn datetime
)

create table Models 
(
	ModelID int primary key identity(101, 1),
	[Name] varchar(50),
	ManufacturerID int foreign key references Manufacturers(ManufacturerID)
)

insert into Manufacturers values
('BMW', '07/03/2003'),
('Audi', '01/03/2003'),
('Subaru', '06/03/2003')

insert into Models values
('x3', 1),
('z63', 1),
('nova 12', 2)

-- many to many - 3
create table Students
(
	StudentID int primary key identity,
	[Name] varchar(50)
)

create table Exams
(
	ExamID int primary key identity(101, 1),
	[Name] varchar(50)
)

create table StudentsExams
(
	StudentID int,
	ExamID int

	constraint PK_Students_Exams primary key (StudentID, ExamID),
	constraint FK_Students foreign key (StudentID) references Students(StudentID),
	constraint FK_Exams foreign key (ExamID) references Exams(ExamID)
)

insert into Students values
('Mila'),
('Tony'),
('Ron')

insert into Exams values
('SpringMVC'),
('Neon4j'),
('Oracle 11g')

insert into StudentsExams values
(1, 101),
(1, 102),
(2, 101),
(2, 103),
(3, 102),
(3, 103)

--

-- self referencing - 4
create table Teachers
(
	TeacherID int primary key identity(101, 1),
	[Name] varchar(50),
	ManagerID int foreign key references Teachers(TeacherID)
)

insert into Teachers values
('John', NULL),
('Maya', 106),
('Silvia', 105),
('Ted', 103),
('Mark', 102),
('Giesib', 104)

-- peaks in rila 9 geography db

select m.MountainRange, p.PeakName, p.Elevation
from Mountains as m
join Peaks as p on p.MountainId = m.Id
where m.MountainRange = 'Rila'
order by p.Elevation desc

select * from Mountains
select * from Peaks

-- 5

use Relations

create table Cities
(
	CityID int primary key identity,
	[Name] varchar(50) not null
)

create table Customers
(
	CustomerID int primary key identity,
	[Name] varchar(50) not null,
	Birthday date,
	CityID int foreign key references Cities(CityID),
)

create table Orders
(
	OrderID int primary key identity,
	CustomerID int foreign key references Customers(CustomerID),
)

create table ItemTypes
(
	ItemTypeID int primary key identity,
	[Name] varchar(50) not null,
)

create table Items
(
	ItemID int primary key identity,
	[Name] varchar(50) not null,
	ItemTypeID int foreign key references ItemTypes(ItemTypeID),
)

create table OrderItems
(
	OrderID int foreign key references Orders(OrderID),
	ItemID int foreign key references Items(ItemID)

	constraint PK_Order_Item primary key (OrderID, ItemID)
)

