FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine
LABEL Author="Mel"
ENV ASPNETCORE_URLS=http://
WORKDIR /app
CMD [ "/bin/sh", "-c", "dotnet restore && dotnet run --urls http://0.0.0.0:5000"]