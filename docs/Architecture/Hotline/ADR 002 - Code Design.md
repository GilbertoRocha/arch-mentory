## Objetivo

Definir o design de codigo da aplicação HotLine

### Contexto da aplicação
Hotline vai ser a aplicação responsável por receber as denuncias/contatos dos civis. Em primeira versao vai receber somente denuncias via web browser, simulando um agente da PMA recebendo uma ligação e entrando a denuncia. Essa forma de receber denuncias/contatos pode evoluir, para se aproximar mais do publico civil.


### Opções
- 3 Camadas
- Hexagonal
- Onion
- Vertical Slice


### Resultado:
O design de codigo utilizado no backend será: Onion.


#### Sobre os Code Design

##### 3 Camadas
Organiza o codigo em camadas, aonde as camadas mais externas são relacionadas a tecnologia e infraestrutura, iniciando na camada de apresentação, passando por dados e infra e chegando nas mais internas, aonde reside a regra de negócio. A dependencia entre as camadas flui de fora para dentro, aonde a regra de negócio acaba dependente das camadas externas de tecnologia


##### Hexagonal
Organiza o codigo em camadas, aonde a camada mais interna chamada de domain contém extritamente regras de negocio, e qualquer dependencia tecnologica (banco de dados, messageria etc) não é lidado diretamente pelo domain. O Domain apenas usa interfaces (ou Ports), e as camadas mais externas implementam isso. A camada do meio, tambem conhecida como camada da aplicação, faz a instanciação e orquestração das classes concretas para essas interfaçes (chamados de Adapters) e os repassa para as interfaces o domain. A camada mais externa é aonde os Adapter são implementados (messageria, WebAPI, etc). A dependencia é inversa, o Domain não conhece nada de tecnologia, e os adapters são projetados para serem substituidos facilmente


##### Onion
Organiza o codigo em camadas, aonde as camadas mais externas estão relacionadas a tecnologia, e a camada mais interna, chamada de Domain, contém apenas as regras de negocio. A camada intermediaria é da aplicação, que orquestra as chamadas ao Domain, e as camadas externas são as relacionadas puramente a tecnologia, como messageria ou WebAPI. A dependencia flui invertida também, aonde o Dominio não conhece a tecnologia, e as camadas de tecnologia dependem do Dominio.


##### Vertical Slice
Organiza o codigo em "Fatias por Features", aonde cada fatia é isolada e contém tudo aquilo que precisa para funcionar, de forma independente, ou seja, cada fatia vai conter desde a regra de negocio, quanto os detalhes tecnicos necessários.




#### Racional para o Onion
Design de Onion é um design mais complexo, no entanto, mesmo com boilerplate de codigo maior, ele é mais indicado a regras de negocio mais complexas, e considerando que o Hotline possa ter uma expansão de regra de negocio, como validação e analise da denuncia antes de encaminhar ela, um modelo mais robusto é indicado.

Outro ponto importante, como o Onion foca principalmente na camada de Domain, ele permite que o projeto que esteja o utilizando possa ser tanto na arquitetura MicroServico, quanto Service Oriented Architecture (SOA), O HotLine talvez não cresça o suficiente para precisar ser usado a arquitetura em MicroServico, portanto o Onion acaba se encaixando bem com a possivel expansão.


#### Comparação entre o escolhido "Onion" contra os demais code design:


##### 3 camadas
Embora seja um dos design com menor boilerplate de codigo, e mais rapido a entregar algo funcional, a logica fica muito atrelada a tecnologia, portanto tentar escalar em termos tecnologicos, por exemplo, usar outro banco de dados, ou formas de propagar eventos, provavelmente vão gerar um refatoramento muito grande.

Se a regra de negocio tambem for expandida, o que pode acontecer, em 3 camadas vai começar a ficar com a complexidade cognitiva alta, por ter tecnologia e regra de negocio junto no mesmo codigo, podendo gerar mais bugs, e maior demora na entrega de novas features.

Aqui o Onion vence por poder separar a regra de negocio da tecnologia, e permitir um escalonamento se necessário.


##### Vertical Slice 
O Vertical Slice também é um design tem duas formas, a "Purista", aonde cada fatia é completamente independente, e fica em uma situação similar a camadas, com escalomento tecnico mais dificil.
Isso em alguma situação pode gerar codigo duplicado, como por exemplo, operações para salvar um registro pode ser replicada em varias fatias.

Se por acaso for necessário adicionar a propagação de eventos, a duplicação de codigo pode ser ainda maior, e deixar o projeto muito exposto a erros devido a esquecimento. Por exemplo, uma mudança no contrato que define os eventos pode passar desapercebido em alguma fatia, e gerar quebra nos eventos.

A versão um pouco mais flexivel, com uso de repositorio por exemplo, lhe permite uma segregação e reaproveitamento de codigo, mas começa a "corromper" o Design de codigo, necessitando cuidado redobrado para evitar cair para o lado de camadas.

Aqui o Onion vençe de forma similar ao de 3 camadas, a separação da regra de negocio da tecnologia permite um escalonamento, e evita a duplicação de codigo, evitando bugs.


##### Hexagonal 
É bem completo e flexivel, também requer mais code boilerplate e maior tempo de rampup de desenvolvimento da aplicação. Hexagonal tambem permite a separação de regra de negocio (Domain) de tecnologia (Adapters), mas o foco aqui muda um pouco se comparado com Onion.

Enquanto Onion foca em ter a camada de negocio mais estruturada e organizada, Hexagonal acaba colocando uma parte do esforço na criação de adapters, aonde o foco é ter adapters faceis de trocar, permitindo assim realizar integrações de forma mais rapida e flexivel.

Isso acaba caracterizando a Hexagonal, por não gerar tantas camadas na parte de negocio (Domain), esse code design da um suporte um pouco menor a regras de negocio complexas, em comparação ao Onion. Isso faz com que a Hexagonal, que serve tanto para MicroServico quanto SOA, acabe pendendo mais ao lado de MicroServico, com regra de negocio menor, e a necessidade de integrações rapidas e flexiveis.

Nesse caso a Onion vençe pelo melhor suporte a regras complexas, por se encaixar um pouco mais em SOA, e caso necessário, pode-se migrar de Onion para Hexagonal de forma mais simples, permitindo uma evolução do code design caso necessário.