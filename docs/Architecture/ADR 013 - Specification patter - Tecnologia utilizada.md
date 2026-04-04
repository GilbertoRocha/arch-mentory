## Objetivo
### Definir a implementação do padrão Specification

O padrão Specification permite o reaproveitamento de codigo para buscas, mas o codigo necessário para se ter as estruturas pode ser extenso e em alguns casos, verboso.

Além da implementação manual dessa estrutura, vamos verificar quais bibliotecas existem e o que elas nos entregam.


##### Opções avaliadas

- Ardalis.Specification
- NSpecifications
- LinqSpecs
- Implementação Customizada (Vanilla)



## Resultado
A lib escolhida foi **Ardalis.Specification**


### Ardalis.Specification
É uma lib considerada padrão de mercado, uma das mais conhecidas e bem completa. Funciona com o EF, e entrega os seguintes recursos:

- [ x ] Filtros
- [ x ] Includes, para Eager Load de models
- [ x ] Ordenação
- [ x ] Paginação
- [ x ] Projeção, para permitir ler apenas alguns campos conforme uma classe passada por parametro, gerando performance em buscas com muitos registros
- [ x ] Caching, permite marcar uma especificação como "Cacheavel". Ao injetar um servico de cache para essa especificação, o ardalis ja vai usar ele de forma transparente.




### NSpecifications
Biblioteca focada em composição da logica, sendo ideal se a necessidade for validação de regras de negocio em memoria pelas entities, deixando o codigo enxuto pois permite criar especificações in-line. É baseada no livro do Eric Evans.
https://github.com/miholler/NSpecifications

Como estamos buscando criar specificações para o repository, a NSpecification acaba não sendo tão eficiente, por se focar em objetos em memoria


### LinqSpecs
Biblioteca para usar o padrão *specification* como LINQ. Serve para buscas com *IQuerable* como *IEnumerable*, servindo para buscas em memoria e no repository. Embora ela seja mais enxuta inicialmente, a combinação de buscas mais complexas acaba deixando ela em um dilema dificil, ou fica mais verboa e complexa, ou nao se reaproveita o codigo.
Ela ainda permite buscas ad-hoc, ou seja, sem uma especificação proriamente criada, é um recurso flexivel, mas pode ser abusado e causar outros problemas


### Implementação Customizada (Vanilla)
A criação de uma lib customizada é muito tentadora, mas tem alguns problemas:

- Não ser um padrão de mercado dificulta o ingresso de novos devs
- Tempo necessario para seu desenvolvimento é alto
- Senioridade para a criação da lib também deve ser alto







