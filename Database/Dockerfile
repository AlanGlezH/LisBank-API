FROM mcr.microsoft.com/mssql/server:2017-CU21-ubuntu-16.04

ENV SA_PASSWORD Password_0
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

RUN mkdir -p /usr/src/app

WORKDIR /usr/src/app

#Cambiar esta linea para docker compose
COPY ./Database /usr/src/app
# COPY . /usr/src/app
EXPOSE 1433

RUN chmod +x /usr/src/app/run-initialization.sh

CMD /bin/bash ./entrypoint.sh

