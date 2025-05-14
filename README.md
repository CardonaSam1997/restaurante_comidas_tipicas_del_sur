**RESTAURANTE COMIDAS TIPICAS DEL SUR**


## Proyecto .NET 8 - Arquitectura por Capas con Entity Framework

Este proyecto ha sido desarrollado en **.NET 8.0.15**,
utilizando una arquitectura en capas para 
separar las responsabilidades del sistema. 

Se utiliza **Entity Framework Core** como ORM 
y **SQL Server 2019** como base de datos relacional. 
Las funcionalidades se exponen a traves de **Web APIs** 
y se pueden probar facilmente mediante **Swagger UI**.

-------------------------------------

## Tecnologias

- **Visual Studio Community 2022**: IDE de .Net para elaboracion del codigo.

- **.NET 8.0.15**: Framework principal para el desarrollo del proyecto.

- **SQL Server 2022 Express**: Motor de base de datos relacional utilizado como backend de datos.

- **NuGet**: Gestor de paquetes utilizado para instalar las dependencias del proyecto.

- **Swagger**: Herramienta para probar los endpoints de la API desde un navegador web.

- **Git/GitHub**: Gestor de versiones.

---------------------------------------

##  Librerias utilizados:

- **Microsoft.EntityFrameworkCore.Design**: 
- **Microsoft.EntityFrameworkCore.SqlServer**: Permite la conexion con la BD SQL Server
- **Microsoft.EntityFrameworkCore.Tools**: Me permite la ejecucion de algunos comandos dotnet (que me permiten interactuar con la BD)
- **Swashbuckle.AspNetCore**: Permite que swagger funcione, mostrando los endpoint

-------------------------------------

## Estructura del Proyecto

El proyecto esta organizado en una arquitectura por capas:

- **Entidades**: Clases que representan las tablas de la base de datos.
- **Repositorios**: Interactua con la base de datos por medio de las entidades.
- **Servicios**: Logica para verificar y manipular los datos.
- **Controladores**: Maneja las solicitudes HTTP y las respuestas.
- **Program.cs/Startup.cs**: Configuracion principal del proyecto y servicios.

-------------------------------------

## Como Desplegar el Proyecto

1. Requisitos Previos
- **.NET SDK 8.0.15**: https://dotnet.microsoft.com/en-us/download
- **SQL Server 2022**: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- **Visual Studio 2022**: https://visualstudio.microsoft.com/
- **NuGet**: Integrado en Visual Studio

### 2. **Clonar el repositorio**
```bash
git clone https://tu-repo-url.git
cd nombre-del-proyecto