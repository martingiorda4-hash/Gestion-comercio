
ALTER TABLE [dbo].Libro
ADD idAutor int;
GO
ALTER TABLE [dbo].Libro 
ADD FOREIGN KEY (idAutor) REFERENCES Autor(idAutor);
GO

UPDATE Libro SET idAutor = 1 WHERE idLibro IN (1,2,3);
SELECT * FROM Autor;


INSERT INTO Autor (codigoAutor, nombre)
VALUES (101, 'Gabriel Márquez'),
       (102, 'Julio Cortázar'),
       (103, 'Ernesto Lopez');


INSERT INTO Editorial (nombre)
VALUES ( 'Sudamericana'),
       ( 'Alfaguara'),
       ( 'Planeta');

INSERT INTO Libro (codigoLibro, titulo, isbn, idEditorial, nroPaginas)
VALUES (201, 'Cien años de soledad', 978123456, 1, 350),
       (202, 'El amor en los tiempos del cólera', 978234567, 1, 400),
       (203, 'Rayuela', 978345678, 2, 450),
       (204, 'Bestiario', 978456789, 2, 250),
       (205, 'El túnel', 978567890, 3, 200);
SELECT idLibro, titulo FROM Libro;
INSERT INTO Escribe (idAutor, idLibro)
VALUES (1, 5),
       (2, 6),
       (3, 7),
       (4, 8),
       (5, 9);


INSERT INTO Escribe (idAutor, idLibro)
VALUES (2, 5),
       (2, 8);

INSERT INTO Escribe (idAutor, idLibro)
VALUES (1, 5);

INSERT INTO Ejemplar (localizacion,codigoEjemplar,idLibro)
VALUES ('Estante A1',1, 5),
('Estante A1',2, 6),
('Estante B2',3, 8),
('Estante C3',4, 7),
('Estante D4',5, 9);

INSERT INTO Prestamo (idEjemplar, fechaInicio, fechaFin,idUsuario)
VALUES (9, '2025-10-01', '2025-10-20', 2),
       (13, '2025-09-15', '2025-09-30', 4),
       (13, '2025-12-03', '2025-12-18', 5),
       (13, '2025-08-13', '2025-09-13', 3);



--1)
SELECT a.nombre AS Autor, 
	   t.titulo AS Libro
	FROM Autor a
    INNER JOIN Escribe e ON a.idAutor = e.idAutor
	INNER JOIN Libro t ON e.idLibro = t.idLibro
	ORDER BY a.nombre
    
--2)
SELECT t.titulo AS Libro,
       e.nombre AS Editorial
    FROM Libro t 
    INNER JOIN Editorial e ON t.idEditorial = e.idEditorial
    ORDER BY e.nombre;

--3)
CREATE PROCEDURE sp_CrearEjemplar 
    @codigoEjemplar INT,
    @localizacion NVARCHAR(50),
    @idLibro INT
AS
BEGIN 
    SET NOCOUNT ON;

    INSERT INTO Ejemplar(codigoEjemplar,localizacion,idLibro) 
    VALUES (@codigoEjemplar,@localizacion,@idLibro);
END;
GO

EXEC sp_CrearEjemplar 
    @codigoEjemplar = 10,
    @localizacion = 'Estante B',
    @idLibro = 5;
	
SELECT * FROM Ejemplar;

--4)
ALTER PROCEDURE sp_IngresarPrestamo
     @fechaInicio DATE,
     @fechaFin DATE,
     @idUsuario INT,
     @idEjemplar INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Prestamo(fechaInicio,fechaFin,idUsuario,idEjemplar)
    VALUES (@fechaInicio,@fechaFin,@idUsuario,@idEjemplar);
END;
GO

EXEC sp_IngresarPrestamo 
    @fechaInicio = '20-10-2025',
    @fechaFin = '22-12-2025',
    @idUsuario = 2,
    @idEjemplar = 9;

SELECT * FROM Prestamo;