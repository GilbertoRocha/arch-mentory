echo "Running chmod"

chmod +x ./CreateCluster.sh
chmod +x ./BuildDockerImages.sh
chmod +x ./UpdateImages.sh
chmod +x ./RunPods.sh


echo "Creating Cluster"

./CreateCluster.sh

echo "Building Docker Images"
./BuildDockerImages.sh

echo "Importing the Docker Images"
./UpdateImages.sh

echo "Starting the pods"
./RunPods.sh

echo "Pods up and running"

kubectl get pods