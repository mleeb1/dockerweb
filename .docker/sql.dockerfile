FROM mcr.microsoft.com/mssql/server:2017-latest
WORKDIR /app
EXPOSE 1433
RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "yourStrong(!)Password"