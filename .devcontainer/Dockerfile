# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal

# Update the package lists for upgrades for packages that need upgrading
RUN apt-get update

# Install ICU dev libraries
RUN apt-get install -y libicu-dev curl vim git wget unzip zip libssl-dev libffi-dev libxml2-dev libxslt1-dev zlib1g-dev 

# Set the working directory in the container
WORKDIR /app

# Install Docker
RUN apt-get install -y apt-transport-https ca-certificates curl software-properties-common && \
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | apt-key add - && \
    add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" && \
    apt-get update && \
    apt-get install -y docker-ce

# Install Docker Compose
RUN curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose && \
    chmod +x /usr/local/bin/docker-compose

# Set the working directory in the container
WORKDIR /app
