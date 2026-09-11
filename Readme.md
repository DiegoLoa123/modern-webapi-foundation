# ProyPruebasApi

API REST de práctica desarrollada con **ASP.NET Core y .NET 10**, orientada al aprendizaje progresivo de backend con buenas prácticas.

El proyecto utiliza **Minimal APIs**, inyección de dependencias, contratos tipados, servicios desacoplados y actualmente incorpora un **CRUD REST de productos almacenado temporalmente en memoria**.

> Este repositorio documenta una ruta progresiva de aprendizaje: fundamentos → HTTP/REST → LINQ → persistencia → testing → arquitectura → microservicios.

## 🚀 Funcionalidades

- Endpoint `Hola Mundo` con timestamp UTC.
- Pronóstico meteorológico generado en memoria.
- CRUD REST de productos.
- Consulta de productos activos.
- Validaciones básicas en creación y actualización.
- Route constraints para IDs numéricos.
- Códigos HTTP `200`, `201`, `204`, `400` y `404`.
- Agrupación de rutas de productos mediante `MapGroup`.
- DTOs separados para requests y responses.
- Inyección de dependencias mediante interfaces.
- OpenAPI disponible en desarrollo.

## 🛠️ Tecnologías

- .NET 10
- ASP.NET Core
- Minimal APIs
- LINQ
- Dependency Injection
- OpenAPI
- Docker

## 📁 Estructura

```text
src/
├── Api/
│   └── Endpoints/             # Rutas HTTP
├── Application/
│   ├── Contracts/             # DTOs de entrada y salida
│   └── Interfaces/            # Contratos de servicios
├── Domain/
│   └── Entities/              # Entidades del dominio
└── Infrastructure/
    └── Services/              # Implementaciones y lógica

Program.cs                     # Configuración, DI y arranque
```

## 📦 API de productos

Las rutas se agrupan bajo `/api/products`.

| Método | Endpoint | Descripción | Respuestas |
|---|---|---|---|
| `GET` | `/api/products/` | Lista todos los productos | `200` |
| `GET` | `/api/products/active` | Lista productos activos | `200` |
| `GET` | `/api/products/{id}` | Busca un producto por ID | `200`, `404` |
| `POST` | `/api/products/` | Crea un producto | `201`, `400` |
| `PUT` | `/api/products/{id}` | Actualiza un producto | `200`, `400`, `404` |
| `DELETE` | `/api/products/{id}` | Elimina un producto | `204`, `404` |

### Crear producto

```http
POST /api/products/
Content-Type: application/json
```

```json
{
  "name": "Webcam",
  "price": 180,
  "active": true
}
```

El ID es generado por la aplicación. Actualmente se valida que el nombre sea obligatorio, tenga al menos 3 caracteres y que el precio sea mayor que cero.

### Actualizar producto

```http
PUT /api/products/6
Content-Type: application/json
```

```json
{
  "name": "Webcam Logitech",
  "price": 250,
  "active": true
}
```

### Eliminar producto

```http
DELETE /api/products/6
```

Una eliminación correcta responde con `204 No Content`.

## 🌐 Otros endpoints

### Hola Mundo

```http
GET /api/hello
```

```json
{
  "message": "¡Hola Mundo!",
  "timestamp": "2026-01-01T12:00:00+00:00"
}
```

### Pronóstico meteorológico

```http
GET /api/weatherforecast
```

Devuelve registros meteorológicos generados en memoria.

## 💾 Persistencia actual

El CRUD todavía **no utiliza una base de datos**. Los productos se mantienen en una colección en memoria mientras la aplicación está ejecutándose.

Por ello, los cambios realizados mediante `POST`, `PUT` o `DELETE` **se pierden cuando la API se reinicia**. Esta decisión es intencional para practicar primero HTTP/REST, CRUD, LINQ, DTOs e inyección de dependencias antes de incorporar persistencia real.

## 📖 OpenAPI

En desarrollo, el documento OpenAPI está disponible en:

```text
/openapi/v1.json
```

Los endpoints incluyen metadatos mediante `WithName`, `WithSummary` y `Produces`.

## ▶️ Ejecutar localmente

**Requisitos:** .NET SDK 10.0 o superior. Docker es opcional.

```bash
dotnet restore
dotnet run
```

ASP.NET Core mostrará en consola la URL asignada al iniciar la aplicación.

## 🐳 Docker

```bash
docker build -t dotnet-pruebas-api .
docker run --rm -p 8080:8080 --name mi_api_tmp dotnet-pruebas-api
```

Ejemplo:

```text
http://localhost:8080/api/hello
```

## 🧩 Decisiones de diseño

**Minimal APIs:** las rutas están separadas de `Program.cs` mediante clases de endpoints.

**Dependency Injection:** los endpoints dependen de abstracciones como `IProductService` en lugar de crear directamente los servicios.

```text
HTTP Request
     ↓
ProductEndpoints
     ↓
IProductService
     ↓
ProductService
     ↓
Product
```

**DTOs:** creación, actualización y respuesta utilizan contratos separados, evitando utilizar directamente la entidad `Product` como contrato HTTP.

**MapGroup:** las operaciones de productos comparten el prefijo `/api/products`.

**Almacenamiento en memoria:** en esta etapa se utiliza almacenamiento temporal para concentrar el aprendizaje en los fundamentos de una API REST.

## 🗺️ Roadmap

- [x] Fundamentos de C# / ASP.NET Core
- [x] Minimal APIs
- [x] Dependency Injection
- [x] HTTP / REST
- [x] CRUD Product
- [x] DTOs de request/response
- [x] Validaciones básicas
- [x] LINQ básico
- [ ] Query Parameters y filtros con LINQ
- [ ] Async / Await
- [ ] Manejo global de excepciones
- [ ] Repository Pattern
- [ ] Entity Framework Core
- [ ] Base de datos SQL
- [ ] OpenAPI avanzado
- [ ] JWT
- [ ] Logging
- [ ] Unit Testing
- [ ] Docker + base de datos
- [ ] CI/CD
- [ ] Cloud deployment
- [ ] Patrones de diseño
- [ ] Idempotencia
- [ ] Mensajería / eventos
- [ ] Microservicios
- [ ] Saga Pattern

## 🎯 Objetivo

El objetivo del repositorio no es únicamente construir una API funcional, sino mostrar una **evolución progresiva del aprendizaje de .NET**, desde los fundamentos de ASP.NET Core hasta conceptos de arquitectura distribuida y microservicios.
