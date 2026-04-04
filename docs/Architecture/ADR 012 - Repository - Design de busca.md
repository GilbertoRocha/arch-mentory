## Objetivo
### Definir um padrão para realizar buscas no repositório

O pattern **Repository** pode apresentar uma "Fragilidade", ele pode ficar com inumeros metodos para retorno dos dados. Isso pode levar a repetição de codigo, ou aumento da complexidade, pois conforme o Domain evolui, mais e mais formas de recurparar os dados sreão necessárias


##### Requisitos para o patter de buscas

- [ x ] Permite criar criterios ou filtros mais granulares possivel, permitindo reuso e testes unitario
- [ x ] Permite criar filtros compostos, ou seja, reaproveitando criterios já existentes para criar filtros mais complexos, sem duplicação de codigo


## Resultado
O padrão escolhido foi o **Specification**


### Specification
Esse padrão visa em criar *especificações* para cada busca. Cada especificação pode ser contida em uma unica classe, que vai possuir todos os criterios necessários para a busca. 
Nesse padrão temos dentro do repositório um metodo de busca genérico, que vai receber como parametro uma classe de especificação, que vai utilizar os criterios nela estabelecidos para montar a busca.

Isso permite o reaproveitamento da especificação em varios pontos, e também o reaproveitamento dos criterios em varias especificações. Cada especificação e criterio podem ser testados unitariamente



