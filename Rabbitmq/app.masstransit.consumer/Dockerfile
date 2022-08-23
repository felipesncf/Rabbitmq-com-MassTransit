#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["app.masstransit.consumer/app.masstransit.consumer.csproj", "app.masstransit.consumer/"]
RUN dotnet restore "app.masstransit.consumer/app.masstransit.consumer.csproj"
COPY . .
WORKDIR "/src/app.masstransit.consumer"
RUN dotnet build "app.masstransit.consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "app.masstransit.consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "app.masstransit.consumer.dll"]