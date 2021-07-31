use TripService

create table Cities 
(
	Id int not null primary key identity,
	[Name] nvarchar(20) not null,
	CountryCode char(2) not null
)

create table Hotels 
(
	Id int not null primary key identity,
	[Name] nvarchar(30) not null,
	CityId int not null references Cities(Id),
	EmployeeCount int not null,
	BaseRate decimal(18, 2)
)

create table Rooms 
(
	Id int not null primary key identity,
	Price decimal(18, 2) not null,
	Type nvarchar(20) not null,
	Beds int not null,
	HotelId int not null references Hotels(Id)
)

create table Trips
(
	Id int not null primary key identity,
	RoomId int not null references Rooms(Id),
	BookDate date not null,
	ArrivalDate date not null,
	ReturnDate date not null,
	CancelDate date,
	check(BookDate < ArrivalDate),
	check(ArrivalDate < ReturnDate)
)

create table Accounts
(
	Id int not null primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(20),
	LastName varchar(50) not null,
	CityId int not null references Cities(Id),
	BirthDate date not null,
	Email varchar(100) not null unique,
)

create table AccountsTrips
(
	AccountId int not null references Accounts(Id) ,
	TripId int not null references Trips(Id),
	Luggage int not null,
	primary key (AccountId, TripId),
	check(Luggage >= 0)
	--constraint PK_Accounts_Trips primary key (AccountId, TripId)
)