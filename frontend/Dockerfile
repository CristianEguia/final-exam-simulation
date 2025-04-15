# Etapa 1: Build
FROM node:20 AS build
WORKDIR /app

COPY ./src/app/package*.json ./
RUN npm install

COPY ./src/app .
RUN npm run build

# Etapa 2: Servidor de producción con nginx
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html

# Copiar configuración opcional de nginx
COPY default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
