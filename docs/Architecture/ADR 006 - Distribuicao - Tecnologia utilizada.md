## Objetivo
#### Definir as tecnologias utilizadas para forma de distribuição da aplicação

#### Finalizado em 15 jan 2026


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
