# Imagem base do ASP.NET (Linux)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Imagem para build (Linux)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["3Trees/ThreeTrees.csproj", "3Trees/"]
RUN dotnet restore "./3Trees/ThreeTrees.csproj"
COPY . .
WORKDIR "/src/3Trees"
RUN dotnet build "./ThreeTrees.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicação do projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ThreeTrees.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase final (imagem para rodar o app)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThreeTrees.dll"]
 