#!/bin/bash

# Cores para o output
GREEN='\033[0;32m'
BLUE='\033[0;34m'
NC='\033[0m'

echo -e "${BLUE}Iniciando a instalação do k3d e ferramentas auxiliares...${NC}"

# 1. Verificar se o Docker está instalado
if ! command -v docker &> /dev/null; then
    echo "Erro: Docker não encontrado. Por favor, instale o Docker primeiro."
    exit 1
fi

# 2. Instalar k3d
echo -e "${GREEN}Instalando k3d...${NC}"
curl -s https://raw.githubusercontent.com | TAG=v5.6.0 bash

# 3. Instalar kubectl (caso não tenha)
if ! command -v kubectl &> /dev/null; then
    echo -e "${GREEN}Instalando kubectl...${NC}"
    curl -LO "https://dl.k8s.io(curl -L -s https://dl.k8s.io)/bin/linux/amd64/kubectl"
    sudo install -o root -g root -m 0755 kubectl /usr/local/bin/kubectl
    rm kubectl
fi

# 4. Verificar versões instaladas
echo -e "${BLUE}--- Versões Instaladas ---${NC}"
k3d --version
kubectl version --client
