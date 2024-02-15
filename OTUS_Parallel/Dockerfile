FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OTUS_Parallel/OTUS_Parallel.csproj", "OTUS_Parallel/"]
RUN dotnet restore "OTUS_Parallel/OTUS_Parallel.csproj"
COPY . .
WORKDIR "/src/OTUS_Parallel"
RUN dotnet build "OTUS_Parallel.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OTUS_Parallel.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OTUS_Parallel.dll"]
