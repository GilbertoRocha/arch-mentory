#!/bin/bash

echo -e "\e[36m Looking for docker \e[0m"
if ! command -v docker &> /dev/null
then
    echo -e "\e[33m Docker not found, installing... \e[0m"

    sudo apt install -y ca-certificates curl gnupg

    # 2. Add Docker's official GPG key:
    sudo install -m 0755 -d /etc/apt/keyrings
    
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
    sudo chmod a+r /etc/apt/keyrings/docker.gpg

    # 3. Add the repository to Apt sources (FORMATO RECOMENDADO ATUAL):
    echo \
      "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
      $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
      sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

    sudo apt update
    sudo apt install -y docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

    # add the docker user
    sudo usermod -aG docker $USER
	
	echo -e "\e[32m Docker installed, version: \e[0m"
    docker --version
else
    echo -e "\e[32m Docker already installed, version: \e[0m"
    docker --version
fi


# Starting docker
echo -e "\e[36m Starting Docker service... \e[0m"
sudo service docker start
sleep 2

sudo chown root:docker /var/run/docker.sock
sudo chmod 666 /var/run/docker.sock


sleep 2

# Verify if the docker is up and running
if sudo docker ps > /dev/null 2>&1; then
    echo -e "\e[32m Docker service is up and running! \e[0m"
else
    echo -e "\e[31m Docker service failed to start. \e[0m"
fi

sleep 5

echo -e "\e[36m Creating folders for KV \e[0m"

# folder for KV volume - Não precisa de sudo para criar na sua Home!
mkdir -p ~/lowkey_data
# Se criou sem sudo, o owner já é você. Mas mantemos por segurança:
sudo chown -R $USER:$USER ~/lowkey_data
chmod -R 777 ~/lowkey_data
