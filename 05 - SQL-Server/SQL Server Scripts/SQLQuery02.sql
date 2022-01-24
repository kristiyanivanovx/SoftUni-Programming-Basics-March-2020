create database Minions

-- introduction

use Minions;

create table Minions 
(
	Id int primary key,
	[Name] varchar(30),
	age int
);

create table Towns 
(
	Id int primary key,
	[name] varchar(30),
	Age int
);

alter table Minions
ADD TownId int;

alter table Minions
add foreign key (TownId) references Towns(Id);

insert into Towns (Id, name) values
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');


insert into Minions (Id, Name, Age, TownId) values
(2, 'Bob', 15, 13),
(3, 'Stewie', NULL, 2);


select * from Towns;

delete from Minions;

DROP TABLE Minions;

DROP TABLE Towns;

create table Users
(
	Id bigint primary key identity,
	Username varchar(30) not null,
	[Password] varchar(26) not null,
	ProfilePicture varchar(max),
	LastLoginTime DATETIME,
	IsDeleted BIT
) ;

--- unique identifier

insert into Users 
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
values
('manOwar2', 'bigstrongpass123', 'https://github.com/rothja.png', '12/28/2021', 0),
('manOwar3', 'bigstrongpass123', 'https://github.com/rothja.png', '1/10/2021', 0),
('manOwar4', 'bigstrongpass123', 'https://github.com/rothja.png', '9/30/2021', 0),
('manOwar5', 'bigstrongpass123', 'https://github.com/rothja.png', '3/19/2021', 0);

select * from users;

alter table Users
drop constraint PK__Users__3214EC074ED2E5FC;

alter table Users
add constraint PK_IdUsername primary key (Id, Username);

alter table Users
add constraint CH_PasswordIsAtLeast5Symbols check (len([Password]) > 5);

alter table Users
add constraint DF_LastLoginTime default getdate() for LastLoginTime;

delete from Users;

alter table Users
drop constraint PK_IdUsername;

alter table Users
add constraint PK_Id primary key (Id);

alter table Users
add constraint CH_UsernameIsAtLeast3Symbols check (len(Username) > 3);

create database Hotel;

use Hotel;

create table Employees
(
	Id int primary key,
	FirstName varchar(90) not null,
	LastName varchar(90) not null,
	Title varchar(50) not null,
	Notes varchar(max)
);

insert into Employees  
(Id, FirstName, LastName, Title, Notes) values
(1, 'anio', 'anev', 'ceo', null),
(2, 'petar', 'petrov', 'cfo', 'some note'),
(3, 'ivan', 'ivanov', 'cto', null);

-- customers

create table Customers 
(
	AccountNumber int primary key,
	FirstName varchar(90) not null,
	LastName varchar(90) not null,
	PhoneNumber char(10) not null,
	EmergencyName varchar(90) not null,
	EmergencyNumber char(10) not null,
	Notes varchar(max)
);

insert into Customers  
(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes ) values
(120, 'g', 'a', '1234567890', 'a', '1234567890', null),
(130, 'f', 'b', '1234567890', 'a', '1234567890', null),
(140, 'a', 'c', '1234567890', 'a', '1234567890', null);

create table RoomStatus 
(
	RoomStatus varchar(20) not null,
	Notes varchar(max),
);

insert into RoomStatus (RoomStatus, Notes) values
('cleaning', 'bigunotuuu'),
('free', 'bigunotuuu'),
('not free', 'bigunotuuu');

create table RoomTypes 
(
	RoomType varchar(20) not null,
	Notes varchar(max),
);

insert into RoomTypes (RoomType, Notes) values
('big', 'cat note'),
('small', 'normal note')
('medium', 'medium note');

create table BedTypes 
(
	BedType varchar(20) not null,
	Notes varchar(max),
);

insert into BedTypes(BedType, Notes) values
('comfy', 'nice'),
('small', 'its ok'),
('child', 'kid');

create table Rooms 
(
	RoomNumber int primary key,
	RoomType varchar(20) not null,
	BedType varchar(20) not null,
	Rate INT,
	RoomStatus bit not null,
	Notes varchar(max)
);

insert into Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) values
(1, 'big apartment', 'king', 678, 1, 'perfect'),
(14, 'small apartment', 'small', 678, 1, 'ok'),
(28, 'medium apartment', 'medium', 678, 1, 'medium');

create table Payments 
(
	Id int primary key,
	EmployeeId int not null,
	PaymentDate datetime not null,
	AccountNumber int not null,
	FirstDateOccupied datetime not null,
	LastDateOccupied datetime not null,
	TotalDays int not null,
	AmmountCharged decimal(15,2),
	TaxRate int,
	TaxAmmount int,
	PaymentTotal decimal(15,2),
	Notes varchar(max)
);

insert into Payments (Id, EmployeeId, PaymentDate, AccountNumber,
FirstDateOccupied, LastDateOccupied, TotalDays, AmmountCharged,TaxRate,
TaxAmmount, PaymentTotal, Notes) values
(2, 1243, '1/12/2021', 11, '2/12/2021', '9/12/2021', 
44, 8000.20, 10, 1000, 10000, 'great'),
(3, 123, '1/12/2021', 11, '2/12/2021', '9/12/2021', 
44, 8000.20, 10, 1000, 10000, 'great');

create table Occupancies 
(
	Id int primary key,
	EmployeeId int not null,
	DateOccupied datetime not null,
	AccountNumber int not null,
	RoomNumber int not null,
	PhoneCharge decimal(15,2),
	Notes varchar(max)
);

insert into Occupancies (Id, EmployeeId, DateOccupied, 
AccountNumber, RoomNumber, PhoneCharge, Notes) values
(1010, 11211, GETDATE(), 4544, 4544, 1823456789, 'perfec1t'),
(1030, 12111, GETDATE(), 4544, 5444, 123456789, 'perfect1'),
(1020, 11311, GETDATE(), 4454, 454, 1823456790, 'perfec2t');

select * from Customers 
order by FirstName asc;

select AccountNumber from Customers
order by AccountNumber desc;

select * from Rooms ;

update Rooms
set Rate = Rate * 1.1
where RoomNumber = 28;