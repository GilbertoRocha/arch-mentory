#!/bin/bash

echo -e "\e[36m Looking for docker \e[0m"
if ! command -v docker &> /dev/null
then
	echo -e "\e[33m Docker not found, instaling... \e[0m"

    # remove old extension, just for safety
    sudo apt-get remove -y docker docker-engine docker.io containerd runc

    sudo apt-get install -y ca-certificates curl gnupg lsb-release

    # add oficial docker key
    sudo mkdir -p /etc/apt/keyrings
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | \
        sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg

    # add docker repo
    echo \
      "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] \
      https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | \
      sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

    # Install
    sudo apt-get install -y docker-ce docker-ce-cli containerd.io docker-compose-plugin

    echo -e "\e[32m Docker installed, version: \e[0m"
	echo -e "\e[32m $(docker --version) \e[0m"	

else
    echo -e "\e[32m Docker already install, version: "
	echo -e "\e[32m $(docker --version) \e[0m"
fi

echo -e "\e[36m Creating folders for KV \e[0m"

# folder for KV volume
sudo mkdir -p ~/lowkey_data
sudo chown -R $USER:$USER ~/lowkey_data
chmod -R 777 ~/lowkey_data