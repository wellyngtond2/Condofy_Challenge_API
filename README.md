# Condofy_Challenge_API

First Run this script in Sql Server:
```sql
use master;
go

IF(DB_ID(N'condofyDB') is null)
	Create database condofyDB;
go

use condofyDB;

go

if not exists (select 1 from  sysobjects
			   where  id = object_id('funcionarios')
			   and   type = 'U')
CREATE TABLE funcionarios(
	Id int NOT NULL,
	Name varchar(54),
	Gender varchar(1),
	Salary numeric(7,2),
	Level varchar(1),
	HiringDate datetime,
	BirthDay datetime,
	PRIMARY KEY (Id))
  ```
  
