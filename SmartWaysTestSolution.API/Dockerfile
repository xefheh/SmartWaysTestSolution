FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SmartWaysTestSolution.API/SmartWaysTestSolution.API.csproj", "SmartWaysTestSolution.API/"]
COPY ["SmartWaysTestSolution.Persistence/SmartWaysTestSolution.Persistence.csproj", "SmartWaysTestSolution.Persistence/"]
COPY ["SmartWaysTestSolution.Domain/SmartWaysTestSolution.Domain.csproj", "SmartWaysTestSolution.Domain/"]
COPY ["SmartWaysTestSolution.Application/SmartWaysTestSolution.Application.csproj", "SmartWaysTestSolution.Application/"]
RUN dotnet restore "SmartWaysTestSolution.API/SmartWaysTestSolution.API.csproj"
COPY . .
WORKDIR "/src/SmartWaysTestSolution.API"
RUN dotnet build "SmartWaysTestSolution.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartWaysTestSolution.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartWaysTestSolution.API.dll"]
