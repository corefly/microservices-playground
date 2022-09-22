#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroservicesPlayground.PlatformService/MicroservicesPlayground.PlatformService.csproj", "MicroservicesPlayground.PlatformService/"]
RUN dotnet restore "MicroservicesPlayground.PlatformService/MicroservicesPlayground.PlatformService.csproj"
COPY . .
WORKDIR "/src/MicroservicesPlayground.PlatformService"
RUN dotnet build "MicroservicesPlayground.PlatformService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesPlayground.PlatformService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesPlayground.PlatformService.dll"]