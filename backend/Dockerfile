FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 9001
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:9001;http://+:8081

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
# RUN dotnet dev-certs https --trust
RUN dotnet build "./" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["./WebApi/WebApi.xml", "./"]
ENTRYPOINT ["dotnet", "WebApi.dll"]
