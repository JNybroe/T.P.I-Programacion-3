USE master;
GO
CREATE DATABASE Clinica_G21;
GO
USE Clinica_G21;

CREATE TABLE Provincias
(
	IdProvincia int IDENTITY(1, 1) not null,
	NombreProvincia varchar(25) not null,
	CONSTRAINT PK_IdProvincia PRIMARY KEY (IdProvincia)
);
GO

CREATE TABLE Localidades
(
	IdLocalidad int IDENTITY(1, 1) not null,
	IdProvincia int not null,
	NombreLocalidad varchar(25) not null,
	CONSTRAINT PK_IdLocalidad PRIMARY KEY (IdLocalidad),
	CONSTRAINT FK_IdProvincia FOREIGN KEY (IdProvincia) REFERENCES Provincias(IdProvincia)
);
GO

CREATE TABLE Especialidades
(
	IdEspecialidad int IDENTITY(1, 1) not null,
	NombreEspecialidad varchar(25) not null,
	CONSTRAINT PK_IdEspecialidad PRIMARY KEY (IdEspecialidad)
);
GO

CREATE TABLE Pacientes
(
	IdPaciente int IDENTITY(1, 1) not null,
	NombrePaciente varchar(25) not null,
	ApellidoPaciente varchar(25) not null,
	DNI varchar(8) not null,
	Sexo char(1) not null,
	Nacionalidad varchar(25) not null,
	FechaNacimiento date not null,
	Direccion varchar(25) null,
	Telefono varchar(25) null,
	Email varchar(25) null,
	IdProvincia int not null,
	IdLocalidad int not null,
	Activo bit not null DEFAULT(1),
	CONSTRAINT PK_IdPaciente PRIMARY KEY (IdPaciente),
	CONSTRAINT FK_Paciente_IdProvincia FOREIGN KEY (IdProvincia) REFERENCES Provincias(IdProvincia),
	CONSTRAINT FK_Paciente_IdLocalidad FOREIGN KEY (IdLocalidad) REFERENCES Localidades(IdLocalidad),
	CONSTRAINT UK_Paciente_InfoPersonal UNIQUE (NombrePaciente ,ApellidoPaciente, DNI),
);
GO

CREATE TABLE Usuarios
(
	IdUsuario int IDENTITY(1, 1) not null,
	nombreUsuario varchar(25) not null,
	contrasenia varchar(25) not null,
	nivelDePermiso varchar(25) not null,
	CONSTRAINT PK_IdUsuario PRIMARY KEY (IdUsuario)
);
GO

CREATE TABLE Medicos
(
	legajoMedico varchar(5) not null,
	IdEspecialidad int not null,
	IdUsuario int not null,
	IdLocalidad int not null,
	IdProvincia int not null,
	DNI varchar(8) not null,
	nombreMedico varchar(25) not null,
	apellidoMedico varchar(25) not null,
	Sexo char(1) not null,
	Nacionalidad varchar(25) not null,
	FechaNacimiento date not null,
	Direccion varchar(25) null,
	Telefono varchar(25) null,
	Email varchar(25) null,
	Activo bit not null DEFAULT(1),
	CONSTRAINT PK_LegajoMedico PRIMARY KEY (legajoMedico),
	CONSTRAINT FK_Medico_Especialidad FOREIGN KEY (IdEspecialidad) REFERENCES Especialidades(IdEspecialidad),
	CONSTRAINT FK_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Medico_IdProvincia FOREIGN KEY (IdProvincia) REFERENCES Provincias(IdProvincia),
	CONSTRAINT FK_Medico_IdLocalidad FOREIGN KEY (IdLocalidad) REFERENCES Localidades(IdLocalidad),
	CONSTRAINT UK_Medico_InfoPersonal UNIQUE (nombreMedico, apellidoMedico, DNI)
);
GO
CREATE TABLE Turnos
(
	IdTurno int IDENTITY(1, 1) not null,
	IdEspecialidad int not null,
	legajoMedico varchar(5) not null,
	IdPaciente int not null,
	dia date not null,
	hora smalldatetime not null,
	estado varchar(20) DEFAULT('PENDIENTE') not null,
	observacion varchar(200) DEFAULT(' '),
	CONSTRAINT PK_Turno PRIMARY KEY (IdTurno),
	CONSTRAINT FK_Turno_Especialidad FOREIGN KEY (IdEspecialidad) REFERENCES Especialidades(IdEspecialidad),
	CONSTRAINT FK_Turno_Paciente FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente),
	CONSTRAINT FK_Turno_Medico FOREIGN KEY (legajoMedico) REFERENCES Medicos(legajoMedico)
);
GO
INSERT INTO Provincias (NombreProvincia) VALUES
('Buenos Aires'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Cordoba'),
('Corrientes'),
('Entre Rios'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquen'),
('Tucuman');
GO

INSERT INTO Localidades (IdProvincia, NombreLocalidad) VALUES
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Tigre'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Cordoba'), 'Villa Carlos Paz'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'San Fernando'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Mendoza'), 'San Rafael'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'San Isidro'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Neuquen'), 'San Martín de los Andes'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Vicente Lopez'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Misiones'), 'Obera'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Olivos'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Jujuy'), 'Tilcara'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Martinez'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Beccar'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Victoria'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Pacheco'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Buenos Aires'), 'Troncos del Talar'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Catamarca'), 'San Fernando del Valle'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Chaco'), 'Resistencia'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Chubut'), 'Puerto Madryn'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Cordoba'), 'Rio Cuarto'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Corrientes'), 'Goya'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Entre Rios'), 'Parana'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Formosa'), 'Clorinda'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Jujuy'), 'Palpala'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='La Pampa'), 'Santa Rosa'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='La Rioja'), 'Chilecito'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Mendoza'), 'Godoy Cruz'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Misiones'), 'Posadas'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Neuquen'), 'Plottier'),
((SELECT IdProvincia FROM Provincias WHERE NombreProvincia='Tucuman'), 'San Miguel');
GO

INSERT INTO Usuarios (nombreUsuario, contrasenia, nivelDePermiso) VALUES
('hFacundo', 'herrera123', 'Administrador'),
('nJulian', 'nybroe123', 'Administrador'),
('lAxel', 'luvaglio123', 'Administrador'),
('gDaniel', 'Gonzalez123', 'Medico'),
('gLucas', 'Gomez123', 'Medico'),
('sNatalia', 'Soriana123', 'Medico'),
('bJoaquin', 'Burgos123', 'Medico'),
('oLorena', 'Olivera123', 'Medico'),
('eLuis', 'Espinoza123', 'Medico'),
('mCristina', 'Mena123', 'Medico'),
('hElizabeth', 'Hernandez123', 'Medico'),
('oGustavo', 'Ochoa123', 'Medico'),
('aMariano', 'Arroyo123', 'Medico'),
('rCarlos', 'Romero123', 'Medico'),
('tAlexandra', 'Torres123', 'Medico'),
('mRoberto', 'Martuccio123', 'Medico'),
('hGraciela', 'Herrera123', 'Medico'),
('eMaximiliano', 'Espinoza123', 'Medico')
GO

INSERT INTO Especialidades (NombreEspecialidad) VALUES
('Cardiologia'),
('Dermatología'),
('Gastroenterologia'),
('Diabetologia'),
('Pediatria'),
('Ginecologia'),
('Oftalmologia'),
('Ortopedia'),
('Psicologia'),
('Kinesiologia'),
('Odontologia'),
('Foniatria'),
('Neumonologia'),
('Nutricion'),
('Psicopedagogia');
GO

INSERT INTO Medicos(legajoMedico, nombreMedico, apellidoMedico, DNI, Sexo, Nacionalidad, FechaNacimiento, Direccion, Telefono, Email, IdEspecialidad, IdProvincia, IdLocalidad, IdUsuario) VALUES
('A0001','Daniel','Gonzalez','40000000', 'M', 'Argentino', '1978-02-12', 'Av Jose Paz 1234', '11-2233-4455', 'DanyGonza@gmail.com', 1, 1, 5, 4),
('A0002','Lucas','Gomez','40000001', 'M', 'Argentino', '1998-11-05', 'Chacabuco 5678', '11-2233-4456', 'luquitaz@gmail.com', 4, 2, 16, 5),
('A0003','Natalia','Soriana','40000002', 'F', 'Argentino', '1994-04-25', 'Av Calle Falsa 1234', '11-2233-4457', 'Sorianatalia@outlook.com', 10, 13, 27, 6),
('A0004','Joaquin','Burgos','40000003', 'M', 'Uruguayo', '1999-06-27', '308 de Negra Arroyo Lane', '11-2233-4458', 'JoaoBurgos@hotmail.com', 9, 5, 19, 7),
('A0005','Lorena','Olivera','40000004', 'O', 'Chileno', '2000-05-15', 'Corrientes 343', '11-2233-4459', 'Lorena.Olivera@gmail.com', 12, 10, 24, 8),
('A0006','Luis','Espinoza','40000005', 'M', 'Peruano', '1985-03-10', 'Av Independencia 1239', '11-2233-4460', 'Espinoza_Luis@gmail.com', 12, 10, 24, 9),
('A0007','Cristina','Mena','40000006', 'F', 'Español', '1979-11-09', 'Av San Martin 3462', '11-2233-4461', 'CMena@outlook.com', 2, 4, 18, 10),
('A0008','Elizabeth','Hernández','40000007', 'F', 'Brasileño', '1961-07-19', 'Las Piedras 5367', '11-2233-4461', 'Elizabeth123@hotmail.com', 14, 1, 9, 11),
('A0009','Gustavo','Ochoa','40000008', 'M', 'Paraguayo', '1990-08-21', 'Belgrano 6243', '11-2233-4462', 'GusOchoa@gmail.com', 15, 8, 22, 12),
('A0010','Mariano','Arroyo','40000009', 'O', 'Argentino', '1984-04-05', 'Hipolito Yrigoyen 2351', '11-2233-4463', 'ArroyoM@gmail.com', 13, 1, 11, 13),
('A0011','Carlos','Romero','40000010', 'M', 'Boliviano', '1975-09-29', 'Matheur 3738', '11-2233-4464', 'CRomero@outlook.com', 8, 6, 20, 14),
('A0012','Alexandra ','Torres','40000011', 'F', 'Venezolano', '1991-01-30', 'Av Avellaneda 2643', '11-2233-4465', 'TorresAlexa@hotmail.com', 5, 1, 3, 15),
('A0013','Roberto','Martuccio','40000012', 'M', 'Peruano', '1997-08-16', 'Rio grande 4352', '11-2233-4466', 'MartuccioR@gmail.com', 11, 10, 24, 16),
('A0014','Graciela','Herrera','40000013', 'F', 'Argentino', '1978-12-19', 'Pasteur 1289', '11-2233-4467', 'GraHerre@outlook.com', 4, 7, 21, 17),
('A0015','Maximiliano','Espinoza','40000014', 'M', 'Uruguayo', '1983-08-02', 'Av Independencia 1978', '11-2233-4468', 'EspinozaMax@gmail.com', 6, 10, 24, 18)
GO

INSERT INTO Pacientes(NombrePaciente,ApellidoPaciente,DNI,Sexo,Nacionalidad,FechaNacimiento,Direccion,Telefono,Email,IdProvincia,IdLocalidad) VALUES
('Carlos','Perez','40000015','M','Argentino','1999-01-23','Av Calle Falsa 987','12-3456-7890','carlitoxperez@outlook.com',1,1),
('Aldana','Miranda','40000016','F','Argentino','1986-04-19','Av Independencia 525','12-3456-7891','miranda_aldana@gmail.com',13,8),
('Gonzalo','Gomez','40000017','M','Uruguayo','1978-11-06','Matheur 1275','12-3456-7892','GGonza@hotmail.com',3,17),
('Fernando','Vargas','40000018','O','Mexicano','2000-09-30','Chacabuco 4573','12-3456-7893','carlitoxperez@outlook.com',1,12),
('Tatiana','Burgos','40000019','F','Argentino','1978-05-13','Pasteur 253','12-3456-7894','tatiburgos@gmail.com',1,5),
('Caleb','Correa','40000020','M','Chileno','1994-03-04','San Martin 863','12-3456-7895','correacaleb@hotmail.com',7,21),
('Mariana','Romero','40000021','F','Paraguayo','1986-10-14','Belgrano 643','12-3456-7896','marianarome@outlook.com',5,19),
('Braian','Martinez','40000022','O','Argentino','1979-12-01','Av Libertad 6543','12-3456-7897','brianmartinez@outlook.com',3,17),
('Jazmin','Bustos','40000023','F','Brasileño','2003-03-23','Las Piedras 753','12-3456-7898','jazminbustos@gmail.com',1,14),
('Roberto','Torres','40000024','M','Boliviano','1999-02-10','Lavalle 5423','12-3456-7899','robertotorres@hotmail.com',13,27),
('Gustavo','Alvarez','40000025','M','Español','1967-11-08','Necochea 4367','12-3456-7900','gusalvarez@outlook.com',11,25),
('Martina','Acosta','40000026','F','Colombiano','1975-04-06','Hipolito Yrigoyen 823','12-3456-7901','carlitoxperez@outlook.com',6,20),
('Sasha','Vera','40000027','O','Argentino','1996-07-23','Rio grande 543','12-3456-7902','carlitoxperez@outlook.com',12,26),
('Alejandro','Cabrera','40000028','M','Peruano','1970-08-18','Av Jose Paz 2145','12-3456-7903','carlitoxperez@outlook.com',7,21),
('Lucia','Pereyra','40000029','F','Argentino','2002-12-05','Martinez 654','12-3456-7904','carlitoxperez@outlook.com',1,9),
('Pablo','Acuña','40000030','O','Venezonlano','1984-06-09','Av Calle Falsa 324','12-3456-7905','carlitoxperez@outlook.com',14,6)
GO

INSERT INTO Turnos(IdEspecialidad,legajoMedico,IdPaciente,dia,hora,estado) VALUES
(1,'A0001',1,'2024-07-20','2024-07-20 08:00:00','PENDIENTE'),
(4,'A0002',3,'2024-08-21','2024-08-21 13:00:00','PENDIENTE'),
(10,'A0003',9,'2025-10-09','2025-10-09 20:00:00','PENDIENTE'),
(2,'A0007',13,'2023-11-01','2023-11-01 08:00:00','AUSENTE'),
(14,'A0008',4,'2024-07-01','2024-07-01 15:00:00','PRESENTE'),
(11,'A0013',5,'2024-01-05','2024-01-05 11:00:00','AUSENTE'),
(15,'A0009',11,'2024-07-20','2024-07-20 17:00:00','PENDIENTE'),
(6,'A0015',10,'2024-07-30','2024-07-30 19:00:00','PENDIENTE'),
(9,'A0004',2,'2024-07-20','2024-07-20 08:00:00','PENDIENTE'),
(12,'A0005',6,'2021-02-20','2021-02-20 09:00:00','AUSENTE'),
(8,'A0011',7,'2024-06-03','2024-06-03 11:00:00','PRESENTE'),
(5,'A0012',8,'2024-10-09','2024-10-09 12:00:00','PENDIENTE'),
(4,'A0014',12,'2024-04-21','2024-04-21 14:00:00','AUSENTE'),
(13,'A0010',14,'2024-12-01','2024-12-01 08:00:00','PENDIENTE'),
(1,'A0001',15,'2024-07-05','2024-07-05 08:00:00','PRESENTE')
GO

CREATE PROCEDURE SpAgregarMedico
(
    @legajoMedico varchar(5),
    @IdEspecialidad int,
    @IdUsuario int,
    @IdLocalidad int,
    @IdProvincia int,
    @DNI varchar(8),
    @nombreMedico varchar(25) ,
    @apellidoMedico varchar(25),
    @Sexo char(1), 
    @Nacionalidad varchar(25), 
    @FechaNacimiento date, 
    @Direccion varchar(25), 
    @Telefono varchar(25), 
    @Email varchar(25) 
)
AS
INSERT INTO Medicos(legajoMedico,nombreMedico,apellidoMedico,DNI,IdEspecialidad,IdProvincia,IdLocalidad,IdUsuario,Sexo,Nacionalidad,FechaNacimiento,Direccion,Telefono,Email) VALUES
(@legajoMedico,@nombreMedico,@apellidoMedico,@DNI,@IdEspecialidad,@IdProvincia,@IdLocalidad,@IdUsuario,@Sexo,@Nacionalidad,@FechaNacimiento,@Direccion,@Telefono,@Email)
RETURN
GO
CREATE PROCEDURE SpAgregarUsuario
(
    @nombreUsuario varchar(25),
    @contrasenia varchar(25),
    @nivelDePermiso varchar(25)
)
AS
INSERT INTO Usuarios(nombreUsuario,contrasenia,nivelDePermiso) VALUES(@nombreUsuario, @contrasenia, @nivelDePermiso)
RETURN
GO


CREATE PROCEDURE SpAgregarPaciente
(
@NombrePaciente varchar(25) ,
@ApellidoPaciente varchar(25),
@DNI varchar(8),
@Sexo char(1),
@Nacionalidad varchar(25),
@FechaNacimiento date,
@Direccion varchar(25),
@Telefono varchar(25),
@Email varchar(25),
@IdProvincia int,
@IdLocalidad int

)
AS
INSERT INTO Pacientes(NombrePaciente, ApellidoPaciente, DNI, Sexo, Nacionalidad, FechaNacimiento, Direccion,
Telefono, Email, IdProvincia, IdLocalidad)
VALUES (@NombrePaciente, @ApellidoPaciente, @DNI, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Telefono,
@Email, @IdProvincia, @IdLocalidad)
RETURN
GO

CREATE PROCEDURE spBajaLogicaPaciente
(
@IDPACIENTE INT
)
AS
UPDATE Pacientes SET Activo = 0
WHERE IdPaciente = @IDPACIENTE;
RETURN
GO




CREATE PROCEDURE SpBajaLogicaMedico
(
    @legajoMedico varchar(5)
)
AS
UPDATE Medicos SET Activo = 0 WHERE legajoMedico = @legajoMedico
RETURN
GO
CREATE PROCEDURE SpActualizarMedico
(
    @legajoMedico varchar(5),
    @IdEspecialidad int,
    @IdLocalidad int,
    @IdProvincia int,
    @DNI varchar(8),
    @nombreMedico varchar(25) ,
    @apellidoMedico varchar(25),
    @Sexo char(1), 
    @Nacionalidad varchar(25), 
    @FechaNacimiento date, 
    @Direccion varchar(25), 
    @Telefono varchar(25), 
    @Email varchar(25) 
)
AS
UPDATE Medicos SET IdEspecialidad = @IdEspecialidad, IdLocalidad = @IdLocalidad,IdProvincia = @IdProvincia ,DNI = @DNI ,nombreMedico = @nombreMedico ,apellidoMedico = @apellidoMedico,Sexo = @Sexo ,Nacionalidad = @Nacionalidad, FechaNacimiento = @FechaNacimiento , Direccion = @Direccion , Telefono = @Telefono , Email = @Email WHERE legajoMedico = @legajoMedico
RETURN
GO
CREATE PROCEDURE SpActualizarUsuario
(
    @IdUsuario int,
    @nombreUsuario varchar(25),
    @contrasenia varchar(25)
)
AS
UPDATE Usuarios SET nombreUsuario = @nombreUsuario, contrasenia = @contrasenia WHERE IdUsuario = @IdUsuario
RETURN
GO
CREATE PROCEDURE SpAgregarTurno
(
    @IdEspecialidad int,
    @legajoMedico varchar(5),
    @IdPaciente int,
    @dia date,
    @hora smalldatetime
)
AS
INSERT INTO Turnos(IdEspecialidad,legajoMedico,IdPaciente,dia,hora) VALUES
(@IdEspecialidad,@legajoMedico,@IdPaciente,@dia,@hora)
RETURN
GO
CREATE PROCEDURE SpActualizarTurno
(
    @IdTurno int,
    @IdEspecialidad int,
    @legajoMedico varchar(5),
    @dia date,
    @hora smalldatetime
)
AS
UPDATE Turnos SET IdEspecialidad = @IdEspecialidad, legajoMedico = @legajoMedico, dia = @dia, hora = @hora WHERE IdTurno = @IdTurno
RETURN
GO
CREATE PROCEDURE SpActualizarEstadoTurno
(
	@IdTurno int,
	@estado varchar(20),
	@observacion varchar(200)
)
AS
UPDATE Turnos SET estado = @estado, observacion = @observacion
WHERE IdTurno = @IdTurno
GO

