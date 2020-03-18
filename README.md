# NotesService

Build docker image

```
docker build .
```

Create and run docker container locally

```
docker container run -p 8080:80 --name notes-service-container notes-service
```

Restart docker container (when not running)

```
docker restart notes-service-container
```

Stop docker container

```
docker container stop notes-service-container
```