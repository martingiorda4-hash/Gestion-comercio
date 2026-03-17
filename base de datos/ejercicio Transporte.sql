CREATE DATABASE Transporte;

use Transporte;

CREATE TABLE Provincia (
idProvincia INT IDENTITY(1,1) PRIMARY KEY,
nombre NVARCHAR(50) NOT NULL
);

CREATE TABLE Area (
idArea INT IDENTITY(1,1) PRIMARY KEY,
nombreArea NVARCHAR(50) NOT NULL
);

CREATE TABLE Camion (
idPatente NVARCHAR(20) PRIMARY KEY,
modelo NVARCHAR(50) NOT NULL,
tipo NVARCHAR(50),
potencia INT
);

CREATE TABLE Ciudad (
idCiudad INT IDENTITY(1,1) PRIMARY KEY,
nombre NVARCHAR(100) NOT NULL,
idProvincia INT NOT NULL,
CONSTRAINT fk_Ciudad_Provincia FOREIGN KEY (idProvincia) REFERENCES
provincia(idProvincia)
);

CREATE TABLE Camionero (
idDni NVARCHAR(20) PRIMARY KEY,
nombre NVARCHAR(100) NOT NULL,
apellido NVARCHAR(100) NOT NULL,
calle NVARCHAR(100),
numero INT,
salario DECIMAL(10, 2),
telefono NVARCHAR(20),
idCiudad INT NOT NULL,
idArea INT,
CONSTRAINT fk_camionero_ciudad FOREIGN KEY (idCiudad) REFERENCES ciudad(idCiudad),
CONSTRAINT fk_camionero_area FOREIGN KEY (idArea) REFERENCES area(idArea)
);

CREATE TABLE Destinatario (
idDni NVARCHAR(20) PRIMARY KEY,
nombre NVARCHAR(100) NOT NULL,
apellido NVARCHAR(100) NOT NULL,
calle NVARCHAR(100),
numero INT,
telefono NVARCHAR(20),
idCiudad INT NOT NULL,
idArea INT,
CONSTRAINT fk_destinatario_ciudad FOREIGN KEY (idCiudad) REFERENCES ciudad(idCiudad),
CONSTRAINT fk_destinatario_area FOREIGN KEY (idArea) REFERENCES area(idArea)
);

CREATE TABLE Paquete (
idCodigo INT IDENTITY(1,1) PRIMARY KEY,
descripcion NVARCHAR(255) NOT NULL,
idDestinatario NVARCHAR(20) NOT NULL,
idCamionero NVARCHAR(20) NOT NULL,
CONSTRAINT fk_paquete_destinatario FOREIGN KEY (idDestinatario) REFERENCES
destinatario(idDni),
CONSTRAINT fk_paquete_camionero FOREIGN KEY (idCamionero) REFERENCES camionero(idDni)
);

CREATE TABLE Conduce (
idConduce INT IDENTITY(1,1) PRIMARY KEY,
fecha DATETIME NOT NULL,
idPatente NVARCHAR(20) NOT NULL,
idDni NVARCHAR(20) NOT NULL,
CONSTRAINT fk_conduce_patente FOREIGN KEY (idPatente) REFERENCES camion(idPatente),
CONSTRAINT fk_conduce_camionero FOREIGN KEY (idDni) REFERENCES camionero(idDni)
);

INSERT INTO Area (nombreArea) VALUES
('03564'),
('0351'),
('0341'),
('0261'),
('0387');

INSERT INTO Provincia (nombre) VALUES
('Córdoba'),
('Santa Fe'),
('Mendoza'),
('Salta'),
('Buenos Aires');

INSERT INTO Ciudad (nombre, idProvincia) VALUES
('San Francisco', 1),
('Córdoba', 1),
('Arroyito', 1),
('Rosario', 2),
('Santa Fe Capital', 2),
('Rafaela', 2),
('Mendoza', 3),
('San Rafael', 3),
('Godoy Cruz', 3),
('Salta', 4),
('Orán', 4),
('Cafayate', 4),
('La Plata', 5),
('Mar del Plata', 5),
('Bahía Blanca', 5);

INSERT INTO Camion (idPatente, modelo, tipo, potencia) VALUES
('AA123BB', 'Mercedes Benz Accelo', 'Corta Distancia', 450),
('AB456CD', 'Mercedes Benz Atego', 'Interurbano', 360),
('AC789DE', 'Iveco Daily', 'Mediano', 440),
('AD012FG', 'Volkswagen Delivery', 'Mediano', 540),
('AE345HI', 'Iveco Tector', 'Larga Distancia', 290);

INSERT INTO Camionero (idDni, nombre, apellido, calle, numero, salario, telefono, idCiudad,
idArea) VALUES
('20111222', 'Javier', 'Gomez', 'Maipú', 150, 650000.00, '3564111111', 1, 1),
('25333444', 'Martina', 'Díaz', 'Independencia', 400, 720000.50, '3512222222', 2, 2),
('30555666', 'Lucas', 'Pérez', 'Sarmiento', 980, 580000.00, '3413333333', 4, 3),
('35777888', 'Valeria', 'Rojas', 'San Martín', 2050, 690000.00, '2614444444', 7, 4),
('40999000', 'Alfredo', 'Vargas', 'Salta', 10, 610000.00, '3875555555', 10, 5);

INSERT INTO Destinatario (idDni, nombre, apellido, calle, numero, telefono, idCiudad,
idArea) VALUES
('50123456', 'Logística', 'Sur', 'Ruta 19', 1200, '3564666666', 1, 1),
('51678901', 'Distribuidora', 'Norte', '27 de Abril', 50, '3517777777', 2, 2),
('52234567', 'Farmacia', 'Central', 'Oroño', 300, '3418888888', 4, 3),
('53890123', 'Bodega', 'Cruz', 'Libertad', 500, '2619999999', 7, 4),
('54456789', 'Minera', 'Luminosa', 'Alberdi', 100, '3870000000', 10, 5);

INSERT INTO Paquete (descripcion, idDestinatario, idCamionero) VALUES
('Caja de Herramientas, 10kg', '50123456', '20111222'),
('Muestras de Vino, Frágil', '53890123', '35777888'),
('Documentación Contable', '51678901', '20111222'),
('Insumos Médicos', '52234567', '30555666'),
('Minerales para Análisis', '54456789', '40999000');

INSERT INTO Conduce (fecha, idPatente, idDni) VALUES
('2025-09-01', 'AA123BB', '20111222'),
('2025-09-02', 'AD012FG', '25333444'),
('2025-09-03', 'AA123BB', '30555666'),
('2025-09-04', 'AC789DE', '35777888'),
('2025-09-05', 'AB456CD', '20111222');

SELECT * FROM Area;
SELECT * FROM Camion;
SELECT * FROM Camionero;
SELECT * FROM Ciudad;
SELECT * FROM Conduce;
SELECT * FROM Destinatario;
SELECT * FROM Paquete;
SELECT * FROM Provincia;

--1) 
SELECT * FROM Camion WHERE potencia >= 400;

--2) 
SELECT nombre,apellido FROM  Camionero WHERE idDni = '35777888';

--3)
SELECT idPatente, potencia FROM Camion WHERE modelo = 'Iveco Daily'; 

--4)
SELECT nombre,salario FROM Camionero ORDER BY salario DESC;

--5)
SELECT idDni FROM Conduce WHERE fecha =  '2025-09-03';
