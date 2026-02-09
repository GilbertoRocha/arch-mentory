# delete cluster
k3d cluster delete mentory

# create a new cluster
k3d registry create mentoryregistry.localhost --port 5000
k3d cluster create mentory --registry-create mentoryregistry.localhost:5000 --port "5002:5002@loadbalancer" --port "4200:80@loadbalancer"

# configure the kubectl to the new cluster
k3d kubeconfig merge mentory --kubeconfig-switch-context

# add images to cluster
k3d image import hotline-webapi:latest -c mentory
k3d image import hotline-frontend:latest -c mentory

# push das imagens
#back
docker tag hotline-webapi:latest localhost:5000/hotline-webapi:latest
docker push localhost:5000/hotline-webapi:latest
#front
docker tag hotline-frontend:latest localhost:5000/hotline-frontend:latest
docker push localhost:5000/hotline-frontend:latest


# apply the deploy and service
kubectl apply -f deployment.yml
kubectl apply -f service.yml


# list of services
kubectl get svc


