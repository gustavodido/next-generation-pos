#!/bin/bash 

docker run --name next-generation-pos-postgres -p 8093:5432 -e POSTGRES_DB=next-generation-pos -e POSTGRES_USER=next-generation-pos -e POSTGRES_PASSWORD=next-generation-pos --rm -d postgres