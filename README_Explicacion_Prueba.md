
# Explicación de la implementación y diferencias con la plantilla GTMotive

Durante el desarrollo del microservicio `AlquilerMicroservicio`, se ha seguido una arquitectura alineada con los principios de la plantilla GTMotive, aplicando **DDD, arquitectura hexagonal, separación de capas, pruebas automatizadas y patrones modernos**.  
No obstante, se han realizado algunos ajustes con el objetivo de **mantener simplicidad y claridad** en una prueba técnica con alcance concreto.

---

## ✅ Qué se ha implementado y cómo se alinea con la plantilla:

- **Separación por capas** (`Domain`, `Application`, `Infrastructure`, `API`) siguiendo el patrón de la plantilla.
- **Uso de `MediatR`** para aplicar el patrón Mediator (commands, queries, events).
- **Dominio rico** con entidades (`Vehicle`, `Rental`), lógica encapsulada y validaciones internas.
- **Servicios de dominio** (`RentalDomainService`) para mantener las reglas de negocio fuera de los handlers.
- **Eventos de dominio** y su handler correspondiente.
- **Dispatcher de eventos** desacoplado, usando `IMediator`.
- **Inyección de dependencias** en todos los niveles.
- **Pruebas automáticas** de los 3 tipos requeridos (unitaria, funcional e infraestructura).
- **Swagger activo y probado** para verificar los endpoints.

---

## 🛠️ Diferencias con la plantilla GTMotive (y su justificación):

| Plantilla GTMotive                        | Nuestra implementación                   | Justificación                                                                 |
|------------------------------------------|------------------------------------------|-------------------------------------------------------------------------------|
| Proyecto `.Host` separado                 | El proyecto `API` actúa como host         | No se requieren múltiples entrypoints; `API` cumple el rol de `Host`         |
| Nombre extendido por convención (`GtMotive.Estimate.*`) | Nombre funcional y directo (`AlquilerMicroservicio`) | Se adapta a la prueba entregada y contexto más simple                         |
| Infraestructura adicional (`Directory.Build.props`, `global.json`, etc.) | No incluido                               | No afecta al cumplimiento funcional ni a la arquitectura                      |
| Plantilla preparada para múltiples microservicios | Implementación centrada en un único microservicio | Por simplicidad y foco en el dominio de alquiler                             |

---

## 🧩 Compatibilidad

La solución desarrollada **puede adaptarse fácilmente a la plantilla GTMotive** si fuera necesario:
- El código está estructurado por capas y se puede reubicar dentro de `src/` y `test/`.
- Las dependencias son estándar y gestionadas por `NuGet`.
- Los proyectos pueden integrarse en una solución mayor sin cambios estructurales.

---

## ✅ Conclusión

Se ha priorizado la claridad, la separación de responsabilidades y el cumplimiento exhaustivo de los **requisitos funcionales y técnicos** de la prueba.

La arquitectura, los patrones y las prácticas seguidas están **alineados con los principios de la plantilla GTMotive**, con una implementación adaptada al tamaño y objetivos del ejercicio técnico.
