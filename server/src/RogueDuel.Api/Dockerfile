FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["RogueDuel.sln", "./"]
COPY ["src/RogueDuel.Domain/RogueDuel.Domain.csproj", "src/RogueDuel.Domain/"]
COPY ["src/RogueDuel.Application/RogueDuel.Application.csproj", "src/RogueDuel.Application/"]
COPY ["src/RogueDuel.Infrastructure/RogueDuel.Infrastructure.csproj", "src/RogueDuel.Infrastructure/"]
COPY ["src/RogueDuel.Api/RogueDuel.Api.csproj", "src/RogueDuel.Api/"]
RUN dotnet restore "src/RogueDuel.Api/RogueDuel.Api.csproj"

COPY . .
RUN dotnet publish "src/RogueDuel.Api/RogueDuel.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "RogueDuel.Api.dll"]
