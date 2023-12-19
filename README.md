# Tour booking

## Requisitos

Para ejecutar la aplicación es necesario tener las siguientes herramientas instaladas.

- Instancia de SQL Server 2019 (15.X) o superior.
- Microsoft SQL Server Management Studio u otro cliente compatible.
- Visual Studio
- .Net 6.0 o superior
- npm

## Configurar y ejecutar la aplicación

1. Clonar o descargar el repositorio.
2. Comprobar que el windows service de su instancia de SQL Server 2019 se esté ejecutando.
3. Configurar API
    - Abrir el archivo `.\api\TourBooking.sln` de proyecto de la API con Visual Studio.
    - Abrir el archivo `appsettings.json` en el proyecto web TourBooking y configurar la variable `TourBookingContext` con el conectionsString de la instancia de SQL Server que tenga instalada.
    - Asegurarse que el proyecto TourBooking sea el `Startup project` y que se ejecute con IIS Express.
    - Ir al menú superior de Visual Studio, `View > Terminal > New Terminal` y ejecutar el siguiente comando: 
    ```
    dotnet tool install --tool-path ./tools dotnet-ef --version 7.0.14
    ```
    - Ejecutar las migrations de la base de datos
    ```
    ./tools/dotnet-ef database update --startup-project .\TourBooking\ --project .\Infraestructure\
    ```
    - Ejecutar la solución en Visual Studio.
4. Configurar WebApp
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
5. Usar la aplicación web.
