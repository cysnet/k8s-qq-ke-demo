#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["twoapi/twoapi.csproj", "twoapi/"]
RUN dotnet restore "twoapi/twoapi.csproj"
COPY . .
WORKDIR "/src/twoapi"
RUN dotnet build "twoapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "twoapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "twoapi.dll"]