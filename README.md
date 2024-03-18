# 240316_DiegoDelgado

El proyecto que reposa en este repositorio maneja una arquitectura MVC, el cual esta desarrollado en ASP.Net Core y el frontend (vistas) esta desarrollado con Angular/CLI y Material

Este proyecto cuenta con varias carpetas (capas) las cuales se definende la siguiente manera:


# Nota: Solo la carpeta PhotoExpress.Views hace parte del FrontEnd, las demas son para BackEnd, por lo que se debe tener en cuenta a la hora de ejecutar las aplicaciones.


## BackEnd
1. PhotoExpress.API: 
    Esta capa contiene los controladores que manejan las operaciones solicitadas al backend a través de consultas API REST.

2. PhotoExpress.BLL
    Capa de lógica de negocio que contiene la implementación de reglas de negocio y operaciones de procesamiento de datos.  

3. PhotoExpress.DAL
    Capa de acceso a datos que gestiona las operaciones de acceso y manipulación de datos en la base de datos.

4. PhotoExpress.DTO
    Define los objetos de transferencia de datos (DTO) que se utilizan para intercambiar información entre las diferentes capas del sistema.

5. PhotoExpress.IOC
    Gestiona la inyección de dependencias en la aplicación, facilitando la configuración y la resolución de dependencias.

6. PhotoExpress.Model
    Define los modelos de datos utilizados en la aplicación, generados con EntityFramework y conectados a la base de datos para garantizar que se obtengan todas las refencias a sus tablas.

7. PhotoExpress.Utility
    Esta capa se encarga del mapeo de objetos entre las diferentes capas del proyecto. Implementa funciones y clases para facilitar la conversión de objetos DTO a entidades de base de datos y viceversa, así como cualquier otro tipo de mapeo necesario en la aplicación.

8. ### Scripts
    Esta carpeta si bien no es necesaria para la compilación, en ella se aloja el SCRIPT de SQL para generar las bases de datos.




## FrontEnd

1. PhotoExpress.Views
    Esta carpeta contiene las vistas del frontend desarrolladas con Angular/CLI y Material Design. Es la interfaz de usuario que interactúa con los usuarios finales.



# Ejecución del Proyecto

#### Para ejecutar la aplicación, sigue estos pasos:

1. Backend:

- Abre la solución en Visual Studio.
- Configura la cadena de conexión a la base de datos (sqlString) en appsettings.json dentro del proyecto PhotoExpress.API.
- Compila y ejecuta el proyecto PhotoExpress.API.

2. Frontend:

- Abre una terminal en la carpeta PhotoExpress.Views.
- Ejecuta npm install para instalar las dependencias.
- Ejecuta ng serve para iniciar el servidor de desarrollo de Angular.

## Abre tu navegador web y visita http://localhost:4200 para ver la aplicación en funcionamiento.

