FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /location-service
EXPOSE 7001

ENV ASPNETCORE_URLS=http://+:7001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/services/LocationService/LocationService.csproj", "src/services/LocationService/"]
RUN dotnet restore "src/services/LocationService/LocationService.csproj"
COPY . .
WORKDIR "/src/src/services/LocationService"
RUN dotnet build "LocationService.csproj" -c $configuration -o /location-service/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LocationService.csproj" -c $configuration -o /location-service/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /location-service
COPY --from=publish /location-service/publish .
ENTRYPOINT ["dotnet", "LocationService.dll"]
