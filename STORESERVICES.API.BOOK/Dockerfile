#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["STORESERVICES.API.BOOK/STORESERVICES.API.BOOK.csproj", "STORESERVICES.API.BOOK/"]
COPY ["STORESERVICES.API.BOOK.SERVICES/STORESERVICES.API.BOOK.SERVICES.csproj", "STORESERVICES.API.BOOK.SERVICES/"]
COPY ["STORESERVICES.API.BOOK.DAO/STORESERVICES.API.BOOK.DAO.csproj", "STORESERVICES.API.BOOK.DAO/"]
COPY ["STORESERVICES.API.BOOK.MODEL/STORESERVICES.API.BOOK.MODEL.csproj", "STORESERVICES.API.BOOK.MODEL/"]
RUN dotnet restore "STORESERVICES.API.BOOK/STORESERVICES.API.BOOK.csproj"
COPY . .
WORKDIR "/src/STORESERVICES.API.BOOK"
RUN dotnet build "STORESERVICES.API.BOOK.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "STORESERVICES.API.BOOK.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "STORESERVICES.API.BOOK.dll"]