CREATE DATABASE Seguridad

DROP table UsuarioRol
DROP table RolOpcion
DROP table rol
DROP table usuario
DROP table opcion

CREATE TABLE Usuario
(
	UsuarioId int not null identity (1,1),
	Nombre varchar (100),
	Contrasena varchar (20),
	Correo varchar(500),
	Fecha date 

	constraint PK_Usuario Primary key(UsuarioId)
)

CREATE TABLE Rol
(
	RolId int not null identity(1,1),
	Nombre varchar (100)

	constraint PK_Rol Primary key(RolId)
)

CREATE TABLE Opcion
(
	OpcionId int not null identity (1,1),
	Nombre varchar (100)

	constraint PK_Opcion Primary key(OpcionID)
)

CREATE TABLE UsuarioRol
(
	UsuarioId int not null,
	RolId int  not null

	constraint PK_UsuarioRol Primary key(UsuarioId,RolId),

	constraint FK_UsuarioRol_Usuario foreign key(UsuarioId)
	references Usuario (UsuarioId),

	constraint FK_UsuarioRol_Rol foreign key (RolId)
	references Rol(RolId)
)

CREATE TABLE RolOpcion
(
	RolId int  not null, 
	OpcionId int not null

	constraint PK_Rol_Opcion Primary key(RolId,OpcionId),

	constraint FK_RolOpcion_Rol foreign  key (RolId)
	references Rol(RolId),

	constraint FK_RolOpcion_Opcion foreign key (OpcionId)
	references Opcion(OpcionId)
)




INSERT INTO Usuario 
SELECT  'Leidy','12345','ltsa0314@gmail.com',getdate()
UNION ALL SELECT'Tatiana','12345','ltsa0314@gmail.com',getdate()
UNION All SELECT   'Johan','12345','johan@gmail.com',getdate()
UNION All SELECT  'Jhonatan','12345','jhonatan0314@gmail.com',getdate()
UNION All SELECT  'Steven','12345','steven@gmail.com',getdate()
UNION All SELECT  'Dante','12345','dante@gmail.com',getdate()

INSERT INTO Rol
SELECT 'Admin'
UNION ALL SELECT 'RolA'
UNION ALL SELECT 'RolB'
UNION ALL SELECT 'RolC'
UNION ALL SELECT 'RolD'
UNION ALL SELECT 'RolE'

INSERT INTO Opcion
SELECT 'Opcion1'
UNION ALL SELECT 'Opcion2'
UNION ALL SELECT 'Opcion3'
UNION ALL SELECT 'Opcion4'
UNION ALL SELECT 'Opcion5'
UNION ALL SELECT 'Opcion6'
UNION ALL SELECT 'Opcion7'
UNION ALL SELECT 'Opcion8'
UNION ALL SELECT 'Opcion9'
UNION ALL SELECT 'Opcion10'
UNION ALL SELECT 'Opcion11'
UNION ALL SELECT 'Opcion12'
UNION ALL SELECT 'Opcion13'
UNION ALL SELECT 'Opcion14'
UNION ALL SELECT 'Opcion15'
UNION ALL SELECT 'Opcion16'
UNION ALL SELECT 'Opcion17'
UNION ALL SELECT 'Opcion18'
UNION ALL SELECT 'Opcion19'
UNION ALL SELECT 'Opcion20'
UNION ALL SELECT 'Opcion21'
UNION ALL SELECT 'Opcion22'
UNION ALL SELECT 'Opcion23'
UNION ALL SELECT 'Opcion24'
UNION ALL SELECT 'Opcion25'
UNION ALL SELECT 'Opcion26'
UNION ALL SELECT 'Opcion27'
UNION ALL SELECT 'Opcion28'
UNION ALL SELECT 'Opcion29'
UNION ALL SELECT 'Opcion30'

INSERT INTO RolOpcion
SELECT 1,OpcionId 
FROM Opcion 
WHERE OpcionId < 11
UNION ALL
SELECT 2,OpcionId 
FROM Opcion 
WHERE OpcionId BETWEEN  11 AND 30
UNION ALL
SELECT 3,OpcionId 
FROM Opcion 
WHERE OpcionId < 6
UNION ALL
SELECT 4,OpcionId 
FROM Opcion 
UNION ALL
SELECT 5,OpcionId 
FROM Opcion 
WHERE OpcionId BETWEEN  11 AND 20
UNION ALL
SELECT 6,OpcionId 
FROM Opcion 
WHERE OpcionId  BETWEEN 6 AND 10  

INSERT INTO UsuarioRol
SELECT 1,1
UNION ALL 
SELECT 2,2
UNION ALL 
SELECT 3,1
UNION ALL 
SELECT 3,2
UNION ALL 
SELECT 4,3
UNION ALL 
SELECT 5,4
UNION ALL
SELECT 6,3
UNION ALL
SELECT 6,5
UNION ALL
SELECT 6,6





SELECT u.Nombre, COUNT(ro.OpcionId) AS OpcionesHabilitadas
from Usuario u 
INNER JOIN UsuarioRol ur ON ur.UsuarioId = u.UsuarioId
INNER JOIN RolOpcion ro ON ro.RolId = ur.RolId 
GROUP BY  u.Nombre 
HAVING  COUNT(ro.OpcionId) > 10 


SELECT U.UsuarioId, u.Nombre, COUNT(ur.RolId) AS RolesAsociados
FROM Usuario u
INNER JOIN UsuarioRol ur ON ur.UsuarioId = u.UsuarioId
INNER JOIN  (
				SELECT	u.UsuarioId, u.Nombre , COUNT(ro.OpcionId) AS opc 
				FROM Usuario u
				INNER JOIN UsuarioRol ur on ur.UsuarioId= u.UsuarioId
				INNER JOIN RolOpcion ro on ro.RolId = ur.RolId
				GROUP BY  u.UsuarioId,u.Nombre 
				HAVING   COUNT(ro.OpcionId) BETWEEN 15 AND 30 
) AS op on op.UsuarioId = u.UsuarioId
GROUP BY  u.UsuarioId,u.Nombre 
HAVING  COUNT(ur.RolId) > 2  



SELECT U.UsuarioId, u.Nombre, COUNT(ur.RolId) AS RolesAsociados
FROM Usuario u
INNER JOIN UsuarioRol ur ON ur.UsuarioId = u.UsuarioId
GROUP BY  u.UsuarioId,u.Nombre 
HAVING  COUNT(ur.RolId) > 2  


SELECT	u.UsuarioId, u.Nombre , COUNT(ro.OpcionId) AS opc 
FROM Usuario u
INNER JOIN UsuarioRol ur on ur.UsuarioId= u.UsuarioId
INNER JOIN RolOpcion ro on ro.RolId = ur.RolId
GROUP BY  u.UsuarioId,u.Nombre 
HAVING   COUNT(ro.OpcionId) BETWEEN 15 AND 30 


SELECT r.Nombre, COUNT(ur.UsuarioId) AS UsuariosAsignados
FROM Rol r
INNER JOIN UsuarioRol ur on ur.RolId = r.RolId
GROUP by r.Nombre


SELECT TOP 3 r.Nombre, COUNT(ro.OpcionId) AS Opciones
from Rol r
INNER JOIN RolOpcion ro on ro.RolId = r.RolId
GROUP BY r.Nombre 
ORDER BY Opciones 

SELECT o.Nombre, COUNT(ur.UsuarioId)
FROM Opcion o
INNER JOIN RolOpcion ro on ro.OpcionId = o.OpcionId
INNER JOIN UsuarioRol ur on ur.RolId = ro.RolId
GROUP BY o.Nombre 
HAVING COUNT(ur.UsuarioId) < 4
