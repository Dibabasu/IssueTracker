#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["apigateways/OcelotApiGateWay/OcelotApiGateWay.csproj", "apigateways/OcelotApiGateWay/"]
RUN dotnet restore "apigateways/OcelotApiGateWay/OcelotApiGateWay.csproj"
COPY . .
WORKDIR "/src/apigateways/OcelotApiGateWay"
RUN dotnet build "OcelotApiGateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApiGateWay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApiGateWay.dll"]
