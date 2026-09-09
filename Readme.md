# ProyPruebasApi
API REST minimal desarrollada con ASP.NET Core y .NET 10. El proyecto expone un endpoint de ejemplo para clima y un endpoint de saludo, con una separación sencilla entre API, contratos, interfaces y servicios.

## ¿Qué hace?

- Expone un pronóstico meteorológico generado en memoria.
- Expone un endpoint `Hola Mundo` con la hora UTC de la respuesta.
- Publica el documento OpenAPI en desarrollo.
- Usa interfaces tipadas e inyección de dependencias para desacoplar endpoints y servicios.

## Requisitos
- .NET SDK 10.0 o superior.
- Docker (opcional).

## Ejecutar localmente
```bash
dotnet restore
dotnet run
```

La aplicación se inicia normalmente en `http://localhost:5229` (o en la URL que indique la consola).

## Endpoints
### Hola Mundo
```http
GET /api/hello
```

Respuesta de ejemplo:

```json
{
  "message": "¡Hola Mundo!",
  "timestamp": "2026-01-01T12:00:00+00:00"
}
```

### Pronóstico
```http
GET /api/weatherforecast
```

Devuelve cinco registros de clima generados aleatoriamente.

En entorno de desarrollo, el documento OpenAPI está disponible en:

```text
/openapi/v1.json
```

## Estructura
```text
Api/Endpoints/                 Definición de rutas HTTP
Application/Contracts/         Modelos de respuesta públicos
Application/Interfaces/        Contratos tipados de los servicios
Infrastructure/Services/       Implementaciones de la lógica de aplicación
Models/                        Modelos de dominio existentes
Program.cs                     Composición de dependencias y arranque
```

## Docker
Construir la imagen:

```bash
docker build -t dotnet-pruebas-api .
```

Ejecutar el contenedor:

```bash
docker run --rm -p 8081:80 --name mi_api_tmp dotnet-pruebas-api
```

Después, consulta `http://localhost:8081/api/hello`.

## Decisiones de diseño
Los endpoints solo se encargan del transporte HTTP y dependen de interfaces (`IHelloWorldService` e `IWeatherForecastService`). Las implementaciones se registran en `Program.cs`, lo que facilita reemplazarlas por una base de datos o servicios externos y simplifica las pruebas futuras.
