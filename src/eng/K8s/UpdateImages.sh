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