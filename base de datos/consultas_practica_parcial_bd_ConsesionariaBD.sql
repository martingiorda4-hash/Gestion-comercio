--D)
SELECT nombre, apellido, num_telefono 
FROM Cliente 
WHERE AreaID like '0%' OR AreaID like '2%'
ORDER BY apellido;

--E)
SELECT m.nombre_Marca, COUNT(a.MarcaID) AS Total_vendidos
FROM Marca m
INNER JOIN dbo.Auto a ON m.MarcaID = a.MarcaID
GROUP BY m.nombre_Marca

--F)
UPDATE Cliente SET num_telefono = '1550998877' WHERE dni = '30123456';
SELECT * FROM Cliente

--G)
SELECT m.nombre_Marca, AVG(c.precio) AS Precio_Venta
FROM Marca m
JOIN Modelo mo ON m.MarcaID = mo.MarcaID
JOIN dbo.Auto a ON mo.ModeloID = a.ModeloID
JOIN Compra c ON a.AutoID = c.AutoID
GROUP BY m.nombre_Marca

--H)
SELECT SUM(precio) AS Total_Recaudado
FROM Compra

--I)
SELECT n.nombre,nm.nombre_marca,nmo.Nombre_Modelo,c.fecha
FROM Compra c
JOIN Cliente n ON c.ClientID = n.ClientID
JOIN dbo.Auto a ON c.AutoID = a.AutoID
JOIN Modelo nmo ON a.ModeloID = nmo.ModeloID
JOIN Marca nm ON nmo.MarcaID = nm.MarcaID

--J)
SELECT a.Chasis, a.Año,m.nombre_marca,mo.Nombre_Modelo
FROM Auto a
JOIN Modelo mo ON a.ModeloID = mo.ModeloID
JOIN Marca m ON a.MarcaID = m.MarcaID
LEFT JOIN Compra c ON a.AutoID = c.AutoID
WHERE c.AutoID IS NULL

--k)
CREATE PROCEDURE SP_RegistrarVenta
	@ClientID INT,
	@AutoID INT,
	@fecha date,
	@precio decimal(10,2)
AS
BEGIN 
	SET NOCOUNT ON;

	INSERT INTO Compra (ClientID,AutoID,fecha,precio) VALUES (@ClientID,@AutoID,@fecha,@precio);
END;
GO
EXEC SP_RegistrarVenta
	@ClientID = 4,
	@AutoID = 1,
	@fecha = '2025-05-28',
	@precio = 5900000.00;

--L)
ALTER PROCEDURE SP_BuscarClientePorDNI
	@dni varchar(20)
AS
BEGIN 
	SET NOCOUNT ON;

	SELECT c.nombre,c.apellido,c.num_telefono,a.numero_area
	FROM Cliente c
	JOIN Cod_Area a ON c.AreaID = a.AreaID
	WHERE c.dni = @dni;
END;
GO

EXEC SP_BuscarClientePorDNI
	@dni = '30123456';

