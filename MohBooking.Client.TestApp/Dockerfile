FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MohBooking.Client.TestApp/MohBooking.Client.TestApp.csproj", "MohBooking.Client.TestApp/"]
RUN dotnet restore "MohBooking.Client.TestApp/MohBooking.Client.TestApp.csproj"
COPY . .
WORKDIR "/src/MohBooking.Client.TestApp"
RUN dotnet build "MohBooking.Client.TestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MohBooking.Client.TestApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MohBooking.Client.TestApp.dll"]
