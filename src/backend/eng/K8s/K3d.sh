# create a new cluster
k3d cluster create mentory -p "8081:80@loadbalancer" --agents 2

# configure the kubectl to the new cluster
k3d kubeconfig merge mentory --kubeconfig-switch-context

# add backend webapi to cluster
k3d image import hotline-webapi:latest -c mentory


# apply the deploy and service
kubectl apply -f deployment.yml
kubectl apply -f service.yml


# list of services
kubectl get svc
