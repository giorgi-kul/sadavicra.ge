FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AcraWebsite/AcraWebsite.csproj", "AcraWebsite/"]
RUN dotnet restore "AcraWebsite/AcraWebsite.csproj"
COPY . .
WORKDIR "/src/AcraWebsite"
RUN dotnet build "AcraWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcraWebsite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcraWebsite.dll"]
