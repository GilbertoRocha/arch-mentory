# apply the deploy and service
#back
echo -e "\e[34m Applying backend pods \e[0m"
kubectl apply -f hotline/backend/deployment.yml
kubectl apply -f hotline/backend/service.yml
kubectl apply -f hotline/backend/databaseService.yml

#front
echo -e "\e[34m Applying fronted pods \e[0m"
kubectl apply -f hotline/frontend/deployment.yml
kubectl apply -f hotline/frontend/service.yml


echo -e "\e[34m Applying ingress \e[0m"
kubectl apply -f ./ingress.yml


# list of services
echo -e "\e[32m getting services in K3d... \e[0m"
echo -e "\e[32m $(kubectl get svc) \e[0m"
