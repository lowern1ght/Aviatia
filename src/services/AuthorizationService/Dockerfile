FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /authorization-service
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/AuthorizationService/AuthorizationService.csproj", "src/services/AuthorizationService/"]
RUN dotnet restore "src/services/AuthorizationService/AuthorizationService.csproj"
COPY . .
WORKDIR "/src/src/services/AuthorizationService"
RUN dotnet build "AuthorizationService.csproj" -c Release -o /authorization-service/build

FROM build AS publish
RUN dotnet publish "AuthorizationService.csproj" -c Release -o /authorization-service/publish

FROM base AS final
WORKDIR /authorization-service
COPY --from=publish /authorization-service/publish .
ENTRYPOINT ["dotnet", "AuthorizationService.dll"]