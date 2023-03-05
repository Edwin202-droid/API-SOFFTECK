#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=https://*8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Softtek-API/Softtek-API.csproj", "Softtek-API/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Pagination/Helpers.csproj", "Pagination/"]
COPY ["DTO/DTO.csproj", "DTO/"]
RUN dotnet restore "Softtek-API/Softtek-API.csproj"
COPY . .
WORKDIR "/src/Softtek-API"
RUN dotnet build "Softtek-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softtek-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softtek-API.dll"]