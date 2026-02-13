# apply the deploy and service
#back
kubectl apply -f hotline/backend/deployment.yml
kubectl apply -f hotline/backend/service.yml
kubectl apply -f hotline/backend/databaseService.yml

#front
kubectl apply -f hotline/frontend/deployment.yml
kubectl apply -f hotline/frontend/service.yml


kubectl apply -f ./ingress.yml


# list of services
kubectl get svc
