# Prueba Tecnica Alcanos (Leidy Tatiana Sanchez)

## Requisitos 
 * Net core 3.1
 * Node v14.15.4
 * Npm 6.14.11
 * Angular CLI 11.0.7


## Pasos para Ejecutar el proyecto

Validar la cadena de conexion en el archivo appsettings.json
~~~
  "ConnectionStrings": {
    "AlcanosDb": "Server=localhost;Database=Seguridad;integrated security=true"
  }
~~~

### 1. Ejecutar Proyecto BackEnd
~~~
cd .\src\Alcanos.Api\
dotnet run .\Alcanos.Api.csproj
~~~

### 2. Ejecutar Proyecto FrontEnd
~~~
cd .\client\ 
ng serve 
~~~