# create a new cluster
k3d cluster create mentory -p "8081:80@loadbalancer" --agents 2

# configure the kubectl to the new cluster
k3d kubeconfig merge mentory --kubeconfig-switch-context

