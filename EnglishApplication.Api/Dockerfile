FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EnglishApplication.Api/EnglishApplication.Api.csproj", "EnglishApplication.Api/"]
RUN dotnet restore "EnglishApplication.Api/EnglishApplication.Api.csproj"
COPY . .
WORKDIR "/src/EnglishApplication.Api"
RUN dotnet build "EnglishApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnglishApplication.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnglishApplication.Api.dll"]
