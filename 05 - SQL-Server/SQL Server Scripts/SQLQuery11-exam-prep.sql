use master
DROP DATABASE TripService
go

--1
create database TripService
use TripService

-- 2
insert into Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) values
('John','Smith','Smith',34, '1975-07-21','j_smith@gmail.com'),
('Gosho', NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com'),
('Ivan','Petrovich','Pavlov', 59,'1849-09-26','i_pavlov@softuni.bg'),
('Friedrich','Wilhelm','Nietzsche', 2 ,'1844-10-15','f_nietzsche@softuni.bg')

insert into Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) values
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

-- 3
update Rooms
set Price = Price * 1.14
where HotelId in (5, 7, 9)

-- 4

delete
from AccountsTrips
where AccountId = 47

-- 5
select * from Cities
select * from Accounts 

select a.FirstName, 
		a.LastName, 
		c.Name, 
		FORMAT(a.BirthDate, 'MM-dd-yyyy') as BirthDate,
		a.Email
from Accounts as a
join Cities as c on c.Id = a.CityId
where Email like 'e%'
order by c.Name

-- 6
select * from Cities
select * from Hotels

select c.Name as City, count(*) as Hotels 
from Cities as c
join Hotels as h on c.Id = h.CityId
group by c.Name
order by Hotels desc, City

-- 6 v2
select c.Name as City, 
	(select count(*) from Hotels h where h.CityId = c.Id) as Hotels
from Cities as c
order by Hotels desc, City

-- 7
select AccountId,
	a.FirstName + ' ' + a.LastName as FullName,
	max(DATEDIFF(day, ArrivalDate, ReturnDate)) as LongestTrip,
	min(DATEDIFF(day, ArrivalDate, ReturnDate)) as ShortestTrip
from AccountsTrips as at
join Accounts a on at.AccountId = a.Id
join Trips t on at.TripId = t.Id
where MiddleName is null and CancelDate is null
group by AccountId, a.FirstName, a.LastName
order by LongestTrip desc, ShortestTrip asc

-- 8
select top(10) c.Id, c.Name as City, c.CountryCode as Country, count(*) as Accounts
from Accounts a
join Cities c on a.CityId = c.Id
group by c.Id, c.Name, c.CountryCode
order by Accounts desc

-- 9
select  AccountId as Id, 
		Email, 
		ac.Name as City,
		Count(*) as Trips 
from AccountsTrips as at
	join Accounts as a on a.Id = at.AccountId
	join Cities as ac on a.CityId = ac.Id
	join Trips as t on at.TripId = t.Id
	join Rooms as r on t.RoomId = r.Id
	join Hotels as h on r.HotelId = h.Id
	join Cities hc on h.CityId = hc.Id
where hc.Id = ac.Id
group by AccountId, Email, ac.Name
order by Trips desc, AccountId asc

-- 10
select  TripId as Id, 
		FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName as [Full Name],
		ac.Name as [From],
		hc.Name as [To],
		case 
			when CancelDate is null 
				then CONVERT(nvarchar,DATEDIFF(day, ArrivalDate, ReturnDate)) + ' days'
			else 'Canceled' 
		end as Duration
from AccountsTrips as at
	join Accounts as a on a.Id = at.AccountId
	join Cities as ac on a.CityId = ac.Id
	join Trips as t on at.TripId = t.Id
	join Rooms as r on t.RoomId = r.Id
	join Hotels as h on r.HotelId = h.Id
	join Cities hc on h.CityId = hc.Id
order by [Full Name], TripId

-- 11
go
create or alter function udf_GetAvailableRoom(@HotelId int, @Date date, @People int)
returns nVARCHAR(MAX)
begin
	declare @RoomInfo varchar(max) = (
		select top(1) 'Room ' + convert(varchar, r.Id) + ': ' + 
		r.Type + ' (' + 
		convert(varchar, r.Beds) + ' beds) - $' + 
		convert(varchar, (BaseRate + Price) * @People)
		from Rooms r
		join Hotels h on h.Id = r.HotelId
		where Beds >= @People and HotelId = @HotelId and
				not exists (select * from Trips as t 
							where t.RoomId = r.Id
							and CancelDate is null
							and @Date between ArrivalDate and ReturnDate)
		order by (BaseRate + Price) * @People desc)

	if (@RoomInfo is null)
		return 'No rooms available'
	return @RoomInfo
end
go

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
-- Room 211: First Class (5 beds) - $202.80

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
-- No rooms available

-- 12
go

CREATE PROC usp_SwitchRoom(@TripId int, @TargetRoomId int)
AS
	Declare @TripHotelId int = (select r.HotelId from Trips t
								join Rooms r on t.RoomId = r.Id
								where t.Id = @TripId);
	Declare @TargetRoomHotelId int = (select HotelId from Rooms 
									  where Id = @TargetRoomId);
	if (@TripHotelId != @TargetRoomHotelId)
		throw 50001, 'Target room is in another hotel!', 1

	declare @TripAccounts Int = (select count(*) from AccountsTrips 
								 where TripId = @TripId);
	declare @TargetRoomBeds Int = (select Beds from Rooms 
								 where Id = @TargetRoomId);
	if (@TripAccounts > @TargetRoomBeds)
		throw 50002, 'Not enough beds in target room!', 1

	update Trips set RoomId = @TargetRoomId where Id = @TripId;
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
