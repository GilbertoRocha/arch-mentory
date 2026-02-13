# delete cluster
k3d cluster delete mentory

# create a new cluster
k3d cluster create mentory --registry-create mentoryregistry.localhost:5000 --port "80:80@loadbalancer" --port "443:443@loadbalancer" #--port "5002:5002@loadbalancer" --port "4200:80@loadbalancer"
