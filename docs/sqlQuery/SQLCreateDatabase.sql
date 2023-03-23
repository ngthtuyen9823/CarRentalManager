CREATE DATABASE CARRENTALMANGER
use CARRENTALMANGER
go

CREATE TABLE [dbo].[Customer] (
	id int primary key,
	phoneNumber char(10),
	name char(100) NULL,
	email char(50) NULL,
	idCard char(15) NULL,
	address char(50) NULL,
	imageIdCardFront char(50) NULL,
	imageIdCardBack char(50) NULL,
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

CREATE TABLE [dbo].[Supplier] (
	id int primary key,
	email char(50) NULL,
	phoneNumber char(10) NULL,
	name char(50) NULL,
	address char(50) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Car] (
	id int primary key,
	name char(100) NULL,
	brand char(50) NULL,
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
	city char(50) NULL,
	supplierId int references [dbo].[Supplier](id),
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
	depositAmount int,
	imageEvidence char(100) NULL,
	notes char(100) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Contract] (
	id int primary key,
	orderId int references [dbo].[Order](id),
	userId int references [dbo].[User](id),
	makingDay date, --newDate
	status char(20) NULL,
	-- PAID, UNPAID
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

insert into [dbo].[Supplier] values(1, 'honda@gmail.com', '0656565565', 'Honda', 'Thu Duc', '2022-03-23', '2022-03-23')
insert into [dbo].[Supplier] values(2, 'toyota@gmail.com', '0987654321', 'Toyota', 'Ho Chi Minh City', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(3, 'ford@gmail.com', '0123456789', 'Ford', 'Hanoi', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(4, 'mercedes@gmail.com', '0369874123', 'Mercedes-Benz', 'Da Nang', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(5, 'bmw@gmail.com', '0656565656', 'BMW', 'Can Tho', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(6, 'carhelp@gmail.com', '0656565656', 'Car Help', 'Hanoi', '2023-03-23', '2023-03-23')

INSERT INTO [dbo].[Car] VALUES (1, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', '2021', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7606', 1300, '/Assets/images/cars/1.jpg', '/assets/images/avatar/p3.jpg', 'HCM', 6, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (2, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7553', 1050, '/assets/images/cars/2.jpg', '/assets/images/avatar/p2.jpg', 'HCM', 6, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (3, 'TOYOTA RUSH 2019', 'TOYOTA', 'Black', '2019', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8095', 900, '/assets/images/cars/3.jpg', '/assets/images/avatar/p3.jpg', 'HANOI', 2, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (4, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A3361', 700, '/assets/images/cars/4.jpg', '/assets/images/avatar/p4.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (5, 'TOYOTA INNOVA G 2016', 'TOYOTA', 'Black', '2016', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1900', 920, '/assets/images/cars/5.jpg', '/assets/images/avatar/p4.jpg', 'HCM', 2, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (6, 'TOYOTA RUSH 2020', 'TOYOTA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6272', 720, '/assets/images/cars/6.jpg', '/assets/images/avatar/p5.jpg', 'HCM', NULL, '2022-01-01' , '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (7, 'MITSUBISHI XPANDER 2019', 'MITSUBISHI', 'Black', '2019', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1933', 450, '/assets/images/cars/7.jpg', '/assets/images/avatar/p5.jpg', 'HANOI', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (8, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8337', 650, '/assets/images/cars/8.jpg', '/assets/images/avatar/p4.jpg', 'DANANG', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (9, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8562', 1050, '/assets/images/cars/3.jpg', '/assets/images/avatar/p3.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (10, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1758', 1050, '/assets/images/cars/2.jpg', '/assets/images/avatar/p2.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (11, 'MITSUBISHI XPANDER 2019', 'MITSUBISHI', 'Black', '2019', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A3897', 450, '/assets/images/cars/7.jpg', '/assets/images/avatar/p3.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (12, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4001', 650, '/assets/images/cars/6.jpg', '/assets/images/avatar/p3.jpg', 'HANOI', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (13, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4681', 700, '/assets/images/cars/4.jpg', '/assets/images/avatar/p4.jpg', 'DANANG', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (14, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7249', 650, '/assets/images/cars/8.jpg', '/assets/images/avatar/p4.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (15, 'TOYOTA RUSH 2020', 'TOYOTA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7835', 720, '/assets/images/cars/6.jpg', '/assets/images/avatar/p5.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (16, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6895', 650, '/assets/images/cars/8.jpg', '/assets/images/avatar/p5.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (17, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A9446', 650, '/assets/images/cars/8.jpg', '/assets/images/avatar/p4.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (18, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', '2021', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A2899', 1300, '/Assets/images/cars/1.jpg', '/assets/images/avatar/p5.jpg', 'DANANG', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (19, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A1216', 1050, '/assets/images/cars/3.jpg', '/assets/images/avatar/p5.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (20, 'TOYOTA INNOVA G 2016', 'TOYOTA', 'Black', '2016', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7688', 920, '/assets/images/cars/5.jpg', '/assets/images/avatar/p2.jpg', 'HCM', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (21, 'MITSUBISHI ATTRAGE 2020', 'MITSUBISHI', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A4104', 700, '/assets/images/cars/4.jpg', '/assets/images/avatar/p3.jpg', 'HANOI', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (22, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', '2021', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A6718', 1300, '/Assets/images/cars/1.jpg', '/assets/images/avatar/p4.jpg', 'HANOI', NULL, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (23, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A8145', 1050, '/assets/images/cars/2.jpg', '/assets/images/avatar/p5.jpg', 'DANANG', NULL, '2022-01-01', '2022-01-01')

INSERT INTO [dbo].[User] VALUES (1, 'carrental@gmail.com', 'staff@123456', '0123456789', 'Staff', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (2, 'carrental@gmail.com', 'staff1@123456', '0558967523', 'Staff1', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (3, 'carrental@gmail.com', 'staff2@123456', '0526489756', 'Staff2', 'ADMIN', '2022-03-08', '2022-03-08')
INSERT INTO [dbo].[User] VALUES (4, 'carrental@gmail.com', 'staff3@123456', '0447896321', 'Staff3', 'ADMIN', '2022-03-08', '2022-03-08')

insert into [dbo].[Customer] values (1,'032132932','Nguyen Van A', 'annv123@gmai.com', '1234823', '111 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (2,'032132932','Nguyen Van B', 'bnnv123@gmai.com', '1221611', '248 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (3,'028432932','Nguyen Van C', 'cnnv123@gmai.com', '1214562', '123 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (4,'032232932','Nguyen Van D', 'dnnv123@gmai.com', '1190561', '114 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (5,'044432932','Nguyen Van E', 'ennv123@gmai.com', '1234561', '116 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (6,'035532932','Nguyen Van F', 'fnnv123@gmai.com', '1234568', '348 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (7,'056432932','Nguyen Van G', 'gnnv123@gmai.com', '1234561', '174 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (8,'033432932','Nguyen Van H', 'hnnv123@gmai.com', '1249256', '124 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (9,'032232932','Nguyen Van I', 'innv123@gmai.com', '1132826', '182 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (10,'032213932','Nguyen Van J', 'jnnv123@gmai.com', '1234246', '192 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')
insert into [dbo].[Customer] values (11,'032812932','Nguyen Van K', 'knnv123@gmai.com', '1233216', '193 Vo Van Ngan', '/assets/images/idCard/1.jpg', '/assets/images/idCard/1.jpg', '2023-12-20', '2023-12-20')

insert into [dbo].[Order] Values(1,1,1,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 30000, 'COMPLETE', 100, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(2,2,2,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 40000, 'CANCELLED', 200, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(3,3,3,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 50000, 'PENDING', 100, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(4,8,4,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 60000, 'COMPLETE', 100, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(5,7,5,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 70000, 'COMPLETE', 200, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(6,6,6,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 80000, 'CANCELLED', 500, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(7,5,7,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 90000, 'COMPLETE', 200, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(8,4,8,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 100000, 'PENDING', 200, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')


insert into [dbo].[Contract] values(1,8,1, '2022-12-12', 'PAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(2,7,2,'2022-12-12', 'PAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(3,6,3,'2022-12-12', 'PAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(4,5,4,'2022-12-12', 'UNPAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(5,5,4,'2022-12-12', 'UNPAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(6,5,1,'2022-12-12', 'UNPAID', '2022-12-12', '2022-12-12')
insert into [dbo].[Contract] values(7,5,3,'2022-12-12', 'UNPAID', '2022-12-12', '2022-12-12')

