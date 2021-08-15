#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["service/issuetracker/IssueTracker.API/IssueTracker.API.csproj", "service/issuetracker/IssueTracker.API/"]
COPY ["service/issuetracker/IssueTracker.Application/IssueTracker.Application.csproj", "service/issuetracker/IssueTracker.Application/"]
COPY ["service/issuetracker/IssueTracker.Domain/IssueTracker.Domain.csproj", "service/issuetracker/IssueTracker.Domain/"]
COPY ["service/issuetracker/IssueTracker.Infrastructure/IssueTracker.Infrastructure.csproj", "service/issuetracker/IssueTracker.Infrastructure/"]
RUN dotnet restore "service/issuetracker/IssueTracker.API/IssueTracker.API.csproj"
COPY . .
WORKDIR "/src/service/issuetracker/IssueTracker.API"
RUN dotnet build "IssueTracker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IssueTracker.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IssueTracker.API.dll"]