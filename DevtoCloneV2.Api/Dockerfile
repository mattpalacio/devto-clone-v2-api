#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DevtoCloneV2.Api/DevtoCloneV2.Api.csproj", "DevtoCloneV2.Api/"]
RUN dotnet restore "DevtoCloneV2.Api/DevtoCloneV2.Api.csproj"
COPY . .
WORKDIR "/src/DevtoCloneV2.Api"
RUN dotnet build "DevtoCloneV2.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevtoCloneV2.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevtoCloneV2.Api.dll"]