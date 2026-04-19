# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ["FIAP.Hackathon.OES.User.Domain/FIAP.Hackathon.OES.User.Domain.csproj", "FIAP.Hackathon.OES.User.Domain/"]
COPY ["FIAP.Hackathon.OES.User.Infra/FIAP.Hackathon.OES.User.Infra.csproj", "FIAP.Hackathon.OES.User.Infra/"]
COPY ["FIAP.Hackathon.OES.User.Service/FIAP.Hackathon.OES.User.Service.csproj", "FIAP.Hackathon.OES.User.Service/"]
COPY ["FIAP.Hackathon.OES.User.API/FIAP.Hackathon.OES.User.API.csproj", "FIAP.Hackathon.OES.User.API/"]

RUN dotnet restore "FIAP.Hackathon.OES.User.API/FIAP.Hackathon.OES.User.API.csproj"

COPY . .

WORKDIR "/app/FIAP.Hackathon.OES.User.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime

RUN addgroup -S appgroup && adduser -S appuser -G appgroup

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:3001
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 3001

HEALTHCHECK --interval=30s --timeout=5s --retries=3 \
  CMD wget -qO- http://localhost:3001/health || exit 1

USER appuser

ENTRYPOINT ["dotnet", "FIAP.Hackathon.OES.User.API.dll"]