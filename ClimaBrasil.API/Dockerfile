FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7179

ENV ASPNETCORE_URLS=http://+:7179
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClimaBrasil.API/ClimaBrasil.API.csproj", "ClimaBrasil.API/"]
COPY ["ClimaBrasil.Application/ClimaBrasil.Application.csproj", "ClimaBrasil.Application/"]
COPY ["ClimaBrasil.Domain/ClimaBrasil.Domain.csproj", "ClimaBrasil.Domain/"]
COPY ["ClimaBrasil.Infrastructure/ClimaBrasil.Infrastructure.csproj", "ClimaBrasil.Infrastructure/"]
RUN dotnet restore "ClimaBrasil.API/ClimaBrasil.API.csproj"
COPY . .
WORKDIR "/src/ClimaBrasil.API"
RUN dotnet build "ClimaBrasil.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClimaBrasil.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClimaBrasil.API.dll"]