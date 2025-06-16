# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . ./

WORKDIR /src/AlquilerMicroservicio.API
RUN dotnet restore
RUN dotnet publish AlquilerMicroservicio.API.csproj -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AlquilerMicroservicio.API.dll"]