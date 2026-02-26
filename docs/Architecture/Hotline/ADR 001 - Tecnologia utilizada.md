## Objetivo
#### Definir as tecnologias utilizadas ao longo do projeto


### FrontEnd
Definir que tecnologia permite criar um FrontEnd moderno e desacoplado do backend, com possibilidade de ser migrado para Micro FrontEnd e permitindo testes unitários e E2E

#### Resultado:
- Angular

##### Prós
- Framework moderno
- Bem conhecido no mercado
- Comunidade grande e ativa
- Diversas Bibliotecas existentes
- Estável
- Performático
- Possui padrão de codigo MVVM, facilitando a leitura do codigo por desenvolvedores diferentes
- Permite componentização
- Permite ser evoluido para micro frontend de maneira menos dolorida
- Usa Typescript


##### Cons
- Pode gerar bundle gigantes
- Pode induzir a criar componentes mais complexos do que precisa
- Em alguns casos excepcionais, a performance pode degradar, especialmente se nao for codado com performancem em mente
- Curva de aprendizagem maior


### Backend
Definir a tecnologia para construir o backend, aond eprecisa ter atualizações frequentes, com otima performance e consumo equilibrado de recursos, permitindo testes unitários e de integração

#### Resultado:
- Dotnet Core


##### Prós
- Framework estável e performático
- Atualizações constantes
- Open Source e gratuito
- Possui diversas libs
- Multiplataforma
- Linguagem elegante

##### Cons
- Comunidade menor que java/javascript/python
- Embora OpenSource, as melhores IDE (vs e rider) são pagas
- Curva de aprendizagem pode ser maior
- Ainda imaturo em termos de IA


### Database
Definir qual database relacional será utilizado no projeto, considerando custos de licença, escalonamento, atualizado com frequencia e permite buscas complexas.

#### Resultado:
- Postgres

##### Prós
- Robusto para aplicações complexas
- Open Source e gratuito
- Comunidade grande e ativa
- Permite consultas complexas
- Escalavel


##### Cons
- Ferramentas graficas inferiores ao SQL server e Oracle
- Tuning pode ser complicado



### Distribuição
Definir a forma como os aplicativos serão distribuidos, considerando velocidade de deploy, velocidade de inicialização, recursos necessários e escalabilidade.

#### Resultado:
- Docker

##### Prós:
- Extremamente mais leve que VM
- Permite escalonamento mais facil (!)
- Integração com CI/CD
- Portabilidade

##### Cons:
- Atenção para persistencia de dados (Volumes)
- Dependencia de demais ferramentas para escalar e gerenciar
- Atenção extra para não vazar segredos nas imagens


### Orquestração
Definir como ou o que irá orquestrar os aplicativos, considerando o nivel de autonomia (menos monitoramento e iteração humana possivel), leveza, escalabilidade e downtime necessário para atualização

#### Resultado:
- Kubernet

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