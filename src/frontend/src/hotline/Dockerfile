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
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
