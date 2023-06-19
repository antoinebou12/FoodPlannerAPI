FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ShoppingMicroservice.csproj", ""]
RUN dotnet restore "./ShoppingMicroservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ShoppingMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingMicroservice.dll"]
