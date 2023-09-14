FROM node:lts-alpine
EXPOSE 80
WORKDIR /clientapp
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
COPY . .
RUN npm install --save && npm i -g typescript vite && npm run build
CMD ["npm", "run", "preview"]