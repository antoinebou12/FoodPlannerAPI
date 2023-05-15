# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal

# Update the package lists for upgrades for packages that need upgrading
RUN apt-get update

# Install ICU dev libraries
RUN apt-get install -y libicu-dev

# Set the working directory in the container
WORKDIR /app