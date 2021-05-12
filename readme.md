# LisBank - API Rest

## Descripción


El servidor está construido con las siguientes tecnologías:
- *.net 5*
- *Microsoft SQL Server 2019*

Requisitos para ejecutar el proyecto
 - Docker instalado

Opcional	
 - Visual Studio 2019

La opción mas fácil para ejecutar el proyecto es desde visual studio: 
 - Abrir el proyecto con Visual Studio
 - Ejecutar el proyecto de docker-compose

Ejecutar desde la terminal
 - Posicionate en la raíz del proyecto (carpeta "Comedores universitarios)
 - Ejecutar los siguentes comandos en la terminal:
	 -  `docker-compose build`	
	 -  `docker-compose up -d`

Los comandos anteriores son para crear las respectivas imágenes del contenedor de la API Rest y la base de datos SQL Server. Cabe mencionar que hay que esperar aproximadamente 90 segundos. El tiempo anterior es para que el servidor de sql sever tenga tiempo suficiente de esta preparado para la conexión. 
Puedes verificar que los contenedores estén corriendo y al mismo tiempo el puerto en el que se encuentran ejecutando: 

 - `docker-compose ps -a`

Podrás observar que el servidor de base de datos y el de la API están ejecutándose y en que puertos. Al visitar *localhost:5001/swagger* entraras a la documentación del servidor, ahí puedes ver todos los servicios definidos en él y la información necesaria para su ejecución. 

