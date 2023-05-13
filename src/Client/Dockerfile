FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM caddy:2-alpine
COPY --from=build-env /app/out/wwwroot /usr/share/caddy
COPY Caddyfile /etc/caddy/Caddyfile
