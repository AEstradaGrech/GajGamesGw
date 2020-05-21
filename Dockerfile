FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app

COPY GajGamesOcelotGw.sln .
COPY GajGamesOcelotGw/GajGamesOcelotGw.csproj ./GajGamesOcelotGw/
COPY GajGamesOcelotGw/configuration.json ./GajGamesOcelotGw/

RUN dotnet restore

COPY . ./

RUN dotnet publish GajGamesOcelotGw.sln -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=base /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "GajGamesOcelotGw.dll"]

