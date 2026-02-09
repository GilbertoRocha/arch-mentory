# create a new cluster
k3d registry create mentoryregistry.localhost --port 5000
k3d cluster create mentory --registry-create mentoryregistry.localhost:5000 --port "5002:5002@loadbalancer"

# configure the kubectl to the new cluster
k3d kubeconfig merge mentory --kubeconfig-switch-context

# add backend webapi to cluster
k3d image import hotline-webapi:latest -c mentory

# push das imagens
docker tag hotline-webapi:latest localhost:5000/hotline-webapi:latest
docker push localhost:5000/hotline-webapi:latest


# apply the deploy and service
kubectl apply -f deployment.yml
kubectl apply -f service.yml


# list of services
kubectl get svc


