# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY BookApi.csproj ./
RUN dotnet restore ./BookApi.csproj

# Copy the remaining source code
COPY . ./

# Build the application in release mode
RUN dotnet publish ./BookApi.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

# Copy published files from build image
COPY --from=build /app/out ./

# Optionally set environment variables (uncomment and set as needed)
# ENV ASPNETCORE_URLS=http://+:8080

# Set the entrypoint to run the API on container startup
ENTRYPOINT ["dotnet", "BookApi.dll"]
