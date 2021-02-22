#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Alcanos.Api/Alcanos.Api.csproj", "Alcanos.Api/"]
RUN dotnet restore "Alcanos.Api/Alcanos.Api.csproj"
COPY . .
WORKDIR "/src/Alcanos.Api"
RUN dotnet build "Alcanos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alcanos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alcanos.Api.dll"]