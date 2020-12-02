#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster AS build
WORKDIR /app
COPY . .
#COPY ["src/PublicApi/PublicApi.csproj", "./PublicApi/"]
#RUN dotnet restore "./PublicApi/PublicApi.csproj"
#COPY . .
WORKDIR "/app/src/PublicApi"
RUN dotnet restore

RUN dotnet build "./PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PublicApi.csproj" -c Release -o /app/publish

FROM base AS final

# Add Filebeat
RUN apt-get update && apt-get install curl -y && \
 curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-7.10.0-amd64.deb
RUN dpkg -i filebeat-7.10.0-amd64.deb
ADD filebeat.yml /etc/filebeat/filebeat.yml

WORKDIR /app
COPY --from=publish /app/publish .

CMD bash -c "nohup filebeat -c filebeat.yml &" && dotnet PublicApi.dll"]