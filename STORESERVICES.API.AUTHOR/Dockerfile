#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["STORESERVICES.API.AUTHOR/STORESERVICES.API.AUTHOR.csproj", "STORESERVICES.API.AUTHOR/"]
COPY ["STORESERVICES.API.AUTHOR.SERVICES/STORESERVICES.API.AUTHOR.SERVICES.csproj", "STORESERVICES.API.AUTHOR.SERVICES/"]
COPY ["STORESERVICES.API.AUTHOR.DAO/STORESERVICES.API.AUTHOR.DAO.csproj", "STORESERVICES.API.AUTHOR.DAO/"]
COPY ["STORESERVICES.API.AUTHOR.MODEL/STORESERVICES.API.AUTHOR.MODEL.csproj", "STORESERVICES.API.AUTHOR.MODEL/"]
RUN dotnet restore "STORESERVICES.API.AUTHOR/STORESERVICES.API.AUTHOR.csproj"
COPY . .
WORKDIR "/src/STORESERVICES.API.AUTHOR"
RUN dotnet build "STORESERVICES.API.AUTHOR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "STORESERVICES.API.AUTHOR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "STORESERVICES.API.AUTHOR.dll"]