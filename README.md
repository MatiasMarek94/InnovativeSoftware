# Innovative Software course project - Backend

## Running production environment

Timezone is set to CET.

```
docker-compose up
```

## Running development environmnet

Ability to access [Swagger UI](http://localhost:8080/swagger). Timezone is set to CET.

```
docker-compose -f docker-compose.development.yml up
```

## Pushing new docker version to dockerhub

(Requires Dstoft user credentials)

```
docker build -t dstoft/inno-backend .
docker push dstoft/inno-backend
```
