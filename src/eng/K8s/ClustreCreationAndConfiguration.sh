SCRIPT_DIR=$(cd "$(dirname "$0")" && pwd)

echo -e "\e[34m Running chmod \e[0m"

sudo chmod +x ./Dependencies.sh
sudo chmod +x ./InstallK3d.sh
sudo chmod +x ./CreateCluster.sh
sudo chmod +x ./BuildDockerImages.sh
sudo chmod +x ./UpdateImages.sh
sudo chmod +x ./RunPods.sh
sudo chmod +x ./AddSecrets.sh

echo -e "\e[34m updating package list \e[0m"
sudo apt-get update

echo -e "\e[34m Instaling dependencies \e[0m"
./Dependencies.sh

echo -e "\e[34m Starting dependencies \e[0m"
docker compose -f "$SCRIPT_DIR/../compose/docker-compose.yml" up -d

echo -e "\e[34m Adding secrets \e[0m"
./../AddSecrets.sh

echo -e "\e[34m Instaling K3d \e[0m"
./InstallK3d.sh

echo -e "\e[34m Creating Cluster \e[0m"
./CreateCluster.sh

echo -e "\e[34m Building Images \e[0m"
./BuildDockerImages.sh

echo -e "\e[34m Importing Docker Imagens to K3d \e[0m"
./UpdateImages.sh

echo -e "\e[34m Starting the pods \e[0m"
./RunPods.sh


echo -e "\e[34m Pods up and running \e[0m"
echo -e "\e[34m Getting pods \e[0m"

echo -e "\e[34m $(kubectl get pods) \e[0m"

