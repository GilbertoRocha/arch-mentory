# Etapa 1: Build da aplicação Angular
FROM node:24.13-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npx ng build hotline --configuration production

FROM nginx:alpine

# Copiar build gerado (note o /browser no final)
COPY --from=build /app/dist/hotline/browser /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf
COPY <<EOF /etc/nginx/conf.d/default.conf
server {
  listen 80;
  server_name _;
  root /usr/share/nginx/html;
  index index.html;

  # Roteamento SPA
  location / {
    try_files $uri $uri/ /index.html;
  }

  # Arquivos estáticos
  location ~* \.(?:js|css|ico|png|jpg|jpeg|gif|svg|woff2?|ttf|eot)$ {
    expires 1y;
    access_log off;
    add_header Cache-Control "public";
  }
}
EOF

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
