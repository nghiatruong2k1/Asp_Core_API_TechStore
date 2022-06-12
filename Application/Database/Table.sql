/*
create database Database_TTTN_0256
*/
use Database_TTTN_0256

go
	drop table if exists Product_0256
go
	create table Product_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		price int,
		salePrice int,
		currencyUnit char,
		imageId int,
		shortDes nvarchar(2000),
		fullDes ntext,
		properties ntext,
		categoryId int,
		brandId int,
		typeId int,
		createDate datetime,
		updateDate datetime,
		isShowHome bit default 0,
		isPublic bit default 1,
		isTrash bit default 0
	)


-----------------------------------------------
go
	drop table if exists ProductType_0256
go
	create table ProductType_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go
	drop table if exists ProductImage_0256
go
	create table ProductImage_0256(
		id int identity(1,1) primary key not null,
		alt nvarchar(100),
		productId int,
		imageId int,
		isDefault bit default 0,
		isPublic bit default 1,
		isTrash bit default 0
	)


-----------------------------------------------
go
	drop table if exists ProductRating_0256
go
	create table ProductRating_0256(
		id int identity(1,1) primary key not null,
		fullDes ntext,
		productId int,
		userId int,
		vote int,
		createDate datetime,
		updateDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go
	drop table if exists Category_0256
go
	create table Category_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		imageId int,
		orderIndex int,
		isPopular bit,
		createDate datetime,
		updateDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------

	
go
	drop table if exists Brand_0256
go
	create table Brand_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		imageId int,
		orderIndex int,
		isPopular bit,
		createDate datetime,
		updateDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------


go
	drop table if exists Image_0256
go
	create table Image_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		url text,
		type varchar(100),
		typeId int,
		size int,
		createDate datetime,
		updateDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------

go
	drop table if exists ImageType_0256
go
	create table ImageType_0256(
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		alias varchar(100),
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go 
	drop table if exists Order_0256
go
	create table Order_0256 (
		id int identity(1,1) primary key not null,
		userId int,
		createDate datetime,
		updateDate datetime,
		voucherSale int,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go 
	drop table if exists OrderStatus_0256
go
	create table OrderStatus_0256 (
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go 
	drop table if exists OrderVoucher_0256
go
	create table OrderVoucher_0256 (
		id int identity(1,1) primary key not null,
		name nvarchar(100),
		shortDes nvarchar(2000),
		code varchar(10),
		value int,
		createDate datetime,
		updateDate datetime,
		endDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go 
	drop table if exists OrderDetail_0256
go
	create table OrderDetail_0256 (
		id int identity(1,1) primary key not null,
		orderId int,
		productId int,
		price int,
		quantity int,
		statusId int default 1,
		isPublic bit default 1,
		isTrash bit default 0
	)
-----------------------------------------------
go
	drop table if exists User_0256
go
	create table User_0256(
	id int identity(1,1) primary key not null,
	firstName varchar(100),
	lastName varchar(100),
	email varchar(100),
	password varchar(100),
	typeId int default 1,
	createDate datetime,
	updateDate datetime,
	isPublic bit default 1,
	isTrash bit default 0
)

-----------------------------------------------
go
	drop table if exists UserType_0256
go
	create table UserType_0256(
	id int identity(1,1) primary key not null,
	name nvarchar(100),
	alias varchar(100),
	shortDes nvarchar(200),
	isPublic bit default 1,
	isTrash bit default 0
)
-------------------------------
go
	drop table if exists Slider_0256
go
	create table Slider_0256(
		id int identity(1,1) primary key not null,
		alt nvarchar(100),
		imageId int,
		orderIndex int,
		createDate datetime,
		updateDate datetime,
		isPublic bit default 1,
		isTrash bit default 0
	)



