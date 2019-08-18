FROM mcr.microsoft.com/dotnet/core/sdk:1.1

WORKDIR /app

COPY /WebApiDummies/bin/Release/netcoreapp*/*  /app/

ENTRYPOINT dotnet WebApiDummies.dll

