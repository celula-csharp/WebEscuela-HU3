FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["webEscuela.Api/webEscuela.Api.csproj", "webEscuela.Api/"]
COPY ["webEscuela.Application/webEscuela.Application.csproj", "webEscuela.Application/"]
COPY ["webEscuela.Domain/webEscuela.Domain.csproj", "webEscuela.Domain/"]
COPY ["webEscuela.Infrastructure/webEscuela.Infrastructure.csproj", "webEscuela.Infrastructure/"]
RUN dotnet restore "webEscuela.Api/webEscuela.Api.csproj"
COPY . .
WORKDIR "/src/webEscuela.Api"
RUN dotnet build "./webEscuela.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./webEscuela.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet webEscuela.Api.dll
