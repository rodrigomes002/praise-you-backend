#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PraiseYou.API/PraiseYou.API.csproj", "PraiseYou.API/"]
COPY ["PraiseYou.Application/PraiseYou.Application.csproj", "PraiseYou.Application/"]
COPY ["PraiseYou.Domain/PraiseYou.Domain.csproj", "PraiseYou.Domain/"]
COPY ["PraiseYou.Infrastructure/PraiseYou.Infrastructure.csproj", "PraiseYou.Infrastructure/"]
RUN dotnet restore "PraiseYou.API/PraiseYou.API.csproj"
COPY . .
WORKDIR "/src/PraiseYou.API"
RUN dotnet build "PraiseYou.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PraiseYou.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PraiseYou.API.dll"]