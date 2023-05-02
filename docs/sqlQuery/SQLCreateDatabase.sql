CREATE DATABASE CARRENTALMANAGER
use CARRENTALMANAGER
go

CREATE TABLE [dbo].[Customer] (
	id int primary key,
	phoneNumber char(10),
	name char(200) NULL,
	email char(50) NULL,
	idCard char(15) NULL,
	address char(50) NULL,
	imageIdCardFront char(200) NULL,
	imageIdCardBack char(200) NULL,
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
	name char(200) NULL,
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
	imagePath char(200) NULL,
	tutorialPath char(200) NULL,
	city char(50) NULL,
	supplierId int,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Order] (
	id int primary key,
	carId int,
	customerId int,
	bookingPlace char(200) NULL,
	startDate date,
	endDate date,
	totalFee int,
	status char(50) NULL,
	--COMPLETE, CANCELLED, PENDING
	depositAmount int,
	imageEvidence char(200) NULL,
	notes char(200) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Contract] (
	id int primary key,
	orderId int,
	userId int,
	status char(20) NULL,
	price int,
	paid int,
	remain int,
	-- PAID, UNPAID
	feedback char(500) NULL,
	returnCarStatus char(100) NULL,
	note char(500) NULL,
	createdAt date,
	updatedAt date,
)

CREATE TABLE [dbo].[Receipt] (
	id int primary key,
	contractId int,
	price int,
	createdAt date,
	updatedAt date,
)

insert into [dbo].[Supplier] values(0, 'carhelp@gmail.com', '0686868686', 'Car Help', 'Ho Chi Minh', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(1, 'honda@gmail.com', '0656565565', 'Honda', 'Thu Duc', '2022-03-23', '2022-03-23')
insert into [dbo].[Supplier] values(2, 'toyota@gmail.com', '0987654321', 'Toyota', 'Ho Chi Minh', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(3, 'ford@gmail.com', '0123456789', 'Ford', 'Hanoi', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(4, 'mercedes@gmail.com', '0369874123', 'Mercedes-Benz', 'Da Nang', '2023-03-23', '2023-03-23')
insert into [dbo].[Supplier] values(5, 'bmw@gmail.com', '0656565656', 'BMW', 'Can Tho', '2023-03-23', '2023-03-23')

INSERT INTO [dbo].[Car] VALUES (1, 'VINFAST LUX A 2.0 2021', 'VINFAST', 'Black', '2021', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7606', 1300, '/Assets/images/cars/1.jpg', '/assets/images/avatar/p3.jpg', 'HCM', 0, '2022-01-01', '2022-01-01')
INSERT INTO [dbo].[Car] VALUES (2, 'MAZDA CX5 2020', 'MAZDA', 'Black', '2020', 'CAR', 'AVAILABLE', 'SELF_DRIVING', 4, 'A7553', 1050, '/assets/images/cars/2.jpg', '/assets/images/avatar/p2.jpg', 'HCM', 0, '2022-01-01', '2022-01-01')
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



insert into [dbo].[Order] Values(1,12,7,'Ho Chi Minh City', '2019-04-29', '2019-04-29', 1403, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-04-29', '2019-04-29')
insert into [dbo].[Order] Values(2,2,4,'Ho Chi Minh City', '2019-04-29', '2019-04-29', 2222, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-04-29', '2019-04-29')
insert into [dbo].[Order] Values(3,12,5,'Ho Chi Minh City', '2019-04-29', '2019-04-29', 1234, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-03-20', '2019-03-20')
insert into [dbo].[Order] Values(4,14,6,'Ho Chi Minh City', '2019-04-29', '2019-04-29', 4888, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-03-20', '2019-03-20')
insert into [dbo].[Order] Values(5,7,7,'Ho Chi Minh City', '2019-01-20', '2019-01-20', 1000, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-01-20', '2019-01-20')
insert into [dbo].[Order] Values(6,18,8,'Ho Chi Minh City', '2019-04-20', '2019-04-20', 1000, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-01-20', '2019-01-20')
insert into [dbo].[Order] Values(7,17,9,'Ho Chi Minh City', '2019-04-20', '2019-04-20', 9876, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-01-20', '2019-01-20')
insert into [dbo].[Order] Values(8,22,1,'Ho Chi Minh City', '2019-04-20', '2019-04-20', 7558, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-01-20', '2019-01-20')
insert into [dbo].[Order] Values(9,20,2,'Ho Chi Minh City', '2019-02-20', '2019-02-20', 999, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-02-20', '2019-02-20')
insert into [dbo].[Order] Values(10,8,3,'Ho Chi Minh City', '2019-02-20', '2019-02-20', 7890, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-02-20', '2019-02-20')
insert into [dbo].[Order] Values(11,11,4,'Ho Chi Minh City', '2019-04-20', '2019-04-20', 2013, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-04-20', '2019-04-20')
insert into [dbo].[Order] Values(12,1,5,'Ho Chi Minh City', '2019-04-25', '2019-04-26', 3384, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-04-20', '2019-04-20')
insert into [dbo].[Order] Values(13,9,6,'Ho Chi Minh City', '2019-02-20', '2019-02-21', 1003, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-02-20', '2019-02-20')
insert into [dbo].[Order] Values(14,12,7,'Ho Chi Minh City', '2019-04-29', '2019-04-30', 1403, 'COMPLETE', 200, '', 'Please contact me soon!', '2019-04-26', '2019-04-26')


insert into [dbo].[Order] Values(15,12,7,'Ho Chi Minh City', '2020-04-29', '2020-04-29', 10100, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-04-29', '2020-04-29')
insert into [dbo].[Order] Values(16,2,4,'Ho Chi Minh City', '2020-04-29', '2020-04-29', 700, 'COMPLETE', 500, '', 'Please contact me soon!', '2020-04-29', '2020-04-29')
insert into [dbo].[Order] Values(17,12,5,'Ho Chi Minh City', '2020-04-29', '2020-04-29', 4534, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-03-20', '2020-03-20')
insert into [dbo].[Order] Values(18,14,6,'Ho Chi Minh City', '2020-04-29', '2020-04-29', 4888, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-03-20', '2020-03-20')
insert into [dbo].[Order] Values(19,7,7,'Ho Chi Minh City', '2020-01-20', '2020-01-20', 900, 'COMPLETE', 300, '', 'Please contact me soon!', '2020-01-20', '2020-01-20')
insert into [dbo].[Order] Values(20,18,8,'Ho Chi Minh City', '2020-04-20', '2020-04-20', 900, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-01-20', '2020-01-20')
insert into [dbo].[Order] Values(21,17,9,'Ho Chi Minh City', '2020-04-20', '2020-04-20', 9876, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-01-20', '2020-01-20')
insert into [dbo].[Order] Values(22,22,1,'Ho Chi Minh City', '2020-04-20', '2020-04-20', 500, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-01-20', '2020-01-20')
insert into [dbo].[Order] Values(23,20,2,'Ho Chi Minh City', '2020-02-20', '2020-02-20', 999, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-02-20', '2020-02-20')
insert into [dbo].[Order] Values(24,8,3,'Ho Chi Minh City', '2020-02-20', '2020-02-20', 2000, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-02-20', '2020-02-20')
insert into [dbo].[Order] Values(25,11,4,'Ho Chi Minh City', '2020-04-20', '2020-04-20', 4154, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-04-20', '2020-04-20')
insert into [dbo].[Order] Values(26,1,5,'Ho Chi Minh City', '2020-04-25', '2020-04-26', 1234, 'COMPLETE', 200, '', 'Please contact me soon!', '2020-04-20', '2020-04-20')
insert into [dbo].[Order] Values(27,9,6,'Ho Chi Minh City', '2020-02-20', '2020-02-21', 1003, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2020-02-20', '2020-02-20')
insert into [dbo].[Order] Values(28,12,7,'Ho Chi Minh City', '2020-04-29', '2020-04-30', 890, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2020-04-26', '2020-04-26')


insert into [dbo].[Order] Values(29,12,7,'Ho Chi Minh City', '2021-04-29', '2021-04-29', 1403, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-04-29', '2021-04-29')
insert into [dbo].[Order] Values(30,2,4,'Ho Chi Minh City', '2021-04-29', '2021-04-29', 3567, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-04-29', '2021-04-29')
insert into [dbo].[Order] Values(31,12,5,'Ho Chi Minh City', '2021-04-29', '2021-04-29', 1111, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-03-20', '2021-03-20')
insert into [dbo].[Order] Values(32,14,6,'Ho Chi Minh City', '2021-04-29', '2021-04-29', 4789, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-03-20', '2021-03-20')
insert into [dbo].[Order] Values(33,7,7,'Ho Chi Minh City', '2021-01-20', '2021-01-20', 5000, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-01-20', '2021-01-20')
insert into [dbo].[Order] Values(34,18,8,'Ho Chi Minh City', '2021-04-20', '2021-04-20', 5000, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-01-20', '2021-01-20')
insert into [dbo].[Order] Values(35,17,9,'Ho Chi Minh City', '2021-04-20', '2021-04-20', 9876, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-01-20', '2021-01-20')
insert into [dbo].[Order] Values(36,22,1,'Ho Chi Minh City', '2021-04-20', '2021-04-20', 2356, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-01-20', '2021-01-20')
insert into [dbo].[Order] Values(37,20,2,'Ho Chi Minh City', '2021-02-20', '2021-02-20', 999, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-02-20', '2021-02-20')
insert into [dbo].[Order] Values(38,8,3,'Ho Chi Minh City', '2021-02-20', '2021-02-20', 893, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-02-20', '2021-02-20')
insert into [dbo].[Order] Values(39,11,4,'Ho Chi Minh City', '2021-04-20', '2021-04-20', 4154, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-04-20', '2021-04-20')
insert into [dbo].[Order] Values(40,1,5,'Ho Chi Minh City', '2021-04-25', '2021-04-26', 2150, 'COMPLETE', 200, '', 'Please contact me soon!', '2021-04-20', '2021-04-20')
insert into [dbo].[Order] Values(41,9,6,'Ho Chi Minh City', '2021-02-20', '2021-02-21', 1003, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2021-02-20', '2021-02-20')
insert into [dbo].[Order] Values(42,12,7,'Ho Chi Minh City', '2021-04-29', '2021-04-30', 1403, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2021-04-26', '2021-04-26')


insert into [dbo].[Order] Values(43,1,1,'Ho Chi Minh City', '2022-01-20', '2022-01-23', 8000, 'COMPLETE', 100, '', 'Please contact me soon!', '2022-01-20', '2022-01-20')
insert into [dbo].[Order] Values(44,2,2,'Ho Chi Minh City', '2022-01-12', '2022-01-13', 757, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2022-01-12', '2022-01-12')
insert into [dbo].[Order] Values(45,3,3,'Ho Chi Minh City', '2022-03-12', '2022-03-14', 571, 'COMPLETE', 100, '', 'Please contact me soon!', '2022-03-12', '2022-03-12')
insert into [dbo].[Order] Values(46,8,4,'Ho Chi Minh City', '2022-05-22', '2022-05-23', 9874, 'COMPLETE', 100, '', 'Please contact me soon!', '2022-05-22', '2022-05-22')
insert into [dbo].[Order] Values(47,7,5,'Ho Chi Minh City', '2022-12-20', '2022-12-20', 744, 'COMPLETE', 200, '', 'Please contact me soon!', '2022-12-20', '2022-12-20')
insert into [dbo].[Order] Values(48,6,6,'Ho Chi Minh City', '2022-06-20', '2022-06-21', 8754, 'CANCELBYADMIN', 500, '', 'Please contact me soon!', '2022-06-20', '2022-06-20')
insert into [dbo].[Order] Values(49,7,7,'Ho Chi Minh City', '2022-07-20', '2022-07-20', 1425, 'COMPLETE', 200, '', 'Please contact me soon!', '2022-07-20', '2022-07-20')
insert into [dbo].[Order] Values(50,11,8,'Ho Chi Minh City', '2022-07-20', '2022-07-20', 5042, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2022-07-20', '2022-07-20')
insert into [dbo].[Order] Values(51,22,9,'Ho Chi Minh City', '2023-01-20', '2023-01-20', 6000, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(52,23,10,'Ho Chi Minh City', '2023-01-19', '2023-01-20', 2000, 'PENDING', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(53,4,1,'Ho Chi Minh City', '2023-01-01', '2023-01-03', 100000, 'COMPLETE', 2000, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(54,18,2,'Ho Chi Minh City', '2023-01-01', '2023-01-03', 10100, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-01', '2023-01-03')
insert into [dbo].[Order] Values(55,19,3,'Ho Chi Minh City', '2023-03-20', '2023-03-20', 1001, 'CANCELBYUSER', 200, '', 'Please contact me soon!', '2023-03-20', '2023-03-20')
insert into [dbo].[Order] Values(56,17,4,'Ho Chi Minh City', '2023-03-20', '2023-03-20', 3567, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-03-20', '2023-03-20')
insert into [dbo].[Order] Values(57,12,5,'Ho Chi Minh City', '2023-03-20', '2023-03-20', 4534, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-03-20', '2023-03-20')
insert into [dbo].[Order] Values(58,14,6,'Ho Chi Minh City', '2023-03-20', '2023-03-20', 4888, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-03-20', '2023-03-20')
insert into [dbo].[Order] Values(59,16,7,'Ho Chi Minh City', '2023-01-20', '2023-01-20', 3453, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(60,18,8,'Ho Chi Minh City', '2023-04-20', '2023-04-20', 3453, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(61,17,9,'Ho Chi Minh City', '2023-04-20', '2023-04-20', 9876, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(62,10,1,'Ho Chi Minh City', '2023-04-20', '2023-04-20', 7558, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-01-20', '2023-01-20')
insert into [dbo].[Order] Values(63,11,2,'Ho Chi Minh City', '2023-02-20', '2023-02-20', 999, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-02-20', '2023-02-20')
insert into [dbo].[Order] Values(64,8,3,'Ho Chi Minh City', '2023-02-20', '2023-02-20', 7548, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-02-20', '2023-02-20')
insert into [dbo].[Order] Values(65,3,4,'Ho Chi Minh City', '2023-04-20', '2023-04-20', 4154, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-04-20', '2023-04-20')
insert into [dbo].[Order] Values(66,8,5,'Ho Chi Minh City', '2023-04-25', '2023-04-26', 3384, 'COMPLETE', 200, '', 'Please contact me soon!', '2023-04-20', '2023-04-20')
insert into [dbo].[Order] Values(67,9,6,'Ho Chi Minh City', '2023-02-20', '2023-02-21', 1003, 'PENDING', 200, '', 'Please contact me soon!', '2023-02-20', '2023-02-20')
insert into [dbo].[Order] Values(68,12,7,'Ho Chi Minh City', '2023-04-29', '2023-04-30', 1403, 'PENDING', 200, '', 'Please contact me soon!', '2023-04-26', '2023-04-26')


insert into [dbo].[Contract] values(1,1,1, 'COMPLETE', 10100, 10100, 0, '', 'BROKEN','', '2019-01-01', '2019-01-03')
insert into [dbo].[Contract] values(2,2,1, 'COMPLETE', 2222, 2222, 0, '', 'INTACT','', '2019-03-20', '2019-03-20')
insert into [dbo].[Contract] values(3,3,1, 'COMPLETE', 1234, 1234, 0, '', 'INTACT','', '2019-03-20', '2019-03-20')
insert into [dbo].[Contract] values(4,4,1, 'COMPLETE', 4888, 4888, 0, '', 'BROKEN','', '2019-03-20', '2019-03-20')
insert into [dbo].[Contract] values(5,5,1, 'COMPLETE', 1000, 1000, 0, '', 'INTACT','', '2019-01-20', '2019-01-20')
insert into [dbo].[Contract] values(6,6,1, 'COMPLETE', 1000, 1000, 0, '', 'INTACT','', '2019-01-20', '2019-01-20')
insert into [dbo].[Contract] values(7,7,1, 'COMPLETE', 9876, 9876, 0, '', 'INTACT','', '2019-01-20', '2019-01-20')
insert into [dbo].[Contract] values(8,8,1, 'COMPLETE', 7558, 7558, 0, '', 'INTACT','', '2019-01-20', '2019-01-20')
insert into [dbo].[Contract] values(9,9,1, 'COMPLETE', 999, 999, 0, '', 'INTACT','', '2019-02-20', '2019-02-20')
insert into [dbo].[Contract] values(10,10,1, 'COMPLETE', 7890, 7890, 0, '', 'INTACT','', '2019-02-20', '2019-02-20')
insert into [dbo].[Contract] values(11,11,1, 'COMPLETE', 2013, 2013, 0, '', 'INTACT','', '2019-04-20', '2019-04-20')
insert into [dbo].[Contract] values(13,13,1, 'COMPLETE', 1003, 1003, 0, '', 'BROKEN','', '2019-04-20', '2019-04-20')
insert into [dbo].[Contract] values(14,14,1, 'COMPLETE', 1403, 1403, 0, '', 'BROKEN','', '2019-04-26', '2019-04-26')

insert into [dbo].[Contract] values(15,15,1, 'COMPLETE', 10100, 10100, 0, 'The service is good', 'INTACT','', '2020-01-01', '2020-01-03')
insert into [dbo].[Contract] values(16,16,1, 'COMPLETE', 700, 700, 0, '', 'INTACT','', '2020-03-20', '2020-03-20')
insert into [dbo].[Contract] values(17,17,1, 'COMPLETE', 4534, 4534, 0, '', 'INTACT','', '2020-03-20', '2020-03-20')
insert into [dbo].[Contract] values(18,18,1, 'COMPLETE', 4888, 4888, 0, '', 'INTACT','', '2020-03-20', '2020-03-20')
insert into [dbo].[Contract] values(19,19,1, 'COMPLETE', 900, 900, 0, '', 'INTACT','', '2020-01-20', '2020-01-20')
insert into [dbo].[Contract] values(20,20,1, 'COMPLETE', 900, 900, 0, 'The car is so old', 'BROKEN','', '2020-01-20', '2020-01-20')
insert into [dbo].[Contract] values(21,21,1, 'COMPLETE', 9876, 9876, 0, '', 'INTACT','', '2020-01-20', '2020-01-20')
insert into [dbo].[Contract] values(22,22,1, 'COMPLETE', 500, 500, 0, '', 'INTACT','', '2020-01-20', '2020-01-20')
insert into [dbo].[Contract] values(23,23,1, 'COMPLETE', 999, 999, 0, '', 'INTACT','', '2020-02-20', '2020-02-20')
insert into [dbo].[Contract] values(24,24,1, 'COMPLETE', 2000, 2000, 0, 'I like this service', 'INTACT','', '2020-02-20', '2020-02-20')
insert into [dbo].[Contract] values(25,25,1, 'COMPLETE', 4154, 4154, 0, '', 'INTACT','', '2020-04-20', '2020-04-20')
insert into [dbo].[Contract] values(26,26,1, 'COMPLETE', 1234, 1234, 0, '', 'BROKEN','', '2020-04-20', '2020-04-20')

insert into [dbo].[Contract] values(27,29,1, 'COMPLETE', 1403, 1403, 0, '', 'INTACT','', '2021-01-01', '2021-01-03')
insert into [dbo].[Contract] values(28,30,1, 'COMPLETE', 3567, 3567, 0, '', 'INTACT','', '2021-03-20', '2021-03-20')
insert into [dbo].[Contract] values(29,31,1, 'COMPLETE', 1111, 1111, 0, '', 'INTACT','', '2021-03-20', '2021-03-20')
insert into [dbo].[Contract] values(30,32,1, 'COMPLETE', 4789, 4789, 0, '', 'INTACT','', '2021-03-20', '2021-03-20')
insert into [dbo].[Contract] values(31,33,1, 'COMPLETE', 5000, 5000, 0, 'This service is so good', 'BROKEN','', '2021-01-20', '2021-01-20')
insert into [dbo].[Contract] values(32,34,1, 'COMPLETE', 5000, 5000, 0, '', 'INTACT','', '2021-01-20', '2021-01-20')
insert into [dbo].[Contract] values(33,35,1, 'COMPLETE', 9876, 9876, 0, '', 'INTACT','', '2021-01-20', '2021-01-20')
insert into [dbo].[Contract] values(34,36,1, 'COMPLETE', 2356, 2356, 0, '', 'INTACT','', '2021-01-20', '2021-01-20')
insert into [dbo].[Contract] values(35,37,1, 'COMPLETE', 999, 999, 0, 'I like this service', 'INTACT','', '2021-02-20', '2021-02-20')
insert into [dbo].[Contract] values(36,38,1, 'COMPLETE', 893, 893, 0, 'The car is so cool', 'INTACT','', '2021-02-20', '2021-02-20')
insert into [dbo].[Contract] values(37,39,1, 'COMPLETE', 4154, 4154, 0, '', 'BROKEN','', '2021-04-20', '2021-04-20')
insert into [dbo].[Contract] values(38,40,1, 'COMPLETE', 2150, 2150, 0, '', 'BROKEN','', '2021-04-20', '2021-04-20')

insert into [dbo].[Contract] values(39,45,1, 'PAID', 571, 100, 471, 'The car is so good', 'INTACT','', '2022-03-12', '2022-03-12')
insert into [dbo].[Contract] values(40,46,2, 'PAID', 9874, 0, 9874, 'The car runs very smooth', 'BROKEN','Accidentally damage the car', '2022-05-22', '2022-05-22')
insert into [dbo].[Contract] values(41,47,3, 'PAID', 744, 0, 744, 'The car is so good', 'INTACT','', '2022-12-20', '2022-12-20')
insert into [dbo].[Contract] values(42,49,4, 'UNPAID', 1425, 200, 1225, 'Xe hoi cu', 'BROKEN','', '2022-07-20', '2022-07-20')
insert into [dbo].[Contract] values(43,51,4, 'UNPAID', 6000, 200, 5800, '', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(44,53,1, 'UNPAID', 100000, 2000, 8000, 'The car is so good', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(45,54,1, 'UNPAID', 10100, 200, 9900, '', 'BROKEN','', '2023-01-01', '2023-01-03')
insert into [dbo].[Contract] values(46,56,1, 'UNPAID', 3567, 200, 3167, '', 'BROKEN','', '2023-03-20', '2023-03-20')
insert into [dbo].[Contract] values(47,57,1, 'UNPAID', 4534, 200, 4234, '', 'BROKEN','', '2023-03-20', '2023-03-20')
insert into [dbo].[Contract] values(48,57,1, 'UNPAID', 4888, 200, 4688, '', 'INTACT','', '2023-03-20', '2023-03-20')
insert into [dbo].[Contract] values(49,59,1, 'UNPAID', 3453, 200, 3253, '', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(50,60,1, 'UNPAID', 3453, 200, 3253, '', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(51,61,1, 'UNPAID', 9876, 200, 9676, '', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(52,62,1, 'UNPAID', 7558, 200, 7358, '', 'INTACT','', '2023-01-20', '2023-01-20')
insert into [dbo].[Contract] values(53,63,1, 'UNPAID', 999, 200, 799, '', 'INTACT','', '2023-02-20', '2023-02-20')
insert into [dbo].[Contract] values(54,64,1, 'UNPAID', 7548, 200, 7348, '', 'INTACT','', '2023-02-20', '2023-02-20')
insert into [dbo].[Contract] values(55,65,1, 'UNPAID', 4154, 200, 3954, '', 'INTACT','', '2023-04-20', '2023-04-20')
insert into [dbo].[Contract] values(56,66,1, 'UNPAID', 3384, 200, 3184, '', 'BROKEN','', '2023-04-20', '2023-04-20')
