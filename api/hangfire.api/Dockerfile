#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 4001
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["hangfire.api/hangfire.api.csproj", "hangfire.api/"]
RUN dotnet restore "hangfire.api/hangfire.api.csproj"
COPY . .
WORKDIR "/src/hangfire.api"
RUN dotnet build "hangfire.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hangfire.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hangfire.api.dll"]