## Objetivo
#### Definir as tecnologias utilizadas para orquestração de conteiner

#### Finalizado em 15 jan 2026

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