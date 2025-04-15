# 🔨 Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos el archivo del proyecto primero para cacheo de dependencias
COPY backend.csproj ./
RUN dotnet restore

# Luego copiamos el resto del código
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# 🚀 Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

# Puerto opcional, no es obligatorio si usás docker-compose
EXPOSE 8080
# EXPOSE 5001

# 👇 Cambiá esto si el nombre de tu DLL no es backend.dll
ENTRYPOINT ["dotnet", "backend.dll"]
