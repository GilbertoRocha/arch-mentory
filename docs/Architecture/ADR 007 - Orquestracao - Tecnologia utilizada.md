## Objetivo
#### Definir as tecnologias utilizadas para orquestração de conteiner

#### Finalizado em 15 jan 2026

### Orquestração
Definir como ou o que irá orquestrar os aplicativos, considerando o nivel de autonomia (menos monitoramento e iteração humana possivel), leveza, escalabilidade e downtime necessário para atualização

#### Resultado:
- Kubernet


##### Sobre o Kubernets
o Kubernets (K8s) nasceu na google, em 2014, a partir de um sistema interno chamado Borg, no qual foi tornado opens source, e hoje é mantido pela Cloud Native Computing Foundation (CNCF).

O principal objetivo do K8s é a execução e governança de aplicações rodando em containers (não somente docker), aonde ficam automatizados algumas tarefas criticas como Escalonamento, resiliencia e implantação.

Outro grande objetivo do K8s é a portabilidade entre nuvens, ou seja, aplicações que estejam rodando no K8s, podem ser portadas de maneira mais "facil" e segura entre os grandes provedores de nuvem, como AWS, Azure e Google Cloud, representando uma vantagem caso os custos ou confiança em algum provedor não for satisfatório.

##### Seu funcionamento (Overview)

O K8s pode ser dividido nas seguintes partes: **Cluster**, **Control Plane**, **Nodes**, **Pods**, **Scheduler**, **Controller Manager**, **API Server** e **etcd**

###### Pods
Os pods são a "menor unidade" dentro do K8s, cada pod representa uma aplicação sendo executada dentro do seu container. Existem situações aonde um pod pode conter mais de uma aplicação ou container ao mesmo tempo, conforme alguns patters como *SiderCar*. Cada Pod está contido dentro de um **Node** no K8s

###### Nodes
Os Nodes são em sua essencia, VM ou maquinas fisicas em execução, prontas para receberem os Pods. O K8s aceita ter varios Nodes, formando assim um **Cluster**


###### Cluster
O Cluster é a "maior unidade" dentro do K8s, é um grupo de Nodes sendo orquestrados e configurados, conforme as especificações definidas pelo **Control Plane**

###### Control Plane
O Control plane é um conjunto de varios componentes que gerenciam o estado do cluster, e tomam ações quando necessário. Muitos consideram o Control Plane como o cérebro do cluster, tendo para exercer essa função os componentes: **API Server**, **Scheduler**, **Controller Manager** e o **etcd**

###### API Server
É uma interface de comunição entre o K8s e o ambiente externo, recebendo as instruções dos desenvolvedores (via API ou kubectl), verifica a authenticação e autorização das instruções são validas, e então notifica o **Controller Manager** e o **Scheduler** sobre os novos estados e instruções a serem adotados, e loga no **etcd** a instrução para fins de auditoria.

###### Scheduler
É o componente que decide em qual node um pod deve ser executado. Essa decisão é baseada em uma série de regras, como por exemplo, limites de memoria e CPU que um pod pode ter, regras de prioridades, afinidades (se deve ser executado em conjunto com outro pod no mesmo node) e/ou sem afinidades (não deve ser executado em conjunto com outro pod no mesmo node), numeros de requests que um node já possui, a carga atual de um node e diversas outras regras.

###### Controller Manager
O Controller manager é o componente que fica monitorando os estados dos pods no cluster, a fim de manter o estado atual do cluster da forma como foi configurado. O Controller Manager tem varios *Controllers*, que monitoram o estado e caso detectam alguma discrepancia, o Controller Manager toma uma ação, por exemplo, se precisa ter 3 instancias de um pod, e so encontra 2 instancias, ele gera um novo pod e marca ele para o Scheduler decidir em qual node ele vai instanciar.

###### ETCD
É um banco de dados distribuido, no estilo key-value, que funciona como fonte da verdade para o cluster. Tudo relacionado ao cluster que é criado ou alterado, como pods, deployments, secrets, configurações e etc, é armazenado no etcd, e posteriormente lido dos demais componentes.

Como todo banco de dados, é necessário se ter rotinas de backups, uma configuração propria para alta disponibilidade (em produção, recomenda-se rodar ao menos em nodes o etcd), e em alguns casos de cluster muito grandes, alguns tunnings para ganho de performance.



##### Prós:
- Escalavel automaticamente
- Resiliencia, gerenciando carga de trabalho e reiniciando imagens com falha
- Portavel entre varios provedores de nuvem
- Gestão dos clusters e imagens centralizado
- Integração com CI/CD

##### Cons:
- Curva de aprendizagem alta, podendo gerar custos
- Configuração incial complexa e sujeita a erros
- Observabilidade em sistemas distribuidos é mais complexo