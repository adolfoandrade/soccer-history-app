#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["App.Admin.Api/App.Admin.Api.csproj", "App.Admin.Api/"]
RUN dotnet restore "App.Admin.Api/App.Admin.Api.csproj"
COPY . .
WORKDIR "/src/App.Admin.Api"
RUN dotnet build "App.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Admin.Api.dll"]