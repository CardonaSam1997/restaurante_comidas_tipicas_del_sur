**RESTAURANTE COMIDAS TIPICAS DEL SUR**

## Proyecto .NET 8 - Arquitectura por Capas con Entity Framework

Este proyecto ha sido desarrollado en **.NET 8.0.15**,
utilizando una arquitectura en capas para 
separar las responsabilidades del sistema. 


# La base de datos ha sido desplegada en Somee
# El API ha sido desplegada en Railway


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
- **Program.cs**: Configuracion principal del proyecto.

********************************************************************************

# Despliegue de Base de Datos en Somee.com

Explicacion del paso a paso para subir una base de datos SQL Server
a la plataforma gratuita https://somee.com

-------------------------------------

## Requisitos Previos

- Tener una cuenta en https://somee.com
- Tener instalado SQL Server Management Studio.
- Tener tu script **.sql** de creación de base de datos o una base de datos local lista.

-------------------------------------

## Pasos para Desplegar la Base de Datos

## Crear Cuenta y Base de Datos

1. inicia sesion en https://somee.com
2. Dirígete a **Hosting gratuito** -> **Crear nuevo sitio**
3. Durante la creacion, activa la opción **Base de datos MS SQL gratuita**
4. Finaliza el proceso. Se generarán automáticamente:
   - Nombre del servidor 
   - Nombre de la base de datos 
   - Usuario 
   - Contraseña 
5. Ir a la pestaña **Base de datos** y copia estos datos

-------------------------------------

## Conectar a Somee desde SQL Server Management Studio

1. Abre SSMS
2. En el campo **Server name**, escribe:
    - nombre_servidor.somee.com
    - Selecciona **SQL Server Authentication**
    - Ingresa el **usuario** y **contraseña** provistos por Somee
    - Conectate

********************************************************************************

## Despliegue del Proyecto en Railway desde GitHub
Este proyecto fue desplegado en Railway conectando directamente 
el repositorio de GitHub. Railway permite hacer despliegues rápidos,
sin configurar infraestructura manualmente.

-------------------------------------

## Requisitos Previos

- Cuenta en https://railway.com/
- Repositorio del proyecto en GitHub
- Archivo docker configurado

-------------------------------------

## Pasos para el Despliegue

- 1. Subir el Proyecto a GitHub

- 2. Crear Proyecto en Railway

    - 1. Ingresa a https://https://railway.com/
    - 2. Haz clic en **"New Project"**.
    - 3. Selecciona **"Deploy from GitHub repo"**.
    - 4. Autoriza acceso a tu cuenta de GitHub.
    - 5. Elige el repositorio que contiene tu proyecto.
    - 6. Railway detectará automáticamente el tipo de proyecto y comenzará el despliegue.

-------------------------------------

## Acceso Público

1. Después del despliegue, damos clic en Settings
2. En la sección **"Networking"**, pulsa **"Generate Domain"**
4. Railway te asignará un dominio público, como: restaurantecomidastipicasdelsur-production.up.railway.app

**********************************************************************
## Endpoints de la API
  Url:`https://restaurantecomidastipicasdelsur-production.up.railway.app`
  Puerto: 8080

Ejemplo de la ruta completa: https://restaurantecomidastipicasdelsur-production.up.railway.app/api/Consultas/ventas-meseros

### Consultas
- `GET /api/Consultas/ventas-meseros` : Total vendido por cada mesero(con nombre y apellido)
- `GET /api/Consultas/clientes-por-consumo?valor=?` : clientes con consumo mayor o igual al vlaor digitado
- `GET /api/Consultas/plato-mas-vendido?anio=2025&mes=05` → Plato mas vendido, cantidad, monto total segun el mes

### Factura
- `POST /api/Factura/crear` → Crear la factura

**JSON para la creacion de factura**:
{
  "cliente": {
    "identificacion": 789654123,
    "nombres": "Andrea",
    "apellidos": "Gómez",
    "direccion": "Carrera 10 #45-67, Medellín",
    "telefono": "3012345678"
  },
  "mesero": {
    "idMesero": 15,
    "nombres": "Julián Torres"
  },
  "mesa": {
    "nroMesa": 8,
    "nombre": "Salón Principal"
  },
  "platos": [
    {      
      "plato": "Pasta Alfredo con camarones",
      "valor": 32000
    },
    {      
      "plato": "Limonada de coco",
      "valor": 9000
    }
  ]
}


