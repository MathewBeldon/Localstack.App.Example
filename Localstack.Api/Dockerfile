#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Localstack.Api/Localstack.Api.csproj", "Localstack.Api/"]
RUN dotnet restore "Localstack.Api/Localstack.Api.csproj"
COPY . .
WORKDIR "/src/Localstack.Api"
RUN dotnet build "Localstack.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Localstack.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Localstack.Api.dll"]