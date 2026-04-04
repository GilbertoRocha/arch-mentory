## Conteudo
Essa pasta contém todos os detalhe e script auxiliares com relação a configuração de ambiente, bem como documentação e instruções de uso


### Cluster K8S
Todos os scripts necessários para instalar, criar, configurar e executar o cluster K8s estão na pasta [K8s](./K8s/), possuindo os seguintes arquivos

- [InstallK3d](./K8s/InstallK3d.sh), Arquivo de instalação do K3d, cluster para ambiente de desenvolvimento local

- [ClustreCreationAndConfiguration](./K8s/ClustreCreationAndConfiguration.sh), Cria o cluster em si, ele valida e instala as dependencias, realiza o build das imagens docker da aplicação, configura o cluster, importa e instala as imagens docker, adiciona e configura o Ingress, pods e nodes. Deixa a aplicação rodando no cluster pronta para ser utilizada.

- [CreateCluster](./K8s/CreateCluster.sh), Recria o cluster, mas nao configura ou importa nada.

- [Dependencies](./K8s/Dependencies.sh), Verifica as dependencias para o cluster e instala/cria elas

- [AddmigrationSecrets](./AddMigrationSecrets.sh), Adiciona as secrets para a migration no simulador do KV, considerando que as migrations são executadas de fora do cluster

- [AddSecrets](./AddSecrets.sh), Adiciona as secrets no simulador do KV

- [InstallDotNet](./../scripts/InstallDotnetCore.sh), Instala o dotnet core (necessário para rodar as migrations)

- [BuildDockerImages](./K8s/BuildDockerImages.sh), Realiza o build de todas as imagens docker dos projetos desenvolvidos

- [UpdateImages](./K8s/UpdateImages.sh), Importa as imagens docker para o cluster, as imagens com a tag `Latest`

- [RunMigrations](./RunMigrations.sh), Roda as migrations, usando o KV para buscar a connection string

- [RunPods](./K8s/RunPods.sh), Atualiza os pods e o ingress

- [InstallOpenLens](./InstallOpenLens.sh), Instala um gerenciador grafico de cluster K8s


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

### WSL
Esse é um guia para instalar o WSL e preparar o ambiente, o resultado final pode ser usado como ambiente de desenvolvimento, ou um ambiente efemero para testes.

#### Configurando o WLS
Primeiro, baixe o .wls no [site oficial da Canonical](https://ubuntu.com/download/wsl), esse readme esta usando a versao 24.04.

##### Registrando o Ubuntu
Use esse comando para registrar um novo wsl com o nome de **UbuntuTeste**, o caminho especificado é um sugerido aonde eu baixei o .wsl do site, mas deve ser alterado conforme o seu diretorio:
`wsl --import UbuntuTeste D:\WSL\Ubuntu\Testes "D:\WSL\Ubuntu\Ubuntu2404-250130_x64.wsl"`

**Atenção** o primeiro path indica aonde o vhdx vai ser criado, esse arquivo pode ocupar muito espaço, então cuidado para não sobrecarregar a partição que contem o windows.

Após instalado, ative ele:
`wsl -d UbuntuTeste`

Com ele ativo, pode-se copiar o bash abaixo e colar no terminal, aonde é criado um usuario sem senha chamado *user*, para instalar tudo o que precisa, inclusive baixar o repo. Sinta-se livre para mudar o diretorio do repo ou o usuario.
```Bash
cd / && apt update && apt install -y sudo && \
useradd -m -s /bin/bash user && \
echo "user:user" | chpasswd && \
usermod -aG sudo user && \
echo "user ALL=(ALL) NOPASSWD:ALL" | tee /etc/sudoers.d/user && \
chmod 0440 /etc/sudoers.d/user && \
su user -c "
  mkdir -p ~/repo && \
  cd ~/repo && \
  sudo apt install git -y && \
  git clone https://github.com/GilbertoRocha/arch-mentory.git && \
  cd ~/repo/arch-mentory/src/eng/K8s && \
  git fetch origin develop && \
  git checkout develop && \
  chmod +x ./ClustreCreationAndConfiguration.sh && \
  ./ClustreCreationAndConfiguration.sh
"

```



