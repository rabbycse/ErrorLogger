FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Asp.NetCore-Log4Net/Asp.NetCore-Log4Net.csproj", "Asp.NetCore-Log4Net/"]
RUN dotnet restore "Asp.NetCore-Log4Net/Asp.NetCore-Log4Net.csproj"
COPY . .
WORKDIR "/src/Asp.NetCore-Log4Net"
RUN dotnet build "Asp.NetCore-Log4Net.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Asp.NetCore-Log4Net.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Asp.NetCore-Log4Net.dll"]