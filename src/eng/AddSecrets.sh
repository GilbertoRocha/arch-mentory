#!/bin/bash

curl -k -X POST 'https://localhost:8443/management/vault' -H 'accept: application/json' -H 'Content-Type: application/json' -d '{
  "baseUri": "https://mentory.vault.localhost:8443",
  "aliases": [
    "https://alias1.localhost:8443",
    "https://alias2.localhost:8443"
  ],
  "recoveryLevel": "CustomizedRecoverable+Purgeable",
  "recoverableDays": 42,
  "created": 1641092645,
  "deleted": 1641092645
}'

curl -k -X PUT "https://vault.localhost:8443/secrets/DB-CONNECTION?api-version=7.4" \
	-H "Authorization: Bearer dummy" \
	-H "Content-Type: application/json" \
	-H "Host: mentory.vault.localhost:8443"  \
	-d '{"value":"Host=postgres-db;Port=5432;Database=Mentory;Username=postgres;Password=postgres"}'


echo -e "\e[32m Secrets added \e[0m"
