create database AssetsManagement
go

use AssetsManagement
go

create table Account
(
	id int identity(1,1) primary key,
	username varchar(50),
	password varchar(50)
)
go

create table Repairer
(
	id int identity(1,1) primary key,
	name nvarchar(50)
)
go

create table Supplier
(
	id int identity(1,1) primary key,
	name varchar(50),
	address varchar(50),
	phone varchar(50)
)
go

create table Unit
(
	id int identity(1,1) primary key,
	name nvarchar(20),
	note nvarchar(50)
)
go

create table Types
(
	id int identity(1,1) primary key,
	name nvarchar(20),
	note nvarchar(50)
)
go

create table Division
(
	id int identity(1,1) primary key,
	name varchar(50),
	type varchar(20)
)
go

create table Contracts
(
	id int identity(1,1) primary key,
	status varchar(10),
	supplier int not null

	foreign key (supplier) references Supplier(id)
)
go

create table Personnel
(
	id int identity(1,1) primary key,
	name varchar(20),
	position varchar(20),
	division int not null

	foreign key (division) references Division(id)
)
go

create table Device
(
	id int identity(1,1) primary key,
	name nvarchar(50),
	price money,
	specification nvarchar(50),
	production_year int,
	implement_year int,
	status nvarchar(50),
	annual_value_lost float,
	contract int not null,
	holding_division int not null,
	unit int not null,
	type int not null

	foreign key (contract) references Contracts(id),
	foreign key (holding_division) references Division(id),
	foreign key (unit) references Unit(id),
	foreign key (type) references Types(id)
)
go