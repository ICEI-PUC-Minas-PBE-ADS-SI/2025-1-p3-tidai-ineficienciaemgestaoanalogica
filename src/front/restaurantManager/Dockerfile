FROM node:22 AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .

RUN npm run build --prod

FROM nginx:alpine

COPY --from=build /app/dist/restaurantManager /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
