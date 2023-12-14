# Tour booking

## Requisitos

Para ejecutar la aplicación es necesario tener las siguientes herramientas instaladas.

- SQL Server 2019 (15.X) o superior.
- Microsoft SQL Server Management Studio u otro cliente compatible.
- Visual Studio
- .Net 6.0 o superior
- npm

## Configurar y ejecutar la aplicación

1. Clonar o descargar el repositorio.
2. Crear base de datos
    - Abrir Microsoft SQL Server Management Studio y conectarse a su instancia de SQL Server.
    - Ejecutar los scripts de la carpeta `.\db` en el orden del prefijo númerico en el nombre de cada archivo. Esto creará la base de datos 'TourBooking' y sus tablas.
4. Configurar API
    - Abrir el archivo `.\api\TourBooking.sln` de proyecto de la API con Visual Studio.
    - Abrir el archivo `appsettings.json` en el proyecto web TourBooking y configurar la variable `TourBookingContext` para conectarse a la instancia de SQL Server donde está instalada la base de datos 'TourBooking'.
    - Asegurarse que el proyecto TourBooking sea el `Startup project` y que se ejecute con IIS Express.
    - Ejecutar la solución en Visual Studio.
5. Configurar WebApp
    - Abrir el archivo `.\webapp\src\config.json` y configurar la variable `API_URL` con la url de la API de .Net. Se obtiene de la ventana abierta por Visual Studio al ejecutar la API.
    - Abrir una terminal de cmd o powershell y dirigirse al directorio `webapp`
    ```
    cd [ruta-completa]\webapp
    ```
    - Instalar las dependencias.
    ```
    npm install
    ```
    - Iniciar la aplicación web.
    ```
    npm start
    ```
6. Usar la aplicación web.
