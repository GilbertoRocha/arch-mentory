### Configuração para o .env
##### DB_CONNECTION
Deverá conter a connection string para a base de dados principal

##### ASPNETCORE_URLS
Deverá conter a(s) URL(s) para acesso a webapi

##### ASPNETCORE_ENVIRONMENT
Deverá indicar se o ambiente é de desenvolvimento, testes ou producao:
- `Development`, ambiente de desenvolviment
- `Staging`, ambiente de testes/homologação
- `Production`, ambiente de produção
Caso o valor não seja preenchido, o default é `Production`