#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NotesService/NotesService.csproj", "NotesService/"]
COPY ["NotesService.DAL/NotesService.DAL.csproj", "NotesService.DAL/"]
COPY ["NotesService.Domain/NotesService.Domain.csproj", "NotesService.Domain/"]
RUN dotnet restore "NotesService/NotesService.csproj"
COPY . .
WORKDIR "/src/NotesService"
RUN dotnet build "NotesService.csproj" -c Release -o /app/build

RUN chmod +x ../entrypoint.sh
CMD /bin/bash ./entrypoint.sh

FROM build AS publish
RUN dotnet publish "NotesService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesService.dll"]