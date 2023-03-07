CREATE DATABASE CARRENTALMANGER
use CARRENTALMANGER
go

CREATE TABLE [dbo].[Customer] (
	id int primary key,
	phoneNumber char(10),
	name char(100) NULL,
	email char(50) NULL,
	cmnd char(15) NULL,
	address char(50) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[User] (
	id int primary key,
	email char(50) NULL,
	password char(50) NULL,
	phoneNumber char(10) NULL,
	name char(50) NULL,
	role char(50) NULL,
	--EUserRole { user, admin, manager }
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Car] (
	id int primary key,
	name char(100) NULL,
	branch char(50) NULL,
	color char(50) NULL,
	publishYear char(50) NULL,
	type char(50) NULL,
	--BIKE, MOTOBIKE, CAR
	status char(50) NULL,
	-- ONRENT, AVAILABLE
	drivingType  char(50) NULL, 
	--SELF_DRIVING, MANNED
	seats int,
	licensePlate char(20) NULL,
	price int,
	imagePath char(100) NULL,
	tutorialPath char(100) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Order] (
	id int primary key,
	carId int references Car(id),
	customerId int references Customer(id),
	bookingPlace char(100) NULL,
	startDate date,
	endDate date,
	totalFee int,
	status char(50) NULL,
	--COMPLETE, CANCELLED, PENDING
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Contract] (
	id int primary key,
	orderId int references [dbo].[Order](id),
	userId int references [dbo].[User](id),
	makingDay date, --newDate
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Receipt] (
	id int primary key,
	contractId int references Contract(id),
	makingDay date,
	price int,
	createdAt date,
	updatedAt date,
)

