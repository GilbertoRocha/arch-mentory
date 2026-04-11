## Objetivo
### Definir a implementação do uso de Projection

O uso de projections permite a definição de quais dados serão retornados de uma pesquisa, possibilitando que um mesmo metodo de busca possa retornar diferentes visões - Projeções - do resultado da busca.

A biblioteca Ardalis tem a capacidade de projetar resultados, através do uso de `Selectors`, que acabam virando expressões `LINQ`.

Essa abordagem tem suas vantagens, principalmente se considerar em quais camadas ela estará disponivel.

Vamos analizar as vantagens e desvantagens comparando varias camadas.


### Camada mais externa (WebAPI, Brokers, etc)

#### Vantagens

##### Performance
usando os recursos do Ardalis, a projeção vira um `LINQ`, compreendido pelo `EF`, que por sua vez retorna somente os campos que estão na projeção, evitando assim os pesados `SELECT * FROM`.

##### Flexibilidade
Configurado de forma correta, é possivel definir a projeção nas camadas mais externas, como a **WebAPI**, e passar para a **camada de aplicação** a projeção via `Expression<Func<Ticket, TOut>>`, facilitando o reaproveitamento do metodo de busca.








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







