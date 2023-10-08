FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ChimeMate.Api/ChimeMate.Api.csproj", "ChimeMate.Api/"]
RUN dotnet restore "ChimeMate.Api/ChimeMate.Api.csproj"
COPY . .
WORKDIR "/src/ChimeMate.Api"
RUN dotnet build "ChimeMate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChimeMate.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChimeMate.Api.dll"]
