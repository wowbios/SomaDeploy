FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Soma.Client/Soma.Client.csproj", "Soma.Client/"]
RUN dotnet restore "Soma.Client/Soma.Client.csproj"
COPY . .
WORKDIR "/src/Soma.Client"
RUN dotnet build "Soma.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Soma.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soma.Client.dll"]
