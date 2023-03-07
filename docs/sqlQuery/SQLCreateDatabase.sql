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

INSERT INTO Car VALUES (1, 'Honda Wave Alpha', 'Honda', 'Black', '2019', 'BIKE', 'AVAILABLE', 'SELF_DRIVING', 2, '29A-12345', 100000, 'https://cdn.tgdd.vn/Products/Images/42/200533/honda-wave-alpha-2019-600x600.jpg', 'https://www.youtube.com/watch?v=Z9Z9Z9Z9Z9Z9', '2020-01-01', '2020-01-01')
INSERT INTO Car VALUES (2, 'Honda Wave Alpha', 'Honda', 'Black', '2019', 'BIKE', 'AVAILABLE', 'SELF_DRIVING', 2, '29A-12345', 100000, 'https://cdn.tgdd.vn/Products/Images/42/200533/honda-wave-alpha-2019-600x600.jpg', 'https://www.youtube.com/watch?v=Z9Z9Z9Z9Z9Z9', '2020-01-01', '2020-01-01')
INSERT INTO Car VALUES (3, 'VinFast Lux SA2.0', 'VinFast', 'Black', '2019', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, '29A-12345', 100000, 'https://cdn.tgdd.vn/Products/Images/42/200533/honda-wave-alpha-2019-600x600.jpg', 'https://www.youtube.com/watch?v=Z9Z9Z9Z9Z9Z9', '2020-01-01', '2020-01-01')

INSERT INTO User VALUES (1, 'carrental@gmail.com', 'staff@123456', '0123456789', 'Staff', 'ADMIN', '2022-03-08', '2022-03-08')
