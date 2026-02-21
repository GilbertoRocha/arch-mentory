## Objetivo
### Definir um novo padrão para o External ID
O External ID é um identificador unico que pode ser exposto para as camadas externas da aplicação, como WebAPI, Messageria e outras formas de integração.

Ele **Não** ser um numero inteiro sequencial (geralmente a Primary key da tabela), pois ao ser exposto fora da aplicação, um numero sequencial pode ser alvo do ataque conhecido como **Insecure Direct Object Reference (IDOR)**, ou ainda o **Broken Object Level Authorization (BOLA)**

Além dos ataques supracitados, gerar um identificador externo realmente unico de forma global, pode evitar problemas quando o numero de microservicos aumentar.

##### Insecure Direct Object Reference (IDOR)
Esse ataque visa em acessar um objeto através de sua referencia (ID, PK, ou qualquer outro idenficador unico), e o alvo do ataque **não** valida se o usuario tem permissão de acesso aquele objeto.

Por exemplo, se no frontend existe um get para clientes `/clientes/125` aonde `125`, é o id do cliente, um atacante pode tentar automatizar uma sequencia de gets entre `125` a `1000`, se a api não validar se o usuario atual pode fazer essa operação, ele vai conseguir os dados.

##### Broken Object Level Authorization (BOLA)
Esse ataque consiste em a API confiar que se o usuario possui um ID valido, ele realmente tem acesso e autorização sobre esse ID, independente se é um sequencial unico ou um External ID complexo e imprevisivel.

Para evitar isso a API deve sempre validar a autorização sobre o acesso do recurso.

### Disclaimer
Como explicado acima, mesmo usando um External ID imprevisivel a api deve validar a autorização de quem fez o request sobre esse Extrenal ID, pois se de alguma forma um atacante consegue pegar um External ID valido, ele vai conseguir fazer o **BOLA** e acessar dados que não poderia.


### Opções para o External ID
- UUIDv4 (GUID)
- Sequential GUID
- Universally Unique Lexicographically Sortable Identifier (ULID)
- Snowflake IDs
- HiLo Algorithm
- Criptografia / Codificação reversivel (Hashids / Id-Encryption, Optimized ID Encryption)
- UUIDv7 (GUID versão 7)


#### UUIDv4 (GUID)
Gera um hash extremamente dificil de se prever o proximo gerado, tornando estatisticamente improvavel um ataque de *IDOR* ou *BOLA*

O ponto negativo é a performance no banco de dados, por ser um hash de alta aleatoriedade, ele gera uma fragmentação de indice muito alta, se tornando pesado para consultas em tabelas com milhares ou milhoes de registros.

#### Sequential GUID
Pega um hash GUID, e substitui partes dele com algum ID sequencial, como timestamp da criação ou um ID sequencial unico (PK) do banco de dados

Embora tenha uma indexação melhor que o GUID, ele acaba se tornando previsivel devido a injeção do ID sequencial.

#### Universally Unique Lexicographically Sortable Identifier (ULID)
É um Hash com estrutura de 128 bits, aonde 48 bits possuem um timestamp e os 80 restantes são aleatórios.

Essa tecnica permite uma indexação mais eficiente no banco de dados, e gera o hash usando Base32, exluindo caracteres mais confusos, deixando a url um pouco mais amigável.

Os pontos negativos são, mesmo gerando um hash bem complexo o timestamp fica no inicio, ou seja, o atacante ainda consegue reduzir o escopo de aleatoriedade, gerando margem para ataques brutos.
Essa tecnica não existe de forma nativa no .net core, ou seja, será necessário desenvolver uma biblioteca interna para isso, ou usar uma externa, o que pode acarretar em criar dependencias do domain para bibliotecas de terceiros.

#### Snowflake IDs
Criado e utilizado pelo X (anteriormente Twitter), é um external ID do tipo inteiro longo, composto por:
- 1 bit de sinal (sempre 0)
- 41 bits para o timestamp gerado (a data referencia para o timestamp pode ser customizada)
- 10 bits para o ID da maquina/worker/container/pod que esta gerando o ID
- 12 bits para a sequencia local 

A vantagem é a indexação muito eficiente no banco de dados (inteiro longo), e ID mais limpos para as URL

O lado negativo é ter que gerir um ID para as maquina/worker/container/pod, se o numero de pods e micro servicos aumentar, isso pode gerar colisões se algum ID da maquina se repetir. Também não tem suporte nativo ao .net core, sendo necessário usar libs de terceiros ou desenvolver a propria.


#### HiLo Algorithm
Sequencial inteiro unico, a aplicação solicita uma faixa exlusiva ao banco (Hi), e vai consumindo esses ID localmente (Lo).

Vantagem de ser extremamente indexável, e ter operações de bulk para inserção com alta eficiencia.

A desvantage é export um sequencial inteiro unico, facilitando muito os ataques de *IDOR* e *BOLA*. Ainda se a aplicação é derrubada ou reiniciada, os Hi alocados são perdidos.


#### Criptografia / Codificação reversivel
O External ID é o ID/PK inteiro e sequencia que passa por um processo de criptografia ou codificação quando é exposto para fora da aplicação, e revertido para o ID/PK original quando recebe ele como input para alguma operação.

Existem algumas estratégias que usam essa mesma linha de pensamento, e todas elas tem a mesma vantagem, que é a indexação extremamente eficiente, pois permite usar a propria PK do registro no banco.

Elas também compartilham uma mesma desvantagem, que é o **Overhead** de CPU, a cada entrada ou saida de dados, esses ID precisam ser processados para criptografia / codificação escolhida, e isso envolve calculos matemáticos que consomem o CPU. Em um cenário com um volume de acessos mais altos, isso pode pesar no cluster.

Cada uma tem alguma vantagem/desvantagem em particular, vamos ver as principais:

**Hashids**, usa uma codificação para o ID, ou seja, usa um algoritmo publico sem segredo, como um Base64, ou então com um "Salt", que ajuda a mascarar o dados. A vantagem é o consumo de CPU um pouco menos intenso que uma criptografia.

A desvantagem é, se usar um algoritmo sem segredo, o ID pode ser descoberto rapidamente. Se usar um "Salt", e esse Salt for descoberto (usando um ataque de força bruta por exemplo), todos os ID ficam expostos. Trocar o Salt pode não ser viável, pois se sistemas externos usam o External ID, ou até mesmo outros micro servicos no cluster usam - e persistem - ele, trocar o salt vai gerar uma desincronia e quebra generalizada no sistema.

**Id-Encryption**, usa uma criptografia real sobre a PK, com uma chave secreta se for simetrico, ou uma publica/privada se for assimetrico.

A vantagem esta em poder usar um algoritmo mais seguro como um AES ou similares, tornando a segurança muito mais alta e muito mais dificil de descobrir a PK.

A desvantagem é o overhead de CPU, esses algoritmos são complexos e demandam bastante da CPU. Outra desvantagem é a URL que começa a ficar mais "Feia".

**Optimized ID Encryption**, usa uma tecnica de criptografia chamada de **Format-Preserving Encryption (FPE)**, que usa uma chave secreta para criptografar a PK, mas a deixa com o mesmo formato da PK, como um inteiro.

A vantagem alem da segurança, é a URL ficar mais amigável.

A desvantagem recai novamente sobre o ovehead de CPU.


#### UUIDv7 (GUID versão 7)
Gera um hash de altissima aleatoriedade, mas ainda assim ordenavel pelo tempo, possuindo na sua estrutura:
- 48 bits para o timestamp (Unix Timestamp)
- 4 bits para a sua versão (fixos em `0111`)
- 12 bits para variantes ou aleatoriedade, ou seja, pode conter frações do tempo para melhorar a precisão, ou apenas aleatoriedade
- 62 bits de aleatoriedade, garantindo que dois containers gerando o mesmo ID no exato milisegundo tenham a chance de colisão virtualmente zero. Também dificulta a previsão dos proximos IDs

Possui uma aleatoriedade considerada segura, e uma indexação bem alta, por conter o timestamp. É possivel extrair a data de criação do registro apenas pelo UUIDv7, sem a necessidade de acessar o banco de dados.


Ele é nativo no .net core 9 e adiante, não precisando de libs extras. O UUIDv7 também segue o padrão **RFC 9562**, ou seja, será compativel com demais dispositivos (como banco de dados)


As desvantages é a exposição do tempo de quando o registro foi criado, isso em algumas situações pode ser uma informação sensivel, por exemplo, saber quando uma denuncia foi feita.

Ele também tem menor entropia que o UUIDv4, embora ainda seja estatisticamente impossivel prever o proximo sequencial.

A legibilidade das URL não fica tão elegante com o UUIDv7, mas não fica tão feia quanto um **Id-Encryption**


## Resultado
O padrão escolhido foi o **UUIDv7 (GUID versão 7)**, que permite um elevado nivel de segurança, baixo consumo de recursos, uma boa indexação, é nativo do .net e ainda é um padrão seguindo o *RFC 9562*, que é mantido pela *IETF (Internet Engineering Task Force)*


