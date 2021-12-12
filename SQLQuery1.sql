
--Database creation script
CREATE DATABASE EmployeeDB

--Scripts for DB
--1st Table

CREATE TABLE dbo.Department(
DepartmentId int identity(1,1),
DepartmentName varchar(500)
)

GO

SELECT * FROM  dbo.Department

GO

INSERT into dbo.Department values('IT')
INSERT into dbo.Department values('Support')

GO

--2nd Table
CREATE TABLE dbo.Employee(
EmployeeId int identity(1,1),
EmployeeName varchar(500),
Department varchar(500),
DateOfJoining date,
PhotoFileName varchar(500)
)

GO

INSERT into dbo.Employee values('Sam','IT','2020-06-01', 'anonymous.png')
INSERT into dbo.Employee values('Sam','IT','2020-06-01', 'anonymous.png')

SELECT * FROM  dbo.Employee


