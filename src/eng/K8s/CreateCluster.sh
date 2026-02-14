# delete cluster
echo -e "\e[35m Deleting cluster if exists \e[0m" 
k3d cluster delete mentory

# create a new cluster
echo -e "\e[32m Creating new cluster \e[0m"
k3d cluster create mentory --registry-create mentoryregistry.localhost:5000 --port "80:80@loadbalancer" --port "443:443@loadbalancer"
