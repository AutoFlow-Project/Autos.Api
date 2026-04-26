# Autos.Api — Backend API REST (.NET 10)

API REST desarrollada en .NET 10 para la gestión de vehículos (CRUD completo).

Este proyecto implementa una arquitectura limpia con separación de responsabilidades, validaciones en múltiples capas y script SQL de creación de base de datos incluido.

---

## Tecnologías Utilizadas

- .NET 10 (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- DTOs + Validaciones

---

## Requisitos Previos

- .NET 10 SDK
- SQL Server (LocalDB, Express o cualquier edición)
- Visual Studio 2026
- Postman (para pruebas)

---

# Base de Datos

El proyecto incluye el script completo de creación de base de datos en:
Database/AutosDB.sql


## Qué hace el script:

- Crea la base de datos `AutosDB` si no existe.
- Crea la tabla `Autos`.
- Define constraints:
  - Año >= 1885 y <= Año actual + 1
  - Cantidad de asientos entre 1 y 8
  - Tipo de combustible restringido
- Inserta datos iniciales.

---

## Cómo crear la Base de Datos

1. Abrir SQL Server Management Studio (SSMS).
2. Abrir el archivo: Database/AutosDB.sql
3. Ejecutar el script completo.
4. Verificar que la base `AutosDB` y la tabla `Autos` fueron creadas.

---

# Configuración de la API

## Cadena de Conexión

Verificar el archivo: appsettings.Development.json

Ejemplo de configuración:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AutosDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
