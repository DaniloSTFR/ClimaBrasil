FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000,http://+:80;

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ClimaBrasil.API/ClimaBrasil.API.csproj", "ClimaBrasil.API/"]
RUN dotnet restore "ClimaBrasil.API/ClimaBrasil.API.csproj"
COPY . .
WORKDIR "/src/ClimaBrasil.API"
RUN dotnet build "ClimaBrasil.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ClimaBrasil.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClimaBrasil.API.dll"]
