## Objetivo
### Definir a implementação do uso de Projection

O uso de projections permite a definição de quais dados serão retornados de uma pesquisa, possibilitando que um mesmo metodo de busca possa retornar diferentes visões - Projeções - do resultado da busca.

A biblioteca Ardalis tem a capacidade de projetar resultados, através do uso de `Selectors`, que acabam virando expressões `LINQ`.

Essa abordagem tem suas vantagens, principalmente se considerar em quais camadas ela estará disponivel.

Vamos analizar as vantagens e desvantagens comparando varias camadas.


### Camada mais externa (WebAPI, Brokers, etc)

#### Vantagens

##### Performance
Usando os recursos do Ardalis, a projeção vira um `LINQ`, compreendido pelo `EF`, que por sua vez retorna somente os campos que estão na projeção, evitando assim os pesados `SELECT * FROM`.

##### Flexibilidade
Configurado de forma correta, é possivel definir a projeção nas camadas mais externas, como a **WebAPI**, e passar para a **camada de aplicação** a projeção via `Expression<Func<Ticket, TOut>>`, facilitando o reaproveitamento do metodo de busca. É possivel partir para flexibildade total, ao tornar o metodo de retorno da camada de aplicação mais genérico, permitindo inclusive inferir o tipo do retorno



#### Desvantagens

##### Maior complexidade no código
Usando a flexibilidade total, ou seja, inferindo até o tipo de retorno da camada de aplicação gera muito code boilerplate, principalmente se tiver que definir novos tipos de retorno para cada chamada. É possivel diminuir o boilerplate passando expressions como parametro para a aplicação, mas isso reduz a legibilidade do código.



### Camada intermediária (Aplicação)


#### Vantagens


##### Performance
Da mesma forma que na camada mais externa, a projeção vira um `LINQ`.


##### Maior controle
Com a aplicação controlando a projeção, as camadas mais externas acabam apenas consumindo o que já esta disponibilizado, evitando delegar controle da aplicação para as camadas externas, ficando mais aderente ao padrão *Onion*



#### Desvantagens

##### Aplicação pode ficar inchada
Uma vez que a aplição vai reter as projeções, ela pode ficar inchada pois vai precisar disponibilizar as projeções para cada consumidor.
Isso pode levar a outro problema, se o tipo do retorno for correspondente a projeção, teremos varios metodos com sobrecarga, gerando mais complexidade. Esse problema pode ser mitigado se tornarmos o metodo genérico o suficiente.


## Resultado



