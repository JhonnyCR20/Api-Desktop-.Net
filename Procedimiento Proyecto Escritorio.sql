---------------------------------------------------------------------------------------------

--Procedimientos
--Procedimiento para consultar usuario login

IF EXISTS(SELECT NAME FROM dbo.sysobjects WHERE NAME ='SP_Cns_Usuario')
DROP PROCEDURE [SP_Cns_Usuario]
go

CREATE OR ALTER PROCEDURE [SP_Cns_Usuario](
@Login varchar(20),
@Passw varchar(20) )
AS
SELECT Login,Password
FROM Usuario
WHERE Login =rtrim(ltrim(@Login))
AND Password= rtrim(ltrim(@Passw))
go

insert into Usuario(login,password) values('Jhonny','123')
insert into Usuario(login,password) values('Byron','123')
go
select * from Usuario

-------------------------------------------------------------------
--Procedimiento para  conusltar por login
IF EXISTS(SELECT NAME FROM dbo.sysobjects WHERE NAME ='SP_Cns_Usuario_Catalogo')
DROP PROCEDURE [SP_Cns_Usuario_Catalogo]
go
CREATE OR ALTER PROCEDURE [SP_Cns_Usuario_Catalogo](
@login varchar(30))
as
SELECT u.Login,u.Password,u.FechaRegistro, u.Estado 
FROM Usuario u
WHERE Login like '%' + RTRIM(LTRIM(@login))+'%'
ORDER BY login
go

--TESTING 
EXEC [SP_Cns_Usuario_Catalogo] 'J' 

-----------------------------------------------------------------------------------
--Procedimiento almacenado para registrar los usuarios
if exists(select name from dbo.sysobjects where name ='Sp_Ins_Usuario') drop procedure[Sp_Ins_Usuario]
go
create procedure[Sp_Ins_Usuario](
@login varchar(20),
@Password varchar(20))
as
insert into Usuario(Login,Password) values (@login,@Password)
go
-----------------------------------------------------------------------------------
--Procedimmiento para Borrar usuarios
if exists(select name from dbo.sysobjects where name ='Sp_Del_Usuario') drop procedure[Sp_Del_Usuario]
go
Create or alter procedure[Sp_Del_Usuario](
@login varchar(100))
as
delete from Usuario where login = rtrim(ltrim(@login))
go
exec [Sp_Del_Usuario] 'Byron'
-----------------------------------------------------------------------------------
--Procedimiento para modificar usuarios
if exists(select name from dbo.sysobjects where name ='Sp_Udp_Usuario') drop procedure[Sp_Udp_Usuario]
go
create or alter procedure[Sp_Udp_Usuario](
@Log varchar(20),
@Pass varchar(20))
as
Update Usuario set
Password=@Pass
where login = rtrim(ltrim(@Log))
go
select * from cliente

