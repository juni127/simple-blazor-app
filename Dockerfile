# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
COPY ./ /app/
WORKDIR /app
RUN dotnet publish -c Release

# Production Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY --from=build /app/bin/Release/net7.0/publish /app
WORKDIR /app
EXPOSE 5000
ENTRYPOINT ["./SimpleBlazorApp", "--urls", "http://0.0.0.0:5000"]