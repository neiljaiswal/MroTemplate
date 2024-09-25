# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Gatherly.App/Gatherly.App.csproj", "src/Gatherly.App/"]
COPY ["src/Gatherly.Application/Gatherly.Application.csproj", "src/Gatherly.Application/"]
COPY ["src/Gatherly.Domain/Gatherly.Domain.csproj", "src/Gatherly.Domain/"]
COPY ["src/Gatherly.Infrastructure/Gatherly.Infrastructure.csproj", "src/Gatherly.Infrastructure/"]
COPY ["src/Gatherly.Persistence/Gatherly.Persistence.csproj", "src/Gatherly.Persistence/"]
COPY ["src/Gatherly.Presentation/Gatherly.Presentation.csproj", "src/Gatherly.Presentation/"]
RUN dotnet restore "./src/Gatherly.App/Gatherly.App.csproj"
COPY . .
WORKDIR "/src/src/Gatherly.App"
RUN dotnet build "./Gatherly.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Gatherly.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gatherly.App.dll"]