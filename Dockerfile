FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY notes-service/*.csproj ./
RUN dotnet restore

# Copy everything else
COPY notes-service/. ./
RUN dotnet publish -c Release -o out

# Build image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "notes-service.dll"]