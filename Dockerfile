FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine
LABEL Author="Mel"
ENV ASPNETCORE_URLS=http://*:5050
WORKDIR /app
CMD [ "/bin/sh", "-c", "dotnet restore && dotnet run" ]