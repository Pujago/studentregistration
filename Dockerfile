FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["StudentRegistration.csproj", "./"]
RUN dotnet restore "./StudentRegistration.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StudentRegistration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentRegistration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentRegistration.dll"]
