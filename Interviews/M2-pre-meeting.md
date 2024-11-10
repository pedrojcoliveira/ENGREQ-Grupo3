# ENGREQ-Grupo3

## Stakeholders' Pre-Meeting #2

### Stakeholders

* Responsável da AMAP
* Responsável da FAIR - PM
* Responsável da FAIR - BA

### Questões Estruturadas

#### Questões sobre Interfaces com Sistemas Externos

##### Questões para Responsável AMAP

* Pretende que a nova aplicação partilhe dados com algum sistema/aplicação externo?
* Se sim:
  * Que tipo de dados devem ser partilhados?
  * Em que formato devem os dados serem partilhados? JSON, XML, Word, PDF?
  * Existem algumas APIs específicas que a nova API devem consumir ou fornecer? (Ex: Facebook, Google/Gmail)? Se sim, quais os requerimentos de autenticação dessas APIs?
  * Com que frequência devem ser partilhados dados com os sistemas externos?
  * Qual o volume de dados experado para a partilha de dados?
* Se não, considera relevante a aplicação estar preprada para tal? A quem gostaria de disponibilizar a informação e que tipo de dados gostaria de partilhar (Produtos, Clientes, Produtores, Estatísticas, etc)?

##### Questões para Responsável da FAIR - PM

* Prevê a existência de alguma restrição técnica para a integração com sistemas externos, caso a nova app precise de comunicar com estes?
* Quais são as tecnologias ou protocolos para comunição externa que prefere utilizar? REST, SOAP, ou outra?
* Quanto a segurança, que medidas considera necessárias e suficientes para a partilha de dados?
* Que requerimentos para cifras e tokens costumam considera mais pertinentes para uso em partilha de dados que considera minimamente seguros? E quais os que considera ideais?
* Quanto a tratamentos de erros, como devem geridos os erros de comunicação com sistemas externos? Considera relevante implementar-se um sistema de logs e outro de retries? Que tipos de sistemas considera suficiente?
* Em termos de performance, quão performante deve ser a nova app na partilha de dados com sistemas externos? Costumam procurar atingir alguma meta quanto a questões de latência e volume de dados partilhados?

#### Outros requisitos não funcionais

##### Questões para Responsável AMAP

* Quais são os tempos de resposta esperados para várias operações (por exemplo, login de utilizador, procura de produtos)?
* Que KPIs de performance devem ser atingidos pelo sistema?
* Quantos utilizadores simultâneos prevê?
* É importante que o sistema seja escalável, ie, quais as prespectivas de crescimento da AMAP?
* Existem padrões específicos de acessibilidade que a aplicação deve cumprir (por exemplo, WCAG)?
* Quais são as expectativas para o design da UI e UX que tem para a app? - nota: esta questão faz sentido também a produtores e consumidores
* Esta aplicação deverá cumprir o RGPD, certo? Quais são as políticas de retenção de dados da AMAP que a app deve seguir?
* A app precisa suportar múltiplos idiomas ou configurações regionais por ex. Mirandês ou Inglês ou basta Português (PT)?
  * Se sim, como deve ser realizada as traduções/localização? Pretende que seja seguido algum padrão?

##### Questões para Responsável da FAIR - PM

* No seu entender, considera que a aplicação deve ser de desenhada de tal forma que seja fácil de atualizar e manter operacional?
* Quantos recursos terá alocado ao suporte da app?
* Que tipo de documentação deve acompanhar a app? Existem alguns elementos considerados obrigatórios ou pelo menos extremamente importantes? Por ex: Diagramas UML, espeficificação técnica. etc?
* Passando para questões de backup e recuperação de dados da app, considera backups importantes?
  * Em todo caso, existindo backups com que frequência considera suficiente estas serem realizadas e também retidas?
  * Mais, de que forma pretende fazer backups?  Em que servidores estas serão alojadas?
    Qual é o tempo de recuperação, em caso de falha do sistema, que considera aceitável para a aplicação?
  * De forma geral, isto resume-se, no seu entender, quão robusto deve ser o sistema atendendo aos recursos alocados ao projeto? nota: tentar não tocar no BA e sacar info do PM aqui.
* No seu entender, deve de existir um sistema secundário, espelho daquele de produção, pronto a entrar ao serviço sempre que o sistema de produção primário falhe? Mais, para questões de manutênção, considera relevante existir uma terceira cópia/servidor, na empresa, para análise de bugs e teste de novas funcionalidades?
  * E tocando nisto, onde considera relevante ser alojada a aplicação? Descentralizada em nuvem, em servidores da empresa, mantidos por esta, ou em servidores do cliente mantidos tanto pela empresa ou por terceiros?

##### Questões para Responsável FAIR-BA

* Qual o orçamento alocado à aplicação?
* A empresa firmou contracto de manutênção com FAIR? Se sim por quanto tempo?
* Quanto prevê gastar em servidores e manutenção da aplicação e por quanto tempo?

#### Descrição geral do sistema

##### Responsável AMAP

* Como cada que cada produtor remunerado por cada cabaz vendido?
  * Mais especificamente, o consumidor paga à AMAP e esta paga o devido a cada produtor ou o consumidor paga diretamente ao produtor?
  * Ou existem as duas possibilidades?
    * Se sim, pode fornecer algumas situações-exemplo?
