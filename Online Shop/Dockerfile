FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Online Shop/Online Shop.csproj", "Online Shop/"]
RUN dotnet restore "Online Shop/Online Shop.csproj"
COPY . .
WORKDIR "/src/Online Shop"
RUN dotnet build "Online Shop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Online Shop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Online Shop.dll"]
