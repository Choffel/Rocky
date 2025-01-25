# Используйте образ с поддержкой .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RockyTwo.csproj", "."]
RUN dotnet restore "./RockyTwo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RockyTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RockyTwo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RockyTwo.dll"]
