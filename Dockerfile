
## ------ FASE DE CONSTRUCCIÓN ------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia y restaura el proyecto de forma limpia
COPY ["ProyPruebasApi.csproj", "./"]
RUN dotnet restore "ProyPruebasApi.csproj"

# Copia el código (el .dockerignore excluirá bin y obj)
COPY . .
RUN dotnet publish "ProyPruebasApi.csproj" -c Release -o /app/publish /p:UseAppHost=false


## ------ FASE DE EJECUCIÓN ------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Crear un usuario no-root compatible con Debian (imagen base oficial de .NET)
RUN useradd --create-home --shell /bin/bash appuser && \
    chown -R appuser:appuser /app

# Copiar el resultado publicado
COPY --from=build /app/publish .

# Puerto 8080 expuesto y asignacion de la url
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Cambiar al usuario no-root
USER appuser

# Iniciar la aplicacion
ENTRYPOINT ["dotnet", "ProyPruebasApi.dll"]
