## Objetivo
#### Definir as tecnologia utilizadas para simular o K8s em ambiente de desenvolvimento
Para o ambiente de desenvolvimento, rodar o Kubernets (K8s) pode ser complexo, demorado para configurar e consumir muitos recursos, mas é importante ter um ambiente para testes locais mais proximo do ambiente de produção. Essa ADR foca em verificar as alternativas para ambiente de desenvolvimento, e selecionar a mais adequada.

Por adequada entende-se que seria a alternativa que permita o maior numero possivel de configurações identicas ao K8s, para testar manifestos e configurações localmente. Outro ponto muito importante é a performance, a alternativa deve ser leve, para liberar recursos a outros componentes do desenvolvimento local, como banco de dados. Por ultimo, a instalação e configuração devem ser simplificadas, a ponto de ser criada via script, para permitir configuração de ambiente mais rapida.

Não se faz necessário ter escalabilidade na horizontal, pois teremos apenas a maquina de desenvolvimento local disponivel.



Detalhes sobre o Kubernets pode se encontrado [nessa ADR](ADR%20007%20-%20Orquestracao%20-%20Tecnologia%20utilizada.md)

#### Finalizado em 





##### Kind
Kind (Kubernets in Docker) é uma imagem docker criada pela comunidade e mantida pela CNCF, com o objetivo em facilitar testes.
Essa imagem docker roda um cluster K8s completo, de forma mais leve e sem precisar da criação de VM para servir como node.

##### Prós:
- Cluster K8s totalmente funcional
- Instalação rapida e facil
- 100% compativel com um cluster K8s em produção (uso de manifestos, services, etc)
- Permite criar multiplos nodes no cluster
- Integra muito facil e rapido com CI/CD
- Consegue carregar uma imagem docker diretamente pelo docker, sem precisar acessar um registry, ficando mais simples e muito mais rapido.

##### Cons:
- Embora 100% compativel, não é indicado para produção
- Cada node é um container, então seu escalonamento pode se tornar pesado
- Algumas configurações de infra, como rede, são simplificadas e não refletem ambiente de produção mais complexos
- O LoadBalancer não vem nativo, no WSL2 teria que usar o Cloud Provider KIND ou o MetalLB. `metallb.universe.tf`
- O Ingress não vem nativo.


##### K3s
É uma versão compacta e oficial do K8s, para computação em edge e IoT, feita e distribuida pela Rancher Lab. O objetivo é fornecer um ambiente compativel com o K8s, mas com menor dependencias e extremamente leve, para ambiente de desenvolvimento ou computação em edge.


##### Prós:
- Certificado pela CNCF, ou seja, 100% compativel com o K8s
- Extremamente leve, enquanto um K8s consome 2GB, o k3s vai de 500mb a 800mb
- Ja tem varios add-ons como ingress controller, services Meshes , storage class
- suporte a CRDs (Custom resource definitions), para criação de recursos customizados
- Pode ser utilizado em produção com cluste pequenos, com suporte ao raspberry Pi ou servidores pequenos
- Binario do K3s minusculo, menos de 100mb
- Importa as imagens diretamente pelo docker, evitando passar por algum registry

##### Cons:
- Embora certificado, alguns recuros avançados não estão disponiveis
- Usa o SQL lite ao inves do ETCD, priorizando leveza, mas nao indicado a ambientes maiores


##### K3d
O k3d é a versão do K3s em docker, mas focado em uma distribuição mais rapida e simples.

##### Prós:
- Todos do K3s
- Muito facil e rapido para criar ou deletar um cluster
- Hot reload de configurações, pode adicionar ou remover nodes sem precisar reinicar o cluster


##### Cons:
- Todos do K3s

##### Minikube
É a opção mais antiga e madura entre as alterativas para rodar K8s localmente, usando o docker como camada de abstração para o cluster. Tem todos os recursos oficiais


##### Prós:
- Sistema de add-ons completo e simples, com um comando se ativa ingress e demais recursos avançados que necessitam de configuração manual
- Muito estavel e recebendo atualizações constantes

##### Cons:
- Consome muito recursos localmente.
- O cluster é limitado, geralmente tendo um unico node
- Não indicado a produção



##### MicroK8s
Versão compacta do K8s criada e mantida pela Canonical (mantenedora do Ubuntu). É certificada pela CNCF sendo compativel com o K8s. Oferece uma instalação bem simplificada se usar o Ubuntu.


##### Prós:
- Mais leve que o Minikube
- Add-ons completos e simples de instalar, igual ao Minikube
- Estavel e pronto para produção em edge ou Iot
- Auto atualizavel, pelo snap
- Não polui o Docker, pois gerencia seus proprios containers

##### Cons:
- Não é tão leve quanto o K3s ou o K3d
- A instalação vai carregar o Ubunto



#### Resultado:
Considerando as funcionalidade entregues, consumo de recursos e possibilidade de manter o "ambiente" de desenvolvimento "limpo", a opção selecionada foi a **K3d**