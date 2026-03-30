#!/bin/bash

echo -e "\e[36m Checking for .NET 10... \e[0m"

# 1. Verifica se o binário do dotnet existe
if command -v dotnet &> /dev/null
then
    # 2. Se existe, verifica se a versão 10.0 está na lista de runtimes ou SDKs
    # O comando 'dotnet --list-sdks' retorna algo como "10.0.100 [/usr/share/dotnet/sdk]"
    if dotnet --list-sdks | grep -q "^10\.0"
    then
        echo -e "\e[32m .NET 10 is already installed. Version: $(dotnet --version) \e[0m"
    else
        echo -e "\e[33m Other .NET versions found, but .NET 10 is missing. Installing... \e[0m"
        
        sudo add-apt-repository ppa:dotnet/backports -y
        sudo apt-get update
        sudo apt-get install -y dotnet-sdk-10.0
    fi
else
    echo -e "\e[31m .NET not found. Installing .NET 10 SDK... \e[0m"
    
    sudo apt-get update
    sudo apt-get install -y wget apt-transport-https
    sudo add-apt-repository ppa:dotnet/backports -y
    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-10.0
fi

# Validação final
if dotnet --list-sdks | grep -q "^10\.0"; then
    echo -e "\e[32m .NET 10 check passed! \e[0m"
else
    echo -e "\e[31m .NET 10 check failed. \e[0m"
fi
