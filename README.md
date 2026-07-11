# ApiCuentaAhorros

API REST desarrollada con ASP.NET Core para registrar simulaciones de cuentas de ahorro y consultar sus resultados y proyecciones.

## Tecnologias

- C#
- .NET 10
- ASP.NET Core Web API basada en controladores
- Entity Framework Core 10.0.9
- SQLite
- OpenAPI
- Mapeadores manuales

## Caracteristicas

La aplicacion permitira:

- Crear simulaciones de cuentas de ahorro.
- Consultar todas las simulaciones almacenadas.
- Consultar una simulacion por su identificador.
- Consultar la proyeccion mensual de una simulacion.
- Consultar la proyeccion anual de una simulacion.
- Almacenar los resultados en SQLite.

La tasa de interes anual se recibe en formato decimal:

- `0.05` representa 5 %.
- `0.08` representa 8 %.

Los calculos internos no deben redondearse. Los valores monetarios se redondean a dos decimales solamente al construir las respuestas.

## Base de datos

La aplicacion utiliza una base de datos SQLite llamada `cuenta-ahorros.db`.

La cadena de conexion se encuentra en `appsettings.json` con el nombre `ConexionSQLite`:

    Data Source=cuenta-ahorros.db

## Estructura principal

    Controladores/
    BaseDatos/
    Dtos/Simulaciones/
    Entidades/
    Mapeadores/
    Servicios/Calculos/
    Servicios/Simulaciones/
    Extensiones/
    Migraciones/
    ApiCuentaAhorrosBruno/

## Responsabilidades del equipo

### Stanly

- Entidad de simulacion.
- DTO.
- Contexto de Entity Framework Core.
- Mapeadores manuales.
- Interfaces de servicios.
- Configuracion de SQLite.
- Configuracion de dependencias.
- Integracion final.
- Migraciones y pruebas finales.

### Derick

- Implementacion de `ServicioCalculos`.

### Darlan

- Implementacion de `ServicioSimulaciones`.
- Implementacion de `SimulacionesController`.

## Restaurar y compilar

Desde la carpeta raiz del proyecto:

    dotnet restore
    dotnet build

## Ejecutar la API

Cuando todas las implementaciones del equipo hayan sido integradas:

    dotnet run

## Migraciones

La migracion inicial y la creacion de la base de datos se realizaran durante la fase final de integracion, despues de incorporar las implementaciones de todos los integrantes.

## Restricciones

El proyecto no utiliza:

- AutoMapper.
- Frontend.
- Autenticacion.
- JWT.
- Usuarios.
- Roles.
