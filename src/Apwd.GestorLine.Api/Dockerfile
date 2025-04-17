#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 82

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Apwd.GestorLine.Api/Apwd.GestorLine.Api.csproj", "Apwd.GestorLine.Api/"]
COPY ["Apwd.GestorLine.Domain/Apwd.GestorLine.Domain.csproj", "Apwd.GestorLine.Domain/"]
COPY ["Apwd.GestorLine.Ioc/Apwd.GestorLine.Ioc.csproj", "Apwd.GestorLine.Ioc/"]
COPY ["Apwd.GestorLine.MongoDb/Apwd.GestorLine.MongoDb.csproj", "Apwd.GestorLine.MongoDb/"]
COPY ["Apwd.GestorLine.Services/Apwd.GestorLine.Services.csproj", "Apwd.GestorLine.Services/"]
RUN dotnet restore "Apwd.GestorLine.Api/Apwd.GestorLine.Api.csproj"
COPY . .
WORKDIR "/src/Apwd.GestorLine.Api"
RUN dotnet build "Apwd.GestorLine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apwd.GestorLine.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apwd.GestorLine.Api.dll"]