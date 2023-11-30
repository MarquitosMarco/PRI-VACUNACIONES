# PRI-Vacunaciones(parte Web)
# Manual Técnico
## 1. Introducción:
Pri-Vacunaciones es un proyecto de registro y manipulación de datos de un sistema de vacunación completo, con creación de campañas, 
registro de usuarios(Médicos), creación de brigadas, mapa de la ubicación de la campaña, generación de reportes, todos con sus respectivos CRUDS,
todos los datos serán guardados en una base de datos, esta base de datos será utilizada por el sistema de creación de vacunas que tomaran todos estos 
datos y los podrá utilizar para registrar las vacunas (Este sistema lo generara una compañera de proyecto de sistemas).
El cliente podrá utilizar el proyecto sin complicaciones, porque el sistema es muy simple de utilizar, con un buen diseño que te guiara como registrar 
todos los datos, en este manual se podrán seguir los pasos para su uso y la instalacion

## 2. Descripción del proyecto:
El proyecto pri-vacunaciones web, en un sistema hecho para 2 tipos de usuarios que usen el sistema uno es el SuperAdmininistrador y el otro es el Admin,
cada uno puede utilizar el proyecto de manera separada, el usuario se encuentra al principio del proyecto con un login que dependiendo su rol (Admin o superAdmin),
pueden entrar a 2 sistemas web diferentes, la contraseña para ambos es QXUG6cV1.

El primero seria el apartado del superAdmin que tiene las funciones de crear usuario, también tiene editar usuario y eliminar usuario, en este caso el superAdmin 
estaría creando al usuario Medico, el medico es un usuario que es registrado por el superAdmin y Admin en web, estos datos de creación son guardados en una base de datos,
esta base de datos luego se utiliza para el login del medico en la parte móvil del proyecto que lo realiza una compañera de proyecto de sistemas, esta compañera crea la parte 
funcional de lo que un medico tiene que hacer al entrar el sistema.

El superAdmin también tiene para crear campañas de mascota que serian como el lugar y la fecha donde serian vacunadas las mascotas, esta creación de campañas también tiene su propio CRUD.

El superAdmin también tiene generador de reportes, obtiene información de las brigadas automáticamente

En la parte del Admin tiene creación de brigadas, que son los grupos de trabajo que se encargan de vacunar a las mascotas, también tiene el mapa de ubicación 
de la campaña en donde se vacunaran a las mascotas, con un simple toque en el mapa en

donde quieren que sea la campaña, el sistema te genera la latitud y longitud en donde lo guarda en la base de datos, también tiene su CRUD.

El Admin también tiene creación de usuarios que serian los médicos con su propio CRUD respectivo.

## 3. Roles / integrantes
- Luis Fernando Kellner Zerda / (Db Architect).

- Marco Josue Cruz Larama / (Git Master).

- Jose Mauricio Herbas Terceros / (Developer).

## 4. Arquitectura del software:
El sistema esta hecho en con ASP.net core, el sistema esta hecho con el patron MVC, modelo, vista, controlador, en la carpeta modelo están todas las clases, 
como Brigade, BrigadeCampaign, Campaign, ErrorViewModel, Person, RegisterVaccine, Report, User, ReportsModel, StatisticData, en la carpeta Data esta DB_Context 
este llama a las clases las obtiene y las asigna, primero se crean los controladores, los controladores contiene la lógica de control de flujo para una aplicación 
ASP.NET MVC, determina qué respuesta devolver a un usuario cuando un usuario realiza una solicitud del explorador, hacen las consultas, en las vistas son las interfaces 
de todas las clases que tienen sus propios CRUDS, luego están las migraciones que permiten cambiar el modelo de datos e implementar los cambios en producción mediante la 
actualización del esquema de base de datos sin tener que quitar y volver a crear la base de datos, la conexión a la base de datos esta en appsettings.jason utiliza json 
para el almacenamiento de datos.

## 5. Requisitos del sistema:

### · Requerimientos de Hardware (mínimo): (cliente)

Se requiere una computadora con windows 10, con ratón, teclado y un buen procesador en nuestro caso hicimos en una i7, con 4 GB de RAM,

### · Requerimientos de Software: (cliente)

Se necesita el visual studio 2022.

Tambien se necesita Microsoft SQL Server 2019 (RTM) – 15.0.2000.5 (X64) 2019 Microsoft Corporation Express Edition (64-bit) on windows 10 pro 10.0 <X64> (Build 19045) (Hypervisor).

### · Requerimientos de Hardware (server/ hosting/BD)

La base de datos esta hecha en SQL server 2019 (RTM) – 15.0.2000.5 (x64).

### · Requerimientos de Software (server/ hosting/BD)

Esta hosteado en el puerto 7151 localhost, cuando le damos al botón de correr el programa nos redirecciona al host web 7151, esta hecho con Asp.net core en eso no habría problemas,
solo se necesita Docker 2019 o 2022 esta dockerizado tiene una imagen que lo subimos y también esta subido al git

## 6. Instalación y configuración:

Para la instalación se necesita tener el visual studio community.

Crear una carpeta en su computadora para poner ahí la carpeta del GIT

Decargar el sistema desde GIT ,el proyecto esta ubicado en el repositorio git, en el hilo de masterWeb, ahi esta el proyecto completo..

Entrar a la carpeta buscar el archivo sln darle doble click, y cambiar en la extensión JSON que se llama appsettings.jason, cambiar la conexión de nuestra base de datos a su conexión:

Server=ellocalhost_delIngeniero;Database=PRIVacunacion;User=sa;Password=contraseña_Ingeniero;Trusted_Connection=True;Encrypt=False;

Base de datos:

Instalar la base de datos, SQL Server, descargar el archivo .bak que ya esta poblada.

## 7. PROCEDIMIENTO DE HOSTEADO / HOSTING (configuración)

### · Sitio Web.

Para importar la imagen del proyecto de ASP primero se ingresa al cmd e ir a la ubicación donde esta el archivo descargado como Vacunacion.Tar

Después ponemos el siguiente código

Docker load < Vacunacion.Tar (nombre del archivo)

Y se importara ahora ponga

Docker images

Y le saldrá las imágenes que tienen y en ahí estará la imagen de vacunación

Luego para ejecutar la imagen ponga la siguiente código

docker run --name ASP -p 80:80 -p 443:443 -d marcotow/vacunacion:latest

y listo inicie su navegador web y ponga localhost y le aparecerá el proyecto, cabe recalcar que mientras hace todo esto el Docker desktop necesita estar abierto para que se actualice el docker.

### · B.D.

Instalar la base de datos, SQL Server, descargar el archivo .bak que ya esta poblada

### · API / servicios Web

### · Otros (firebase, etc.)

## 8. GIT :

El proyecto se encuentra en PRI-Vacunaciones en la rama masterWEB:

https://github.com/MarquitosMarco/PRI-VACUNACIONES.git

## 9. Personalización y configuración:

Cuando se abra el proyecto se necesita logearse para logearse en nombre de usuario se pueden escoger dos opciones la del administrador y la del superadmi, 
la contraseña para ambos es QXUG6cV1, esa es la contraseña del usuario admin y superadmin sin esa contraseña no puede ingresar al sistema.

La función del ingreso de datos es crear una contraseña y usuario al momento de insertar datos del usuario (medico) en el crud de crear usuarios del superadmin y
admin se manda a un correo electrónico la nueva contraseña y usuario al medico, en este caso el ingeniero puede probar con su correo electronico.

10. Seguridad:

### Login

Los usuarios deben autenticarse antes de insertar datos, sino se logean no podrá entrar al sistema.

### Gestión de Roles

La aplicación debe tener roles como Superadmin y Admin

Los administradores tienen acceso a crear usuarios y brigadas

Los superadministradores pueden crear campañas, usuarios y generar reportes.

Restringiendo el acceso de acuerdo a su rol.

## 11. Depuración y solución de problemas:

Tenemos un pequeño inconveniente al editar usuario en el superadmin y admin, al momento de editar a una persona que queremos cambiar, se crea un registro nuevo en nuestra base de datos, pero igual sigue registrando en la base de datos.

## 12. Glosario de términos:

ASP.NET Core: Framework de desarrollo web de código abierto desarrollado por Microsoft. Es una versión modular y de alto rendimiento de ASP.NET que es multiplataforma y compatible con la nube.

Superadmin: el que se encarga de tener el control de lo mas importante en un espacio de trabajo, tener el control de los administradores.

## 13. Referencias y recursos adicionales:

Documentación de ASP.NET https://learn.microsoft.com/es-es/aspnet/core/?view=aspnetcore-8.0

## 14. Herramientas de Implementación:

### · Lenguajes de programación: C#

### · Frameworks:ASP.net Core

### · Plataforma DB: SQL Server

## 15. Bibliografía

### - Guía de como dockerizar

https://youtu.be/bLVVj-3_wlA?si=SFbR796Q7I4uut7J

### - Como es un crud completo ASP.Net core MVC, con conexión Sql server

https://youtu.be/qcRCDM5KiSo?si=EIihgD8Y0VcnfQZs
# VIDEO DE YOUTUBE
## https://youtu.be/xaBsinfLQPI?si=D2NsezSkj-0znCsU
