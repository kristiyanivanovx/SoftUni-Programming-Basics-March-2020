
create database Relations

use Relations

-- relations exercises

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


-- 6 7 8

-- 6

create database ExerciseSix
use ExerciseSix

create table Majors
(
	MajorID int primary key identity,
	[Name] nvarchar(100) not null,
)

create table Students
(
	StudentID int primary key identity,
	StudentNumber int unique,
	StudentName nvarchar(100),
	MajorID int foreign key references Majors(MajorID),

)
create table Payments
(
	PaymentID int primary key identity,
	PaymentDate datetime2,
	PaymentAmmount int,
	StudentID int foreign key references Students(StudentID),
)

create table Subjects
(
	SubjectID int primary key identity,
	SubjectName nvarchar(90) not null,
)

create table Agenda
(
	SubjectID int foreign key references Subjects(SubjectID),
	StudentID int foreign key references Students(StudentID),
	
	constraint PK_Agenda primary key (SubjectID, StudentID)
)