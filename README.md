# Apw Digital - GestorLine.Api

_Descri��o do projeto
http://localhost:0000/swagger/index.html

### Deploy
```sh
dotnet publish -c Release
```

### Docker 250417.2
```sh
docker build --no-cache -f Dockerfile -t apwd-lg5-api:19.2 ..

docker tag apwd-lg5-api:19.2 apwsolucoes/apwd-lg5-api:19.2

docker push apwsolucoes/apwd-lg5-api:19.2
------------------
docker pull apwsolucoes/apwd-lg5-api:19.2

docker run -d --restart unless-stopped -p 81:5000 -e ASPNETCORE_URLS="http://+:5000" apwsolucoes/apwd-lg5-api:19.2

curl -X GET "http://localhost:81/api/v1/systeminfo" -H  "accept: text/plain"

```

### Local Docker
```sh
docker run -d --name apwd-lg5-api-v:x -p 81:5000 -e ASPNETCORE_URLS="http://+:5000" apwd-lg5-api-v:x

```




curl -X GET "http://3.226.202.230:81/api/v1/systeminfo" -H  "accept: text/plain"
http://apigestor.espressospeciale.com.br:81/api/v1/systeminfo