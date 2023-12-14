# tour-booking

## Requisitos

Para ejecutar la aplicación es necesario tener las siguientes herramientas instaladas.

- SQL Server 2019 (15.X) o superior.
- Microsoft SQL Server Management Studio u otro cliente compatible.
- Visual Studio
- .Net 6.0 o superior
- npm

## Configurar y ejecutar la aplicación

1. Clonar el repositorio.
2. Abrir Microsoft SQL Server Management Studio y conectarse a su instancia de SQL Server.
    - Ejecutar los scripts de la carpeta `.\db` según el orden del prefijo númerico en el nombre de cada archivo. Esto creará la base de datos 'TourBooking' y sus tablas.
3. Abrir el archivo `.\api\TourBooking.sln` de proyecto de la API con Visual Studio.
    - Abrir el archivo `app.config` en el proyecto web TourBooking y configurar la variable `connectionString` para conectarse a la instancia de SQL Server donde está instalada la base de datos 'TourBooking'.
    - Asegurarse que el proyecto TourBooking sea el `Startup project` y que se ejecute con IIS Express.
    - Ejecutar la solución en Visual Studio.
4. Abrir el archivo `.\webapp\src\Utils\useAppParameters.js` y configurar el valor de la variable `apiBaseUrl` con la url de la API de .Net.
5. Abrir una terminal de cmd o powershell y dirigirse al directorio `.\webapp`
    - Ejecutar el comando `npm install` para instalar las dependencias.
    - Ejecutar el comando `npm start` para iniciar la aplicación web.
6. Usar la aplicación web en la ventana que se abrió en su navegador.
