# Documentación del Microservicio de Alquiler de Vehículos

Este documento recoge toda la información técnica del microservicio **AlquilerMicroservicio**, incluyendo arquitectura, diseño, entidades, servicios y componentes de infraestructura. La documentación está pensada para desarrolladores que quieran entender el flujo del sistema o continuar el desarrollo.

---

## Arquitectura

El proyecto está basado en los siguientes principios:

- Arquitectura Hexagonal
- DDD (Domain-Driven Design)
- MediatR para patrones CQRS y publicación de eventos
- MongoDB como sistema de persistencia
- Clean Code y buenas prácticas de diseño SOLID

---

## Estructura del Proyecto

```plaintext
AlquilerMicroservicio/
├── src/API/                   --> Entrada HTTP, controladores
├── src/Application/           --> Comandos, queries, handlers
├── src/Domain/                --> Entidades, interfaces, eventos
├── src/Infrastructure/        --> Repositorios, conexión Mongo, eventos
├── tests/                 --> Pruebas unitarias y funcionales
└── docs/                  --> Documentación generada (DocFX)
```

---

## Componentes Clave

### API

Controladores REST que reciben las peticiones y lanzan comandos o consultas.

### Application

Contiene la lógica de aplicación, con comandos, queries y sus respectivos handlers.

### Domain

Modelos del dominio (vehículos, alquileres), reglas de negocio y eventos de dominio.

### Infrastructure

Implementación de los repositorios usando MongoDB, conexión con la base de datos y publicación de eventos con MediatR.

---

## Repositorios

- `IVehicleRepository` y `IRentalRepository` definen las operaciones de persistencia.
- `MongoVehicleRepository` y `MongoRentalRepository` implementan la lógica real sobre MongoDB.

---

## Pruebas

La solución incluye pruebas por capas:

- **Unitarias**: enfocadas en la lógica de dominio y handlers.
- **Funcionales**: validan escenarios completos de negocio.
- **Infraestructura**: comprueban integración real con MongoDB.

---

## Configuración

Ejemplo de configuración mínima en `appsettings.json`:

```json
{
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "Database": "AlquilerDb"
  }
}
```

---

## Generación de Documentación

Esta documentación se genera automáticamente con [DocFX]. Para generarla localmente:

```bash
docfx docfx.json --serve
```

Para generar un PDF:

```bash
docfx docfx.json --pdf
```

---

