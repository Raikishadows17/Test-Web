# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia el .sln primero
COPY *.sln .

# Copia cada .csproj en su carpeta respectiva (preserva estructura para multi-proyecto)
COPY Application/*.csproj Application/
COPY Domain/*.csproj Domain/
COPY Infrastructure/*.csproj Infrastructure/
COPY TLSRestApi/*.csproj TLSRestApi/

# Restaura dependencias del proyecto principal (o de la solución si prefieres)
RUN dotnet restore "TLSRestApi/TLSRestApi.csproj"

# Copia todo el código fuente restante
COPY . .

# Publica el proyecto principal
WORKDIR "/src/TLSRestApi"
RUN dotnet publish "TLSRestApi.csproj" -c Release -o /app/publish --no-restore

# Etapa 2: Runtime (imagen ligera para producción)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Configuración para Render: usa $PORT que inyecta automáticamente Render
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

# Expone el puerto variable
EXPOSE ${PORT:-8080}

# Ejecuta la app
ENTRYPOINT ["dotnet", "TLSRestApi.dll"]
