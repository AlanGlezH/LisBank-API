#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LisBank.API/LisBank.API.csproj", "LisBank.API/"]
COPY ["LisBank.Core/LisBank.Core.csproj", "LisBank.Core/"]
COPY ["LisBank.Infrastructure/LisBank.Infrastructure.csproj", "LisBank.Infrastructure/"]
RUN dotnet restore "LisBank.API/LisBank.API.csproj"
COPY . .
WORKDIR "/src/LisBank.API"
RUN dotnet build "LisBank.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LisBank.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LisBank.API.dll"]
