# ApiCuentaAhorros

API REST desarrollada con ASP.NET Core para registrar simulaciones de cuentas de ahorro, almacenar los resultados y consultar proyecciones mensuales y anuales.

## Tecnologias

- C#
- .NET 10
- ASP.NET Core Web API basada en controladores
- Entity Framework Core 10.0.9
- SQLite
- OpenAPI
- Scalar
- Mapeadores manuales

## Caracteristicas

La aplicacion permite:

- Crear simulaciones de cuentas de ahorro.
- Consultar todas las simulaciones almacenadas.
- Consultar una simulacion por su identificador.
- Consultar la proyeccion mensual de una simulacion.
- Consultar la proyeccion anual de una simulacion.
- Almacenar los resultados en SQLite.

La tasa de interes anual se recibe en formato decimal:

- `0.05` representa 5 %.
- `0.08` representa 8 %.

Los calculos internos no se redondean durante cada operacion. Los valores monetarios se redondean a dos decimales al construir las respuestas.

## Base de datos

La aplicacion utiliza una base de datos SQLite llamada:

    cuenta-ahorros.db

La cadena de conexion se encuentra en `appsettings.json` con el nombre `ConexionSQLite`:

    Data Source=cuenta-ahorros.db

El archivo de base de datos se genera localmente y esta ignorado por Git.

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
- Migraciones.
- Integracion y pruebas finales.

### Derick

- Implementacion de `ServicioCalculos`.

### Darlan

- Implementacion de `ServicioSimulaciones`.
- Implementacion de `SimulacionesController`.

## Restaurar y compilar

Desde la carpeta raiz del proyecto:

    dotnet restore
    dotnet build

## Aplicar la migracion

La migracion inicial incluida en el proyecto se aplica con:

    dotnet ef database update

Para consultar las migraciones disponibles y aplicadas:

    dotnet ef migrations list

## Ejecutar la API

Desde la carpeta raiz:

    dotnet run

La configuracion local inicia la API en:

    http://localhost:5256

## Documentacion interactiva

En el ambiente de desarrollo, Scalar esta disponible en:

    http://localhost:5256/scalar/v1

El documento OpenAPI se encuentra en:

    http://localhost:5256/openapi/v1.json

## Endpoints

### Crear una simulacion

    POST /api/simulaciones

Ejemplo del cuerpo:

    {
      "depositoInicial": 10000,
      "tasaInteresAnual": 0.05,
      "plazoAnios": 2
    }

Respuesta correcta:

    201 Created

### Listar simulaciones

    GET /api/simulaciones

Respuesta correcta:

    200 OK

### Obtener una simulacion por ID

    GET /api/simulaciones/{id}

Respuestas posibles:

    200 OK
    404 Not Found

### Obtener la proyeccion mensual

    GET /api/simulaciones/{id}/proyeccion-mensual

Respuestas posibles:

    200 OK
    404 Not Found

### Obtener la proyeccion anual

    GET /api/simulaciones/{id}/proyeccion-anual

Respuestas posibles:

    200 OK
    404 Not Found

## Validaciones

Los siguientes valores deben ser mayores que cero:

- Deposito inicial.
- Tasa de interes anual.
- Plazo en anios.

Cuando los datos son invalidos, la API devuelve:

    400 Bad Request

## Pruebas realizadas

Durante la integracion final se comprobaron correctamente:

- Restauracion de dependencias.
- Compilacion del proyecto.
- Aplicacion de la migracion inicial.
- Creacion de `cuenta-ahorros.db`.
- Persistencia de simulaciones en SQLite.
- Codigo `200 OK`.
- Codigo `201 Created`.
- Codigo `400 Bad Request`.
- Codigo `404 Not Found`.
- Proyecciones mensuales.
- Proyecciones anuales.
