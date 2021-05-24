FROM mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04

USER root

#ENV SA_PASSWORD Password_0
#ENV ACCEPT_EULA Y
#ENV MSSQL_PID Express

RUN mkdir -p /usr/src/app

WORKDIR /usr/src/app

#Usar esta linea para docker compose
COPY ./Database /usr/src/app
#Usar esta línea para dockerfile
#COPY . /usr/src/app
EXPOSE 1433

RUN chmod +x /usr/src/app/run-initialization.sh

CMD /bin/bash ./entrypoint.sh

