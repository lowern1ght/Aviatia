FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/AuthorizationService/AuthorizationService.csproj", "src/services/AuthorizationService/"]
RUN dotnet restore "src/services/AuthorizationService/AuthorizationService.csproj"
COPY . .
WORKDIR "/src/src/services/AuthorizationService"
RUN dotnet build "AuthorizationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthorizationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthorizationService.dll"]
