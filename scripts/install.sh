#!/bin/bash

# https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
sudo chmod +x ./dotnet-install.sh
./dotnet-install.sh --version latest
./dotnet-install.sh --version 7.0.203
./dotnet-install.sh --version 7.0.203 --runtime dotnet
./dotnet-install.sh --version 7.0.203 --runtime aspnetcore