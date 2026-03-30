#!/bin/bash

echo -e "\e[36m Looking for K3d \e[0m"

if ! command -v k3d &> /dev/null
then 
    echo -e "\e[33m K3d not found, instaling... \e[0m"    

    sudo apt-get install -y curl

    curl -s https://raw.githubusercontent.com/k3d-io/k3d/main/install.sh | bash

    echo -e "\e[32m K3d installed, version: \e[0m"
	echo -e "\e[32m $(k3d --version) \e[0m"	    
else
    echo -e "\e[32m K3d Already installed, version: \e[0m"
	echo -e "\e[32m $(k3d --version) \e[0m"	    
fi



echo -e "\e[36m Looking for Kubectl... \e[0m"
if ! command -v kubectl &> /dev/null
then

    echo -e "\e[33m Kubectrl not found, instaling... \e[0m"    

    sudo apt-get install -y apt-transport-https ca-certificates curl gnupg
	sudo mkdir -p /etc/apt/keyrings
	

    # add key of GPG
	curl -fsSL https://pkgs.k8s.io/core:/stable:/v1.30/deb/Release.key | sudo gpg --dearmor -o /etc/apt/keyrings/kubernetes-apt-keyring.gpg

    # add lkubernets repo
    echo 'deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.30/deb/ /' | sudo tee /etc/apt/sources.list.d/kubernetes.list
	

    sudo apt-get install -y kubectl

    echo -e "\e[32m Kubectl installed, version: \e[0m"
	echo -e "\e[32m $(kubectl version --client) \e[0m"
else
    echo -e "\e[32m Kubectl already installed, version: \e[0m"
	echo -e "\e[32m $(kubectl version --client) \e[0m"
fi