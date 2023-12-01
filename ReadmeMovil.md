

# PRI-VACUNACIONES MOVIL



Manual técnico de la aplicación Android para el control de vacunación para mascotas en dispositivos móviles 

 

 

 

Cinthia Ocampo Rivera 

 

 

 

Universidad del valle 

Ingeniería de Sistemas Informáticos 

Cochabamba – Bolivia 

 Año 2023 

 

 

 

Índice general  

 

 1 Introducción  

 2 Descripción general del sistema 

 3  roles/integrantes 

 4 Arquitectura del software 

 5 Requisitos del sistema: software y hardware 

6 Instrucciones de instalación y configuración del sistema 

7 Procedimiento de hosteado/hosting(configuración) 

8 Git 

9 Personalización y configuración del sistema 

10 Seguridad del sistema 

11 Depuración y solución de problemas 

12 Glosario de términos 

13 Referencias y recursos adicionales 

14 Herramientas de implementación 

15 Bibliografía 

 

 

 

 

 

 

 

1 Introducción 

Este manual, se realizó con el objetivo de indicar al usuario la forma en que se instala la aplicación “Control de vacunas para mascotas” en un teléfono móvil. Por lo tanto, se realizó una descripción general de la aplicación, las instrucciones a seguir para instalarla o desinstalarla y la solución de problemas. Además, se hizo mención sobre las características de los usuarios que utilicen la aplicación y los requerimientos software y hardware que requiera la misma. 

 

 

 

 

 

2 Descripción general del sistema 

El marco del proyecto incluye el desarrollo de la aplicación “Control de vacunas para Mascotas” con el propósito de obtener una lista de mascotas registradas en la API, junto con sus respectivos códigos QR. Uno de los objetivos fundamentales del proyecto es facilitar la administración de diversas vacunas a las mascotas. Una vez que hemos recuperado los datos de la API, que incluyen información tanto del propietario como de la mascota, junto con sus respectivas fotografías para garantizar una mayor seguridad, procedemos a aplicar las distintas vacunas según las campañas activas. 

Una vez que hemos recopilado todos los datos relevantes, llevamos a cabo el proceso de registro de la vacunación para cada mascota. Este enfoque integral garantiza un control efectivo de las vacunas administradas, contribuyendo así a la salud y bienestar de las mascotas y proporcionando a los propietarios una  

Plataforma segura y confiable, para gestionar el historial de vacunacion de sus mascotas. 

3 Roles/integrantes 

Rol: Team Leader/ Developers 

Estudiante: Cinthia Ocampo Rivera 

 

4 Arquitectura del software 

La arquitectura en el desarrollo de aplicaciones moviles, como en el caso de MAUI, sé sustenta en principios de desarrollo modernos e integración de tecnologías clave para garantizar la eficiencia y consistencia de aplicaciones multiplataforma. La elección cuidadosa de patrones de diseño y la organización estructurada de componentes son fundamentales para lograr un desarrollo mantenible y de calidad. 

Proyecto MAUI: La aplicación inicia con un proyecto MAUI, la base del desarrollo multiplataforma. Este proyecto alberga los archivos de configuración, recursos compartidos y referencias a proyectos específicos de cada plataforma. Proporciona la infraestructura necesaria para crear aplicaciones que funcionan de manera uniforme en distintos entornos. 

Páginas y Vistas: Las páginas, componentes esenciales, representan las interfaces de usuario (UI). Se utiliza XAML para definir la estructura de estas páginas y vistas, asegurando una separación clara entre la presentación y la lógica de la interfaz. 

ViewModels: Los ViewModels son la capa que contiene la lógica de presentación y facilita la interacción entre la interfaz de usuario y los datos. Adopta el patrón MVVM (Model-View-ViewModel) para una clara separación entre la lógica de presentación y la lógica de negocio. 

Modelos: Representan la estructura de datos y la lógica de negocio. Pueden incluir clases, servicios y otros componentes para la manipulación de datos. 

Servicios y APIs: Los servicios proporcionan funcionalidades específicas, como el acceso a bases de datos, servicios web o capacidades del sistema operativo. La interacción con APIs permite acceder a funciones específicas de la plataforma. 

Dependency Injection (Inyección de Dependencias): MAUI facilita la Inyección de Dependencias para gestionar las dependencias entre componentes. Esto mejora el modularidad y la testabilidad al proporcionar instancias de servicios y otros objetos necesarios. 

Patrones de Diseño: MAUI utiliza patrones de navegación para gestionar las transiciones entre páginas y vistas, adaptándose según los requisitos de la aplicación. Además, se pueden definir estilos y temas para mantener la coherencia visual, y los recursos compartidos permiten la reutilización de estilos en diferentes plataformas. 

Interacciones entre Componentes: 

Interfaz de Usuario y ViewModel: 

La interfaz de usuario se enlaza con el ViewModel para reflejar cambios en los datos y responder a las interacciones del usuario. Los comandos y enlaces de datos facilitan la comunicación bidireccional. 

ViewModel y Model: 

El ViewModel se comunica con el modelo para obtener y actualizar datos. Los cambios en el modelo se reflejan en la interfaz de usuario a través de la lógica de presentación en el ViewModel. 

Servicios y ViewModel: 

Los servicios proporcionan funcionalidades específicas al ViewModel. La Inyección de Dependencias facilita la integración de servicios en el ViewModel. 

Patrones de Diseño Utilizados: 

MVVM (Model-View-ViewModel): 

Divide la aplicación en modelos, vistas y ViewModels para una organización clara y una separación de preocupaciones. 

Inyección de Dependencias: 

Facilita la gestión de dependencias entre componentes, mejorando la modularidad y la testabilidad. 

XAML para la Definición de Interfaces de Usuario: 

Utiliza el lenguaje XAML para definir la estructura y la apariencia de la interfaz de usuario, proporcionando una separación clara entre la lógica de presentación y la interfaz de usuario. 

 

5 Requisitos del sistema: software y hardware 

Los requisitos mínimos de la terminal móvil para la instalación y trabajo de la aplicación “Control de vacunación”, son los siguientes: 

Sistema operativo Android mayor a la versión 5.  

Memoria RAM de 2 Gb y capacidad de almacenamiento de 4Gb.  

Los requisitos necesarios para la instalación y puesta en marcha de la aplicación “Control de vacunación”, se describe detalladamente en el manual técnico “aplicación de control de vacunas para mascotas”.  

Los requisitos mínimos de la terminal escritorio para la instalación y trabajo de la aplicación “Control de vacunación”, son los siguientes: 

Windows 10 o versión superior. 

Memoria RAM de 8 Gb para garantizar un rendimiento óptimo de la aplicación. 

 

6 Instrucciones de instalación y configuración del sistema 

Esta sección aborda el proceso de instalación, ejecución y operación de la aplicación “Control de Vacunas”. La instalación de la aplicación es seguida por la ejecución, que nos lleva directamente a la pantalla de inicio de sesión. Una vez en la pantalla de inicio de sesión, se nos presenta la opción de ingresar con uno de los dos usuarios previamente definidos según los requisitos del cliente: el usuario “Admin” con la contraseña”123” o el usuario “Medico” con la contraseña”122”. Una vez autenticados, la aplicación nos redirige a la interfaz de escaneo de códigos QR. 

En la interfaz de escaneo, al hacer clic en el botón "Escanear", se nos lleva a la sección de archivos donde seleccionamos el código QR correspondiente. Al seleccionar el código QR, la aplicación recupera automáticamente los datos asociados a las mascotas, incluyendo información del propietario y hasta cuatro fotos de cada mascota para garantizar la máxima seguridad en la identificación. 

Con los datos obtenidos, tanto del propietario como de las mascotas, el siguiente paso es el registro de una vacuna. Para llevar a cabo este proceso, hacemos clic en el botón "Registrar Vacuna". Una vez completado el registro de la vacuna, se nos brinda la opción de cerrar la aplicación. 

 

Abrimos la aplicación .NET 

 

 

Nos dirijira a la interfaz de inicio de sesion 

Dondo ingresaremos los datos de usuario (Admin) y Passsowrd(123) 

 

Luego nos dirigira a la siguiente interfaz para activar la cámara para escanear el codigo.  

 

 

 

 

 

 

Una vez seleccionado el botón de cámara nos dirigirá a esta interfaz donde podremos seleccionar el QR. 

  

Una vez que hemos presionado el botón seleccionar qr nos dirigirá a este interfaz. Donde podremos seleccionar el QR que hemos creado. En este caso seleccionamos el qr29.  

 

 

 

Una vez seleccionado el qr escaneamos el qr y nos devlovera el codigo. 

 

 

 

Seleccionamos el botón ingresar. Nos dirigirá a esta interfaz donde podremos visualizar los datos que nos retornará el QR desde la API. 

 

Una vez obtenida los datos del QR. Registramos una vacuna para las mascotas.  

 

 

Si queremos ejecutar en la computadora tenemos que tener instalado la siguiente versión de visual studio commnity 2022: para ejecutar la aplicación .NET MAUI, necesitara la versión 7.5 de visual Studio 2022. Una vez descargado el archivo desde el GITHUB debe ejecutar el programa en su visual studio 2022. Si presenta algún inconveniente o fallos debe asegurarse de recompilar la solución en el proyecto o debe configurar la conexión a la base de datos. En la carpeta Services, la clase PersonServece.cs 

Para hacer la cadena de conexión  a la base de datos debe poner sus credenciales como su usuario sa y su password. El nombre de la base de datos no debe cambiar eso mantendra. 

Una vez realixada la cadena de conexión podra ver las diagras de bases de datos y tablien iniciar secion en la aplicación. 

 

         

Una vez en la pantalla de inicio de sesión, se nos presenta la opción de ingresar con uno de los dos usuarios previamente definidos según los requisitos del cliente: el usuario “Admin” con la contraseña”123” o el usuario “Medico” con la contraseña”122”. Una vez autenticados, la aplicación nos redirige a la interfaz de escaneo de códigos QR. 

En la interfaz de escaneo, al hacer clic en el botón "Escanear", se nos lleva a la sección de archivos donde seleccionamos el código QR correspondiente. Al seleccionar el código QR, la aplicación recupera automáticamente los datos asociados a las mascotas, incluyendo información del propietario y hasta cuatro fotos de cada mascota para garantizar la máxima seguridad en la identificación. 

Con los datos obtenidos, tanto del propietario como de las mascotas, el siguiente paso es el registro de una vacuna. Para llevar a cabo este proceso, hacemos clic en el botón "Registrar Vacuna". Una vez completado el registro de la vacuna, se nos brinda la opción de cerrar la aplicación. 

 

 

 

 

  

 

 

7 Procedimiento de hosteado/hosting(configuración) 

  

B.D  

Para la base de datos se prefirió  el SQL SERVER 

API/servicio web 

Para la recuperación de la información del propietario y las fotos de las mascotas se utiliza una API. 

 

C:\Windows\System32>docker ps 

CONTAINER ID   IMAGE     COMMAND   CREATED   STATUS    PORTS     NAMES 

 

 C:\Windows\System32>docker pull mcr.microsoft.com/mssql/server:2022-latest 

 

2022-latest: Pulling from mssql/server 

e481c36a257f: Pull complete 

167fcf789ae3: Pull complete 

de849cbae9b1: Pull complete 

Digest: sha256:3adc70cba564b18190340eb4b82d11dd1c99dbca5fc490b20290f8f6a138069f 

Status: Downloaded newer image for mcr.microsoft.com/mssql/server:2022-latest 

mcr.microsoft.com/mssql/server:2022-latest 

  

What's Next? 

  View a summary of image vulnerabilities and recommendations → docker scout quickview mcr.microsoft.com/mssql/server:2022-latest 

  

C:\Windows\System32>docker image ls 

REPOSITORY                       TAG           IMAGE ID       CREATED       SIZE 

mcr.microsoft.com/mssql/server   2022-latest   3c17532d9acc   5 weeks ago   1.58GB 

 

 

 

 

 

 

  

C:\Windows\System32>docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Cinthia1234." -p 1433:1433 --name contenedorSqlServer2022 -d mcr.microsoft.com/mssql/server:2022-latest 

8e6dbfb328b360f8f0bf73917301bf4fbae22a2169fe91f6201962eaf3f88706 

  

C:\Windows\System32>docker ps -a 

CONTAINER ID   IMAGE                                        COMMAND                  CREATED          STATUS          PORTS                    NAMES 

8e6dbfb328b3   mcr.microsoft.com/mssql/server:2022-latest   "/opt/mssql/bin/perm…"   49 seconds ago   Up 45 seconds   0.0.0.0:1433->1433/tcp   contenedorSqlServer2022 

  

C:\Windows\System32>docker ps 

CONTAINER ID   IMAGE                                        COMMAND                  CREATED         STATUS         PORTS                    NAMES 

8e6dbfb328b3   mcr.microsoft.com/mssql/server:2022-latest   "/opt/mssql/bin/perm…"   2 minutes ago   Up 2 minutes   0.0.0.0:1433->1433/tcp   contenedorSqlServer2022 

  

C:\Windows\System32>docker stop contenedorSqlServer2022 

contenedorSqlServer2022 

  

C:\Windows\System32>docker ps 

CONTAINER ID   IMAGE     COMMAND   CREATED   STATUS    PORTS     NAMES 

  

C:\Windows\System32>docker start contenedorSqlServer2022 

ContenedorSqlServer2022 

 

 

 

 

 

 

 8 Git 

 

 

9 Personalización y configuración del sistema 

La personalización y configuración del sistema son procesos esenciales para adaptar el software a las necesidades específicas del usuario. 

1. Configuración del Software: 

a. Acceso a Configuración: 

Busca la sección de configuración o preferencias dentro del software. Esto suele estar disponible en menús desplegables o barras de herramientas. 

b. Configuración de Interfaz de Usuario: 

Personaliza la apariencia de la interfaz de usuario ajustando temas, colores, fuentes y disposición de elementos. 

c. Configuración de Cuentas: 

Establece preferencias de cuenta, como nombre de usuario, imagen de perfil y notificaciones. 

3. Variables de Entorno: 

a. Configuración a Nivel de Sistema: 

Utiliza variables de entorno para configurar aspectos globales del sistema que afectan múltiples aplicaciones. 

b. Variables de Entorno del Usuario: 

Personaliza variables de entorno específicas del usuario para ajustar configuraciones individuales. 

4. Configuración de Seguridad: 

a. Contraseñas y Autenticación: 

Ajusta las configuraciones relacionadas con la seguridad, como políticas de contraseñas y métodos de autenticación. 

b. Configuración de Cortafuegos: 

Personaliza las reglas del cortafuegos para controlar el tráfico de red y mejorar la seguridad. 

5. Configuración de Copias de Seguridad y Restauración: 

a. Programación de Copias de Seguridad: 

Configura la programación y la retención de copias de seguridad para proteger datos importantes. 

b. Restauración del Sistema: 

Configura y utiliza puntos de restauración del sistema para revertir configuraciones no deseadas. 

6. Accesibilidad: 

a. Configuración para Necesidades Especiales: 

Ajusta opciones de accesibilidad, como lectores de pantalla, atajos de teclado y contraste de color. 

7. Configuración de Actualizaciones: 

a. Programación de Actualizaciones: 

Configura la programación y el manejo de actualizaciones automáticas para mantener el software actualizado. 

 

10 Seguridad del sistema 

La seguridad es un aspecto critico en el desarrollo y uso de software. 

Control de acceso y permisos: 

 

a. Principio de Menor Privilegio: 

Otorga a los usuarios y sistemas solo los privilegios mínimos necesarios para realizar sus funciones. 

b. Gestión de Usuarios y Roles: 

Implementa una gestión de usuarios eficaz, asignando roles y responsabilidades de manera apropiada. 

2. Autenticación: 

a. Contraseñas Fuertes: 

Exige contraseñas robustas y fomenta su cambio periódico. Además, la aplicación ejecuta y dirige al usuario al proceso de autenticación en el cual solo se permite el acceso a roles específicos, según se describe en la descripción del sistema. 

3. Cifrado de Datos: 

a. Comunicaciones Seguras: 

Utiliza protocolos seguros (por ejemplo, HTTPS) para la transmisión de datos en redes. 

b. Cifrado de Almacenamiento: 

Cifra datos almacenados para proteger la información sensible, incluso en repositorios de bases de datos. 

 

11 Depuración y solución de problemas 

En este apartado, se mencionan las soluciones a algunos problemas que pueden llegar a suceder durante la instalación y ejecución de la aplicación “Control de vacunas”. Cabe mencionar, que la solución de problemas correspondientes a la aplicación “Control de vacunas para mascotas”, se encuentra en el manual técnico “aplicación para el control de vacunación de las mascotas”.  

Existe la posibilidad de que el teléfono móvil no permita la instalación de la aplicación “Control de vacunación”. Por lo tanto, es necesario dirigirse a las configuraciones del dispositivo móvil y habilitar la instalación de aplicaciones desconocidas. Además, es importante tener en cuenta que la aplicación no podrá ejecutarse en versiones anteriores a la 5, ya que requiere una versión del sistema operativo igual o superior a la 5 para funcionar correctamente. 

12 Glosario de términos 

MAUI (Multi-platform App UI): Framework de desarrollo de aplicaciones multiplataforma que permite la creación de interfaces de usuario consistentes en diversas plataformas. 

Depuración: Proceso de identificación y corrección de errores o problemas en el código de software. 

Autenticación Multifactor (MFA): Método de seguridad que requiere múltiples formas de verificación antes de permitir el acceso, proporcionando una capa adicional de protección. 

HTTPS (Hypertext Transfer Protocol Secure): Protocolo seguro de transferencia de hipertexto utilizado para la comunicación segura a través de la web. 

Cifrado de Datos: Proceso de codificación de información para proteger su confidencialidad, integridad y autenticidad. 

Registro de Eventos: Registro detallado de actividades y sucesos en un sistema, utilizado para auditoría y solución de problemas. 

Control de Versiones: Práctica de gestionar y rastrear cambios en el código fuente y otros archivos a lo largo del tiempo, facilitando la colaboración y la reversión a versiones anteriores. 

Branching (Ramificación): Creación de líneas de desarrollo separadas en un sistema de control de versiones para trabajar en funcionalidades o correcciones sin afectar la versión principal. 

Análisis Post-mortem: Revisión retrospectiva de un incidente o problema para identificar causas y aprender lecciones para mejorar en el futuro. 

Simulación de Problemas: Creación de escenarios controlados que reproducen problemas específicos para su análisis y resolución. 

Entorno de Desarrollo: Configuración de software y hardware utilizada para el desarrollo y prueba de aplicaciones. 

Configuraciones del Dispositivo Móvil: Ajustes y preferencias específicos que se pueden modificar en un dispositivo móvil, como permisos de instalación de aplicaciones y configuraciones de seguridad. 

Framework: Estructura o conjunto de herramientas que proporciona un marco de trabajo para el desarrollo de software. 

Pruebas de Estrés: Evaluación del rendimiento y la estabilidad del sistema bajo cargas extremas para identificar posibles problemas. 

Herramientas de Análisis Estático: Programas que analizan el código fuente sin ejecutarlo, identificando posibles problemas o vulnerabilidades. 

Desarrollo Multiplataforma: Creación de aplicaciones que pueden ejecutarse en múltiples plataformas, como iOS y Android, utilizando un único código base. 

 

13 Referencias y recursos adicionales 

Desarrollo de Software y MAUI: 

Documentación Oficial de .NET MAUI: Recursos detallados sobre .NET MAUI proporcionados por Microsoft. 

GitHub de .NET MAUI: Repositorio oficial de .NET MAUI en GitHub. 

Xamarin.Forms Documentation: Documentación para Xamarin.Forms, el precursor de .NET MAUI. 

Control de Versiones y Colaboración: 

Git Documentation: Documentación oficial de Git. 

Desarrollo Móvil y Backend: 

Enlace para el GIT  

https://github.com/MarquitosMarco/PRI-VACUNACIONES 

 

14 Herramientas de implementación 

Lenguajes de programación: C# 

Frameworks: .NET MAUI. 

 

15 Bibliografía 

https://github.com/yushulx/dotnet-barcode-qr-code-sdk/tree/main/example/maui. 

Xamarin.Forms barcode QR code scanner. 

 
 
Xamarin.Forms barcode QR code scanner. 
