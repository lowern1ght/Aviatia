FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7001
EXPOSE 6001

ENV ASPNETCORE_URLS=http://+:7001
ENV ASPNETCORE_URLS=https://+:6001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/services/LocationService/LocationService.csproj", "src/services/LocationService/"]
RUN dotnet restore "src/services/LocationService/LocationService.csproj"
COPY . .
WORKDIR "/src/src/services/LocationService"
RUN dotnet build "LocationService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LocationService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationService.dll"]
