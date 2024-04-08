#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["APIs/Pencil/GraphiteApi.Pencil.API/GraphiteApi.Pencil.API.csproj", "APIs/Pencil/GraphiteApi.pencil.API/"]
COPY ["Domain/GraphiteApi.Domain.Commons/GraphiteApi.Domain.Commons.csproj", "Domain/GraphiteApi.Domain.Commons/"]
RUN dotnet restore "./APIs/Pencil/GraphiteApi.Pencil.API/./GraphiteApi.Pencil.API.csproj"
COPY . .
WORKDIR "/src/APIs/Pencil/GraphiteApi.Pencil.API"
RUN dotnet build "./GraphiteApi.Pencil.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GraphiteApi.Pencil.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphiteApi.Pencil.API.dll"]