CREATE DATABASE EjercicioTransporte;

USE EjercicioTransporte; 

CREATE TABLE Provincia (
idCodigo int IDENTITY (1,1) PRIMARY KEY, 
nombre NVARCHAR (50) NOT NULL
);

CREATE TABLE Camion(
idMatricula int identity(1,1) primary key, 
modelo nvarchar(50) not null, 
tipo nvarchar (50), 
potencia int
);

CREATE TABLE Camionero(
idDni nvarchar(20) primary key,
nombre nvarchar(50)not null,
Apellido nvarchar(50) not null,
direccion nvarchar(150) not null,
poblacion nvarchar(50) not null,
salario decimal(10,2) not null,
telefono nvarchar(20) not null
);


CREATE TABLE Paquete(
    idCodigo int identity(1,1) primary key,
    descripcion nvarchar(100),
    destinatario nvarchar(100),
    calle nvarchar(100) not null,
    numero int,
    idCamionero nvarchar(20) not null,
    idProvincia int not null,
    CONSTRAINT fk_Paquete_Camionero FOREIGN KEY(idCamionero)
        REFERENCES Camionero(idDni),
    CONSTRAINT fk_Paquete_Provincia FOREIGN KEY(idProvincia)
        REFERENCES dbo.Provincia(idCodigo)
);

CREATE TABLE Conduce(
idConduce int identity(1,1) primary key,
fecha DATETIME not null ,
idMatricula int not null,
idDni nvarchar(20) not null,
constraint fk_Conduce_Matricula foreign key(idMatricula) references Camion(idMatricula),
constraint fk_Conduce_Camionero foreign key(idDni) references Camionero(idDni)
);


INSERT INTO Provincia (nombre) VALUES
('Córdoba'),
('Santa Fe'),
('Mendoza'),
('Salta'),
('Buenos Aires');

INSERT INTO Camion (idPatente, modelo, tipo, potencia) VALUES
('AA123BB', 'Mercedes Benz Accelo', 'Corta Distancia', 450),
('AB456CD', 'Mercedes Benz Atego', 'Interurbano', 360),
('AC789DE', 'Iveco Daily', 'Mediano', 440),
('AD012FG', 'Volkswagen Delivery', 'Mediano', 540),
('AE345HI', 'Iveco Tector', 'Larga Distancia', 290);
