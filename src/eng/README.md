## Conteudo
Essa pasta contém todos os detalhe e script auxiliares com relação a configuração de ambiente, bem como documentação e instruções de uso


### Cluster K8S
Todos os scripts necessários para instalar, criar, configurar e executar o cluster K8s estão na pasta [K8s](./K8s/), possuindo os seguintes arquivos

- [InstallK3d](./K8s/InstallK3d.sh), Arquivo de instalação do K3d, cluster para ambiente de desenvolvimento local

- [ClustreCreationAndConfiguration](./K8s/ClustreCreationAndConfiguration.sh), Cria o cluster em si, ele valida e instala as dependencias, realiza o build das imagens docker da aplicação, configura o cluster, importa e instala as imagens docker, adiciona e configura o Ingress, pods e nodes. Deixa a aplicação rodando no cluster pronta para ser utilizada.

- [CreateCluster](./K8s/CreateCluster.sh), Recria o cluster, mas nao configura ou importa nada.

- [Dependencies](./K8s/Dependencies.sh), Verifica as dependencias para o cluster e instala/cria elas

- [AddSecrets](./AddSecrets.sh), Adiciona as secrets no simulador do KV

- [BuildDockerImages](./K8s/BuildDockerImages.sh), Realiza o build de todas as imagens docker dos projetos desenvolvidos

- [UpdateImages](./K8s/UpdateImages.sh), Importa as imagens docker para o cluster, as imagens com a tag `Latest`

- [RunPods](./K8s/RunPods.sh), Atualiza os pods e o ingress


### Imagens auxiliares docker
O projeto precisa de imagens auxiliares docker:
- Postgres
- PgAdmin
- Low Key (Azure KV Simulator)

Existe um compose que já tem as configurações sugeridas prontas [Neste link](./compose/docker-compose.yml)


## Configurações Windows
Para desenvolver no windows com o docker e cluster rodando no wsl, algumas coisas precisam mudar.

#### Configuração de Hosts
No windows, no arquivo Hosts, localizado geralmente em `C:\Windows\System32\drivers\etc\hosts`, adicione as seguintes linhas:
```
127.0.0.1 mentory.vault.localhost
127.0.0.1 localhost
```


