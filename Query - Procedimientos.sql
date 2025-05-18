create database Ventas
go 
use Ventas
go

 CREATE TABLE Cliente (
    idCliente INT PRIMARY KEY,
    rucCliente NVARCHAR(20) NOT NULL,
    razonSocial NVARCHAR(150) NOT NULL,
    dirCliente NVARCHAR(200),
    idCiudad INT NOT NULL,
    idTipoCliente INT NOT NULL,
    idEstCliente INT NOT NULL,
    fecCreacion datetime
);


Create or ALTER PROCEDURE [dbo].[spListarCliente]
As
Select idCliente, rucCliente, razonSocial, dirCliente, idCiudad, idTipoCliente,idEstCliente
from Cliente
where idEstCliente != 0



CREATE OR ALTER PROCEDURE [dbo].[spInsertarCliente]
    @rucCliente CHAR(11),
    @razonSocial VARCHAR(50),
    @dirCliente VARCHAR(50),
    @idCiudad INT,
    @idTipoCliente INT,
    @idEstCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Cliente (rucCliente, razonSocial, dirCliente, idCiudad, idTipoCliente, idEstCliente, fecCreacion)
    VALUES (@rucCliente, @razonSocial, @dirCliente, @idCiudad, @idTipoCliente, @idEstCliente, GETDATE());
    
    -- Devolvemos el número de filas afectadas
    SELECT @@ROWCOUNT AS FilasAfectadas;
END


CREATE OR ALTER PROCEDURE [dbo].[spBuscarClientePorId]
@idCliente INT
AS
BEGIN
    SELECT 
        idCliente, rucCliente, razonSocial, dirCliente, idCiudad, 
        idTipoCliente, idEstCliente, fecCreacion
    FROM Cliente
    WHERE idCliente = @idCliente;
END;
GO


CREATE OR ALTER PROCEDURE [dbo].[spEditarCliente]
    @idCliente INT,
    @rucCliente NVARCHAR(20),
    @razonSocial NVARCHAR(150),
    @dirCliente NVARCHAR(200),
    @idCiudad INT,
    @idTipoCliente INT,
    @idEstCliente INT
AS
BEGIN
    UPDATE Cliente
    SET 
        rucCliente = @rucCliente,
        razonSocial = @razonSocial,
        dirCliente = @dirCliente,
        idCiudad = @idCiudad,
        idTipoCliente = @idTipoCliente,
        idEstCliente = @idEstCliente
    WHERE idCliente = @idCliente;
END;
GO

create or alter procedure [dbo].[spInhabilitarCliente]
@idCliente int
as
begin 
	update Cliente
	set idEstCliente = 0
	where idCliente = @idCliente
end













--Eliminar elementos de la tabla
delete from Cliente

INSERT INTO Cliente (rucCliente, razonSocial, dirCliente, idCiudad, idTipoCliente, idEstCliente, fecCreacion)
VALUES 
('20123456789', 'Empresa Alpha S.A.', 'Av. Principal 123', 1, 1, 1, GETDATE()),
('20198765432', 'Comercial Beta S.R.L.', 'Calle Secundaria 456', 2, 1, 1, GETDATE()),
('20234567890', 'Inversiones Gamma E.I.R.L.', 'Av. Industrial 789', 1, 2, 1, GETDATE()),
('20345678901', 'Servicios Delta S.A.C.', 'Jr. Los Olivos 321', 3, 1, 1, GETDATE()),
('20456789012', 'Distribuidora Epsilon S.A.', 'Calle Comercio 654', 2, 2, 1, GETDATE());
