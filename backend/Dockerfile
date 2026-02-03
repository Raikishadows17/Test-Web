# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  # Cambia a 9.0 o tu versión si usas .NET 9
WORKDIR /src

# Copia solución y proyectos para restaurar (mejora cache)
COPY *.sln .
COPY */*.csproj ./
RUN dotnet restore "TLSRestApi/TLSRestApi.csproj"

# Copia código y publica
COPY . .
WORKDIR "/src/TLSRestApi"
RUN dotnet publish "TLSRestApi.csproj" -c Release -o /app/publish

# Runtime stage (ligera)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render inyecta $PORT automáticamente, pero fuerza si quieres
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE ${PORT:-8080}

ENTRYPOINT ["dotnet", "TLSRestApi.dll"]  # Ajusta si tu DLL se llama diferente
