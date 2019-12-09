use master;
go


-- DDL stands for Data Definition Language
-- create 
-- create a new database called PizzaBox
-- .mdf file = master data file, the first file a database creates to hold the database "stuff"
-- .ldf file = log data file, keeps track of changes in the database, queries run, etc., 
-- .ndf file = nonmaster data file, replicate more data files so the database can save more information, keeps the data files small so that the system can load them quickly, loaded via the .mdf file
create database PizzaBox;
go

use PizzaBox;
go

-- creating schemas (basically namespaces in c#)
-- colation is either in western or cyrillic depending on whether the language is symbolic or not, utf-8 supports all spoken languages
create schema [Order];
GO

create schema [Account];
GO

-- sequence is the process of determining the next value based on some rule
-- tsql has identity which is a type of sequence built into tsql
-- session sequence will increment as long as the session is alive
-- database wide sequence will only go up for as long as the database is up
-- identity has a seed and a step, seed is where it starts, step is how much it goes up
create table [Order].[Order]
(
    OrderId int not null identity(1,2) --primary key --inline way of defining primary key, cannot be easily changed, not ideal way but works
    ,UserId int not NULL --foreign key references [Account].[User].UserId --inline method of defining foreign key, again not recommended
    ,StoreId int not null --foreign key, 2nd normal form
    ,TotalCost decimal(3,2) not null--2 types of decimal numbers, decimal(number of digits before ., number of digits after .), numeric(total number of digits, number of digits after .)
    ,OrderDate datetime2(0) not null --date can be 4 types, date (year-month-day), time (hour-minute-seconds-milliseconds), datetime (year-month-day-hour-minute-sec-milisec), datetime2 (year-month-day-hour-minute-sec-milisec w/7 precision)
    ,Active bit not null --default
    ,constraint PK_Order_OrderId primary key (OrderId) --creates an index which can be changed later on, this is the better way of defining primary/foreign keys
    --,constraint FK_Order_StoreId foreign key (UserId) references [Account].[User](UserId)
);

create table [Order].[Pizza]
(
    PizzaId int not null identity(1,2) --primary key
    ,Price decimal(2,2) not NULL
    ,SizeId int not null --foreign key
    ,CrustId int not NULL --foreign key
    ,Active bit not null 
    ,constraint PK_Pizza_PizzaId primary key (PizzaId)
)

create table [Order].[OrderPizza]
(
    OrderPizzaId int not null identity(1,2) --primary key
    ,OrderId int not null --foreign key
    ,PizzaId int not null --foreign key
    ,Active bit not null
    ,constraint PK_OrderPizza_OrderPizzaId primary key (OrderPizzaId)
    ,constraint FK_OrderPizza_OrderId foreign key (OrderId) references [Order].[Order](OrderId)
    ,constraint FK_OrderPizza_PizzaId foreign key (PizzaId) references [Order].Pizza(PizzaId)
)

-- alter, can be used to define constraints on table in a compartmentalised way
--alter table [order].[order]
--    add constraint PK_Order_OrderId primary key (OrderId)

alter table [Order].[Order]
    add constraint DF_Order_Active default (1) for Active;

alter table [Order].[Pizza]
    add constraint DF_Pizza_Active default (1) for Active;

alter table [Order].[Order]
    add constraint CK_Order_TotalCost check (TotalCost < 500);

alter table [Order].[Order]
    add constraint CK_Order_OrderDate check (OrderDate > '2019-11-11');

alter table [Order].[Order]
    drop constraint CK_Order_OrderDate; 

alter table [Order].[Order]
    add TipAmount decimal(2,2) null;

alter table [Order].[Order]
    drop column TipAmount


--drop 
--drop table [Order].[OrderPizza]

--truncate
--truncate table [Order].[OrderPizza];

