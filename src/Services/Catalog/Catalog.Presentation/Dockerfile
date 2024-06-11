#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Catalog/Catalog.Presentation/Catalog.Presentation.csproj", "Services/Catalog/Catalog.Presentation/"]
COPY ["Services/Catalog/Catalog.Application/Catalog.Application.csproj", "Services/Catalog/Catalog.Application/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Services/Catalog/Catalog.Domain/Catalog.Domain.csproj", "Services/Catalog/Catalog.Domain/"]
COPY ["Services/Catalog/Catalog.Infrastructure/Catalog.Infrastructure.csproj", "Services/Catalog/Catalog.Infrastructure/"]
RUN dotnet restore "./Services/Catalog/Catalog.Presentation/./Catalog.Presentation.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Catalog.Presentation"
RUN dotnet build "./Catalog.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Presentation.dll"]