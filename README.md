Preâmbulo
---------
---

Este é um *fork* da biblioteca original, a qual foi descontinuada e teve seu pacote NuGet correspondente removido do repositório público nuget.org.

Este *fork* não possui nenhum recurso e/ou funcionalidade diferente do que já existiu implementado na biblioteca original,
e foi criado única e exclusivamente porque o repositório original foi aparentemente abandonado pelos seus mantenerodes originais
(UOL e equipe PagSeguro). Com isso, a biblioteca original deixou de ser atualizada para suportar as versões mais recentes do .NET Framework (4.8),
e também apresentava erros de sintaxe que impediam a compilação adequada do projeto.

Para resolver tais problemas presentes no repositório original, e também para ter uma base de código sendo devidamente mantida,
criamos este *fork*, o qual tem como intuito manter a biblioteca atualizada e funcional para as versões mais recentes do .NET Framework.

Disponibilizamos um pacote NuGet com a última versão disponível, a qual pode ser encontrada na lista de *releases* desse repositório.
Os pacotes NuGet também encontram-se disponíveis para consumo através do *feed* privado da **Fastchannel** aqui no GitHub:
https://github.com/orgs/fastchannel/packages

Apesar de ser um *feed* privado, o *feed* mencionado acima pode ser consumido por qualquer membro da comunidade GitHub, sem restrições.
Basta criar seu *token* de acesso pessoal (clássico) e configurar o Visual Studio para consumir o *feed* privado da **Fastchannel**:
https://github.com/settings/tokens

Também aceitamos *issues* e *pull requests* para correção de bugs e/ou implementação de novas funcionalidades.

Por fim, caso a UOL e a equipe PagSeguro estejam interessadas em reassumir o desenvolvimento do repositório original,
poderemos realizar um *pull request* de volta ao repositório original, sem problemas ou dificuldades.

**NOTA:** A **Fastchannel** consome ativamente este pacote em seus projetos e atesta que o mesmo encontra-se funcional e estável.

https://www.fastchannel.com

==========================================

`DEPRECATED` # Biblioteca de integração PagSeguro em .NET

> **NOTA: Esse SDK foi descontinuado pela UOL e pela equipe PagSeguro**  
Estamos trabalhando em soluções e facilidades para evoluirmos a Plataforma de API’s do PagSeguro.  
Conheça nossa Plataforma de API’s acessando:  
https://dev.pagseguro.uol.com.br/reference/pagseguro-reference-intro

---
Descrição
---------
---
A biblioteca PagSeguro em .NET é um conjunto de classes de domínio que facilitam,
para o desenvolvedor .NET, a utilização das funcionalidades que o PagSeguro oferece na forma de APIs.
Com a biblioteca instalada e configurada, você pode facilmente integrar funcionalidades como:


 - [Criar Requisições de Pagamentos]
 - [Criar Requisições de assinaturas]
 - [Cancelar Assinaturas]
 - [Consultar Assinaturas]
 - [Consultar Transações por Código]
 - [Consultar Transações por Intervalo de Datas]
 - [Receber Notificações]


Requisitos
----------
---
 - [.NET Framework] 4.8+


Instalação
----------
---
 - Baixe o repositório como arquivo zip ou faça um clone;
 - Descompacte os arquivos em seu computador;
 - Dentro do diretório *source* existem dois diretórios, o *Uol.PagSeguro* e o *Examples*. O diretório *Examples* contém exemplos de chamadas utilizando a API e o diretório *Uol.PagSeguro* contém a biblioteca propriamente dita;
 - Inclua o projeto Uol.PagSeguro.csproj dentro de sua solução;
 - Adicione uma referência ao projeto Uol.PagSeguro.csproj em seu projeto.

Configuração
------------
---
Visando garantir a segurança dos seus dados no PagSeguro, é necessário que você informe suas credenciais de acesso ao executar funções da biblioteca que realizam chamadas via API. As credenciais de acesso são formadas pelo e-mail de cadastro no PagSeguro e um token, que funciona como uma senha.

As chamadas via API exigem que você passe uma instância da classe AccountCredentials que é responsável por encapsular suas credenciais.


Dúvidas?
----------
---
Caso tenha dúvidas ou precise de suporte, abra um chamado conosco [link].


Changelog
---------
---
3.1.5

- Atualização do Framework para 4.8
- Correção de erros de sintaxe presentes no código-fonte do repositório original
- Empacotamento do projeto e disponibilização do pacote NuGet

3.0.0

- Remoção de funcionalidade depreciada (checkout com cartão de crédito internacional)

2.5.1

- Possibilidade de definir parcelamento sem juros.

2.5.0

- Integração com serviço de consulta de Assinaturas (PreApproval) por código de notificação.

2.4.0

- Integração com serviço de modelo de aplicações.
- Possibilidade de definir descontos por meio de pagamento durante a requisição do código de checkout - Ver exemplo createPaymentRequest.php
- Ajustes em geral.

2.3.0

- Adicionado classes e métodos para utilização do Checkout Transparente.

2.2.0

- Integração com serviço de solicitação de estorno.
- Integração com serviço de solicitação de cancelamento.
- Integração com serviço de consulta de transações por código de referência.
- Integração com serviço de consulta de transações abandonadas.
- Ajustes em geral.
- Obs.: Algumas das funcionalidades descritas ainda não estão disponíveis comercialmente para todos os vendedores. Em caso de dúvidas acesse nosso [fórum].

2.1.1

- Ajustes diversos

2.1.0

- Implementação do environment Sandbox
- Validação da implementação de Assinaturas (PreApproval). https://github.com/pagseguro/dotnet/pull/4


2.0.6

 - Opção para retornar apenas o código de checkout no método Register.
 - Atualização do exemplo CreatePayment.

2.0.5

 - Correção no TransactionSearchResult.

2.0.4

 - Atualização dos códigos de meios de pagamento.

2.0.3

 - Atualização da arquitetura em diretorios.
 - Alterado método de envio para HTTP.
 - Adicionado possibilidade de envio de SenderCPF, MetaData e Parameter Generics.

2.0.0 - 2.0.2

 - Classes de domínios que representam pagamentos, notificações e transações.
 - Criação de checkouts via API.
 - Controller para processar notificações de pagamento enviadas pelo PagSeguro.
 - Módulo de consulta de transações.


Licença
-------
---
Copyright 2013 PagSeguro Internet LTDA.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.


Notas
-----
---
 - O PagSeguro somente aceita pagamento utilizando a moeda Real brasileiro (BRL).
 - Certifique-se que o email e o token informados estejam relacionados a uma conta que possua o perfil de vendedor ou empresarial.


Contribuições
-------------
---
Achou e corrigiu um bug ou tem alguma feature em mente e deseja contribuir?

* Faça um fork.
* Adicione sua feature ou correção de bug.
* Envie um pull request no [GitHub].

  [Criar Requisições de Pagamentos]: https://devs.pagseguro.uol.com.br/docs/checkout-web
  [Criar Requisições de assinaturas]: https://devs.pagseguro.uol.com.br/docs/arquivo-documentacoes-depreciadas
  [Cancelar Assinaturas]: https://devs.pagseguro.uol.com.br/docs/arquivo-documentacoes-depreciadas
  [Consultar Assinaturas]: https://devs.pagseguro.uol.com.br/docs/arquivo-documentacoes-depreciadas
  [Consultar Transações por Código]: https://devs.pagseguro.uol.com.br/docs/pagamento-recorrente-consulta-pelo-codigo-de-adesao
  [Consultar Transações por Intervalo de Datas]: https://devs.pagseguro.uol.com.br/docs/pagamento-recorrente-consulta-por-intervalo-de-datas
  [Receber Notificações]: https://devs.pagseguro.uol.com.br/docs/checkout-web-notificacoes
  [link]: https://app.pipefy.com/public/form/k8aKYyJE/?_ga=2.175732066.1759255508.1544013668-532205691.1540442951
  [.NET Framework]: http://www.microsoft.com/net
  [GitHub]: https://github.com/pagseguro/pagseguro-sdk-dotnet
  [documentação oficial]: https://pagseguro.uol.com.br/v2/guia-de-integracao/documentacao-da-biblioteca-pagseguro-netframework.html
