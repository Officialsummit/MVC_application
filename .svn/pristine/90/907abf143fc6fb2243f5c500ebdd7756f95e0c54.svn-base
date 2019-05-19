SET NOCOUNT ON
GO
:On Error exit

if exists(select name from master.sys.databases where name='$(DBName)')
drop database $(DBName)
GO

create database $(DBName)
GO