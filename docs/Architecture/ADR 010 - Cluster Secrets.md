## Objetivo
#### Definir qual tecnologia utilizar para lidar com secrets
Para um ambiente seguro, é importante controlar os acessos a recursos, como connection string da base de dados de produção. Não é uma boa prática deixar essas informações expostas, e tão pouco deixar essas informações hardcoded, dificultando a rotatividade delas.


#### Finalizado em



### Opções

- Bitnami Sealed Secrets
- External Secrets Operator (Azure Key Vault)
- Doppler 
- HashiCorp Vault


#### Bitnami Sealed Secrets
Realiza uma criptografia dos secrets usando uma chave publica do cluster, ficando seguro para publicar o conteudo na code base

##### Vantagens
- Simplicidade para o dev
- A criptografia é segura

##### Desvantagens
- Rotatividade da chave requer um novo commit, PR e deploy. Em casos de emergencia isso pode significar indisponibilidade maior do sistema


##### External Secrets Operator (ESO)
Usar operadores externos de secrets, como o Azure Key Vault ou o AWS Secrets Manager permite uma segregação das secrets e sua governaça e da aplicação (cluster) em si. Isso incrementa a segurança, permitindo uma granularidade de acesso a nivel de pessoa, aonde uma pessoa pode ter acesso ao ESO, mas nao ter acesso ao cluster, e vice-versa.

##### Vantagens
- Maior governança sobre as secrets
- Rotatividade de secrets desacoplada de deploy
  - Se utilizado com Secrets Store CSI Driver (SSCD), o SSCD detecta automaticamente alterações em secrets e repassa a aplicação, que pode estar preparada para fazer o reload sem precisar reinicar o pod, usando por exemplo o recurso `reloadOnChange` e `IOptionsMonitor`


##### Desvantagens
- Valor envolvido
- Alguns deles são dependentes do provedor de cloud, como por exemplo, o Azure Key Vault integra muito facil no Azure, mas requer maior trabalho se o cluster ficar na AWS


#### HashiCorp Vault
Projeto open source agnostico para gerenciamento de segredos, funcionando muito bem em on-premise ou qualquer provedor de cloud.

##### Vantagens
- Open source sem custos
- Muito flexivel
- Permite rotatividade automática


##### Desvantagens
- Mais complexo para se configurar e manter
- Consome mais recursos do cluster


## Resultado

### Azure key Vault
O Azure key vault integra perfeitamente com AKS, e para ambientes de desenvolvimento existe o **Low-key Vault**, que é um simulador de AKV local e offline, já com uma imagem em docker para executar. O Low-Key Vault tem algums particularidades no seu setup, que podem ser feitas quando a aplicação esta em ambiente de desenvolvimento, mas o SDK funciona igual para o Azure Key Vault, permitindo usar o AKV em ambientes de stg ou produção sem qualquer mudança.