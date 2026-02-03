# Etapa 1: Build
# Cambia a 9.0 o tu versión si usas .NET 9
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solución y proyectos (para cachear restore)
COPY *.sln .
COPY */*.csproj ./
RUN dotnet restore "TLSRestApi/TLSRestApi.csproj"

# Copia código y publica
COPY . .
WORKDIR "/src/TLSRestApi"
RUN dotnet publish "TLSRestApi.csproj" -c Release -o /app/publish --no-restore

# Etapa 2: Runtime (imagen ligera)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render usa $PORT automáticamente
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

EXPOSE ${PORT:-8080}
ENTRYPOINT ["dotnet", "TLSRestApi.dll"]  # Cambia si tu DLL se llama diferente