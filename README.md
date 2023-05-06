# SelfManagement (AutoGestión)

## Descripción

**SelftManagement** es un proyecto nacido de la necesidad de tener un portal alternativo de AutoGestión al que en su momento supo tener SharePoint 2013. La idea es pasar y mejorar la funcionalidad existente manteniendo un frontend simple y System Center Orchestrator como orquestador de los workflows, manejo de estados y notificaciones de errores o resultados.

## Arquitectura

Basado en DDD la estructura de la solución es:
- ProvinciaNET.SelfManagement.Core (Dominio)
- ProvinciaNET.SelfManagement.Infraestructure (Aplicación)
- ProvinciaNET.SelfManagement.WebApi (Servicios)
- ProvinciaNET.SelfManagement.WebApp (Frontend)

Adicionalmente encontramos los proyectos de test unitario y funcional:
- ProvinciaNET.SelfManagement.WebApi.UnitTests
- ProvinciaNET.SelfManagement.WebApp.FunctionalTests

## Frameworks y Librerías

- NET 7
- Entity Framework Core
- AspNetCore
- AspNetCore OpenApi
- AspNetCore OData
- Swashbuckle (Swagger)
- NLog
- Radzen Blazor
- DocumentFormat OpenXml
- xUnit
- Playwright (NUnit)