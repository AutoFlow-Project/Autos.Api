IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AutosDB')
BEGIN
    CREATE DATABASE AutosDB;
END
GO

USE AutosDB;
GO

IF OBJECT_ID('Autos', 'U') IS NOT NULL
    DROP TABLE Autos;
GO

CREATE TABLE Autos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    Anio SMALLINT NOT NULL,
    TipoDeAuto NVARCHAR(50) NOT NULL,
    CantidadDeAsientos TINYINT NOT NULL,
    Color NVARCHAR(30) NOT NULL,
    TieneAireAcondicionado BIT NOT NULL DEFAULT 0,
    TipoCombustible NVARCHAR(20) NOT NULL,

    CONSTRAINT CK_Autos_Anio 
        CHECK (Anio >= 1885 AND Anio <= YEAR(GETDATE()) + 1),

    CONSTRAINT CK_Autos_Asientos 
        CHECK (CantidadDeAsientos BETWEEN 1 AND 8),

    CONSTRAINT CK_Autos_TipoCombustible 
        CHECK (TipoCombustible IN (N'Gasolina', N'Diésel', N'GNV', N'GLP', N'Eléctrico', N'Híbrido'))
);
GO

INSERT INTO Autos (Marca, Modelo, Anio, TipoDeAuto, CantidadDeAsientos, Color, TieneAireAcondicionado, TipoCombustible)
VALUES 
    ('Toyota', 'Yaris', 2023, 'Sedán', 5, 'Plata', 1, 'Gasolina'),
    ('Kia', 'Picanto', 2022, 'Hatchback', 5, 'Rojo', 1, 'Gasolina'),
    ('Hyundai', 'Creta', 2024, 'SUV', 5, 'Blanco', 1, 'Gasolina'),
    ('Toyota', 'Hilux', 2023, 'Camioneta Pickup', 5, 'Negro', 1, 'Diésel');
GO