## Objetivo

Definir o design de codigo da aplicação HotLine

### Contexto da aplicação
Hotline vai ser a aplicação responsável por receber as denuncias/contatos dos civis. Em primeira versao vai receber somente denuncias via web browser, simulando um agente da PMA recebendo uma ligação e entrando a denuncia. Essa forma de receber denuncias/contatos pode evoluir, para se aproximar mais do publico civil.


### Opções
- Camadas
- Hexagonal
- Cebola
- Vertical Slice


### Resultado:
O design de codigo utilizado no backend será: Cebola.

#### Racional:
Design de cebola é um design intermediario entre os design mais simples como Camadas ou Vertical Slice, e o complexo hexagonal.

OS design mais simples requerem menor boilerplate de codigo, e permitem um desenvolvimento inicial mais rapido, mas a escalabilidade e evolução fica comprometida pelos seguintes fatores:

- **Em camadas**, a logica fica muito atrelada a tecnologia, portanto tentar escalar em termos tecnologicos, por exemplo, usar outro banco de dados, ou formas de propagar eventos, provavelmente vão gerar um refatoramento muito grande.

- **Vertical Slice** "Purista" cai em uma similar a camadas, com escalomento tecnico mais dificil. A versão um pouco mais flexivel, com uso de repositorio (geralmente com codigo comum compartilhado) te permite uma segregação sobre a logica e tecnologia, mas começa a "corromper" o Design de codigo, necessitando cuidado redobrado para evitar cair para o lado de camadas. Além disso, em um possivel crescimento, a logica poderia ficar repetida, e a evolução para um modelo mais complexo vai necessitar um bom nivel de retrabalho para organizar e unificar os dominios em cada slice.


Sobre os design mais complexos:
- **Hexagonal**, é mais completo e flexivel, mas também o mais complexo, requerindo mais code boilerplate e maior tempo de rampup de desenvolvimento da aplicação. Iniciar uma aplicação com **Hexagonal** leva mais tempo para ter um MVP, portanto é aconselhavel usar esse modelo quando se tem certeza do crescimento da aplicação

*Considerações finais na decisão*
Como existe a expectativa de um crescimento da aplicação, embora não se tenha ainda definido o quanto ela irá crescer ou escalar, o Design de Cebola se encontra como intermediário, permitindo um rampup de desenvolvimento aceitável, assim como permite um nivel de escalabilidade como Cebola, ou ainda permite a evolução para Hexagonal caso necessário, de maneira menos disruptiva e trabalhosa do que os demais design.

