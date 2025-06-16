# AlquilerMicroservicio

Este microservicio ha sido desarrollado siguiendo una arquitectura alineada con los principios de la plantilla GTMotive, aplicando DDD, arquitectura hexagonal, separación de capas, pruebas automatizadas y patrones modernos.

> Algunas simplificaciones se han hecho con el objetivo de mantener claridad en el contexto de una prueba técnica de alcance concreto.

---

## Estructura del proyecto

El proyecto está organizado en capas:

- `Domain`: Entidades, lógica de negocio y servicios de dominio.
- `Application`: Commands, queries, eventos y lógica de aplicación usando MediatR.
- `Infrastructure`: Acceso a datos, repositorios con MongoDB, configuración.
- `API`: Exposición HTTP y configuración de Swagger.
- `tests/`: Pruebas unitarias, funcionales y de infraestructura.

---

## Funcionalidades implementadas

- Arquitectura por capas totalmente alineada con la plantilla GTMotive.
- Uso de **MediatR** para aplicar el patrón Mediator (commands, queries, events).
- **Dominio rico** con validaciones encapsuladas y servicios de dominio (`RentalDomainService`).
- Desacoplamiento con eventos de dominio manejados por `IMediator`.
- **Inyección de dependencias** en todos los niveles con `IServiceCollection`.
- **Repositorios sobre MongoDB** en la capa `Infrastructure`.
- Configuración por `appsettings.json` y variables de entorno (para puertos y Mongo).
- **Swagger habilitado sin restricciones**, probado localmente y vía Docker.
- Preparado para contenedores Docker:
  - `Dockerfile`
  - `docker-compose.yml`
  - `.dockerignore`
- Variables como `ASPNETCORE_URLS=http://+:80` incluidas para compatibilidad en contenedor.
- **Documentación generada con DocFX** desde la carpeta `docs`.

---

## Pruebas

Incluye tres tipos de pruebas automatizadas:

- **Unitarias**
- **Funcionales**
- **Infraestructura**

Ubicadas dentro del directorio `tests/`.

---

## Compatibilidad

- El código es fácilmente adaptable a la plantilla GTMotive real.
- Estructura ya compatible con `src/` y `test/`.
- Sin dependencias externas ni acoplamientos innecesarios.
- Cumple principios de **Clean Code** y **SOLID**.
- Totalmente portable e integrable en soluciones mayores.

---

## Configuración Docker

En la raíz del proyecto encontrarás:

- `Dockerfile`
- `docker-compose.yml`
- `.dockerignore`

Listo para ejecución en contenedores junto con MongoDB.

---

## Conclusión

Se ha priorizado:

- Claridad y mantenibilidad.
- Separación de responsabilidades.
- Cumplimiento de requisitos funcionales y técnicos.

La solución está pensada para reflejar buenas prácticas, pero sin sobreingeniería, enfocándose en cumplir correctamente con los objetivos de la prueba técnica.

---

**Autor:** Ramón Vázquez Piñeiro
