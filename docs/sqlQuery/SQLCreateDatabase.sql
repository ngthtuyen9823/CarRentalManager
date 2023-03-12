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

CREATE TABLE UserRole
(
	id int primary key,
	displayName char(100),
)

INSERT INTO UserRole VALUES(1,'Admin')
INSERT INTO UserRole VALUES(2,'Staff')

CREATE TABLE Users
(
	id int primary key,
	displayName char(100),
	userName char(100),
	pass_Word char(100),
	idRole int references UserRole(id)
)
	
INSERT INTO Users VALUES(1, 'Nguyen Van A', 'vananguyen', 'anv@123', 2)
INSERT INTO Users VALUES(2, 'Nguyen Van B', 'vanbnguyen', 'anv@123', 1)
INSERT INTO Users VALUES(3, 'Nguyen Van C', 'vancnguyen', 'anv@123', 1)
INSERT INTO Users VALUES(4, 'Nguyen Van D', 'vandnguyen', 'anv@123', 1)


INSERT INTO [dbo].[Car] VALUES (1, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7606', 1300, '/Assets/1.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (2, 'MAZDA CX5 2020', 'MAZDA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7553', 1050, '/assets/2.jpg', '/assets/p2.jpg', '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (3, 'TOYOTA RUSH 2019', 'TOYOTA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8095', 900, '/assets/3.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (4, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A3361', 700, '/assets/4.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (5, 'TOYOTA INNOVA G 2016', 'TOYOTA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1900', 920, '/assets/5.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (6, 'TOYOTA RUSH 2020', 'TOYOTA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6272', 720, '/assets/6.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (7, 'MITSUBISHI XPANDER 2019', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1933', 450, '/assets/7.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (8, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8337', 650, '/assets/8.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (9, 'MAZDA CX5 2020', 'MAZDA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8562', 1050, '/assets/3.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (10, 'MAZDA CX5 2020', 'MAZDA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1758', 1050, '/assets/2.jpg', '/assets/p2.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (11, 'MITSUBISHI XPANDER 2019', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A3897', 450, '/assets/7.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (12, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4001', 650, '/assets/6.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (13, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4681', 700, '/assets/4.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (14, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7249', 650, '/assets/8.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (15, 'TOYOTA RUSH 2020', 'TOYOTA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7835', 720, '/assets/6.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (16, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6895', 650, '/assets/8.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (17, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A9446', 650, '/assets/8.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (18, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A2899', 1300, '/Assets/1.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (19, 'MAZDA CX5 2020', 'MAZDA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1216', 1050, '/assets/3.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (20, 'TOYOTA INNOVA G 2016', 'TOYOTA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7688', 920, '/assets/5.jpg', '/assets/p2.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (21, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4104', 700, '/assets/4.jpg', '/assets/p3.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (22, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6718', 1300, '/Assets/1.jpg', '/assets/p4.jpg', '2022-01-01', '2022-01-01')
INSERT INTO Car VALUES (23, 'MAZDA CX5 2020', 'MAZDA', 'Black', 'undefined', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8145', 1050, '/assets/2.jpg', '/assets/p5.jpg', '2022-01-01', '2022-01-01')

INSERT INTO [dbo].[User] VALUES (1, 'carrental@gmail.com', 'staff@123456', '0123456789', 'Staff', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (2, 'carrental@gmail.com', 'staff1@123456', '0558967523', 'Staff1', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (3, 'carrental@gmail.com', 'staff2@123456', '0526489756', 'Staff2', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (4, 'carrental@gmail.com', 'staff3@123456', '0447896321', 'Staff3', 'ADMIN', '2022-03-08', '2022-03-08')
