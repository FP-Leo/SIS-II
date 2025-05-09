# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Presentation/SIS.API/SIS.API.csproj", "Source/Presentation/SIS.API/"]
COPY ["Source/Core/SIS.Application/SIS.Application.csproj", "Source/Core/SIS.Application/"]
COPY ["Source/Core/SIS.Domain/SIS.Domain.csproj", "Source/Core/SIS.Domain/"]
COPY ["Source/Infrastructure/SIS.Infrastructure/SIS.Infrastructure.csproj", "Source/Infrastructure/SIS.Infrastructure/"]
COPY ["Common/SIS.Common.csproj", "Common/"]
COPY ["Source/Infrastructure/SIS.Persistence/SIS.Persistence.csproj", "Source/Infrastructure/SIS.Persistence/"]
RUN dotnet restore "./Source/Presentation/SIS.API/SIS.API.csproj"
COPY . .
WORKDIR "/src/Source/Presentation/SIS.API"
RUN dotnet build "./SIS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SIS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIS.API.dll"]