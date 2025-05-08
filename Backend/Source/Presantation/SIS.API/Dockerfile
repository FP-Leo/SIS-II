FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5046

ENV ASPNETCORE_URLS=http://+:5046

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Backend/Source/Presantation/SIS.API/SIS.API.csproj", "Backend/Source/Presantation/SIS.API/"]
RUN dotnet restore "Backend/Source/Presantation/SIS.API/SIS.API.csproj"
COPY . .
WORKDIR "/src/Backend/Source/Presantation/SIS.API"
RUN dotnet build "SIS.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "SIS.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIS.API.dll"]
