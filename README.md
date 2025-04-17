# Apw Digital - GestorLine.Api

_Descri��o do projeto
http://localhost:0000/swagger/index.html

### Deploy
```sh
dotnet publish -c Release
```

### Docker
```sh
docker build --no-cache -f Dockerfile -t apwd-lg5-api:19.1 ..

docker run -d -p 82:82 apwd-lg5-api:19.1

docker run -d --restart unless-stopped -p 81:5000 -e ASPNETCORE_URLS="http://+:5000" apwsolucoes/apwd-lg5-api-v:x

```

### Local Docker
```sh
docker run -d --name apwd-lg5-api-v:x -p 81:5000 -e ASPNETCORE_URLS="http://+:5000" apwd-lg5-api-v:x

```