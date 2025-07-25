# [INATEL � P�s-gradua��o](https://inatel.br/) � [Desenvolvimento Mobile e Cloud Computing](https://inatel.br/pos/desenvolvimento-mobile-e-cloud-computing)

## Disciplina DM113 - Desenvolvimento de servi�o SOAP com WCF em C#

## Prof. Pedro Julio Matuck

### Aluno [Vagner Nogueira](https://github.com/vagnernogueira)<br>

---

# Trabalho da Disciplina<br>

## Atividade proposta

Tecnologias: gRPC ou SOAP
Objetivo: Desenvolver um servi�o de comunica��o entre sistemas distribu�dos, usando os conceitos de chamadas remotas s�ncronas e ass�ncronas, streaming (no caso de gRPC), e modelagem de contratos de servi�o.

---

## Entrega da Atividade

---

### Sistema de Pedidos em SOAP

### Descri��o

Este projeto implementa um servi�o de gerenciamento de pedidos utilizando a tecnologia SOAP (Simple Object Access Protocol) com WCF (Windows Communication Foundation) em C#. O sistema permite que aplica��es cliente consumam os servi�os para consultar, adicionar, atualizar e remover pedidos, produtos e itens de pedidos.

### Justificativa

A escolha do tema "Sistema de Pedidos" foi justificada pela poss�vel simplicidade da implementa��o, facilitando o foco na exposi��o de servi�os SOAP e consumo deles em projeto cliente, ou via ferramenta de testes. Esse tipo de sistema tamb�m � comum em ind�strias, como lojas ou distribuidores de produtos diversos, onde � necess�rio gerenciar pedidos de clientes, aproximando assim a atividade do dia a dia de uma empresa.

A escolha de utilizar o SOAP como tecnologia para o desenvolvimento do sistema de pedidos foi justificada pela larga popularidade do uso de SOAP em ambientes corporativos e ind�strias. Embora SOAP tenha sido tratado como legado com o advento de arquiteturas REST, o uso de SOAP ainda � comum em sistemas corporativos, especialmente em in�meros sistemas mais antigos ainda em opera��o.

### Caracter�sticas Detalhadas do Projeto

- **Servi�o SOAP:** A comunica��o � baseada em SoapCore e WCF, garantindo interoperabilidade entre diferentes plataformas que suportam SOAP.
- **Opera��es CRUD:** O servi�o exp�e m�todos para opera��es completas de Create, Read, Update e Delete para as entidades `Pedido`, `Produto` e `ItemPedido`.
- **Contrato de Servi�o:** A interface `IPedidoService` define o contrato do servi�o, especificando as opera��es dispon�veis e as estruturas de dados.
- **Modelo de Dados:** O sistema utiliza um modelo de dados simples com as entidades `Pedido`, `Produto` e `ItemPedido` para representar as informa��es.
- **Cliente de Console:** Inclui um exemplo de aplica��o cliente de console (`ClientConsoleApp`) que demonstra como consumir os servi�os SOAP expostos.
- **Configura��o Flex�vel:** Utiliza `appsettings.json` para configura��es, permitindo f�cil altera��o de par�metros como a URL do servi�o.

### Divis�o em dois projetos

- **Servi�o SOAP:** Projeto raiz `dm113-pedidos` que implementa o servi�o SOAP utilizando SoapCore. 
- **Cliente SOAP:** Projeto interno `ClientConsoleApp` que consome o servi�o SOAP utilizando WCF com interface em console.

### Arquivos fontes importantes

- `Program.cs`
- `Model/`
  - `ItemPedido.cs`
  - `ModelUtil.cs`
  - `Pedido.cs`
  - `Produto.cs`
- `Service/`
  - `PedidoService.cs`
- `ClientConsoleApp/`
  - `Program.cs`

### Teste e execu��o no Visual Studio

- O reposit�rio cont�m uma �nica pasta raiz `dm113-pedidos` que cont�m a solu��o com dois projetos: `dm113-pedidos` (projeto do servi�o SOAP) e `ClientConsoleApp` (projeto do cliente SOAP).
- No Visual Studio utilize a op��o 'Abrir um projeto ou uma solu��o'. Navegue at� dentro da pasta raiz `dm113-pedidos` e abra o arquivo `dm113-pedidos.sln`.

1. **Executar o Servi�o SOAP:**

- Na barra superior de bot�es do Visual Studio (logo abaixo do menu principal), confirme que est� selecionado o projeto `dm113-pedidos`.
- Clique no bot�o 'Iniciar sem depurar' (�cone de play verde claro) para compilar e executar o projeto. N�o � necess�rio utilizar o modo debub (�cone play verde escuro).
- O servi�o estar� dispon�vel para consumo via HTTP na URL `http://localhost:5168/Service.asmx`.
**NOTA** Caso queira alterar a porta TCP, altere o arquivo `launchSettings.json` na pasta `Properties` do projeto `dm113-pedidos`. Essa altera��o afeta apenas a execu��o atrav�s do Visual Studio, ou seja, em ambiente de desenvolvimento.

2. **Executar o Cliente SOAP:**

- Na barra superior de bot�es do Visual Studio (logo abaixo do menu principal), confirme que est� selecionado o projeto `ClientConsoleApp` ou selecione-o.
- Clique no bot�o 'Iniciar sem depurar' (�cone de play verde claro) para compilar e executar o projeto. N�o � necess�rio utilizar o modo debub (�cone play verde escuro).
- Ao executar o projeto, ser� apresentado menu interativo em aplicativo de console para testar as opera��es do servi�o SOAP.

**NOTA** O aplicativo cliente est� configurado por padr�o para acessar a URL `http://localhost:5168/Service.asmx`. Caso tenha alterado a porta TCP do servi�o SOAP utilize a primeira op��o no meu interativo para informar a URL utilizada (op��o zero do menu). Caso n�o tenha feito altera��es, n�o precisa entrar nessa op��o do menu interativo.

3. **Testar as Opera��es:**

- O projeto `ClientConsoleApp` possui um menu interativo em aplicativo de console que permite ao usu�rio testar as opera��es do servi�o SOAP.
- O usu�rio pode inserir informa��es de pedidos, produtos e itens de pedidos, bem como consultar informa��es existentes.
- Ap�s executar o projeto, siga as instru��es na tela para testar as opera��es.

### Teste e execu��o no Terminal Powershell do windows

- Navegue at� a se��o release deste reposit�rio no github e baixe os arquivos zipados.
- `https://github.com/vagnernogueira/dm113-pedidos/releases/tag/v1.0`
- Descompacte os arquivos em uma pasta de sua prefer�ncia, em um computador windows com dotnet instalado.
- Abra o Terminal Powershell do windows. Navegue at� a pasta onde os arquivos foram descompactados.

1. **Executar o Servi�o SOAP:**

- Execute o arquivo `dm113-pedidos.exe` digitando `.\dm113-pedidos.exe` e pressionando Enter.
- Observe atentamente o log de execu��o no terminal onde ser� mostrado a porta onde o servi�o levantou. 
- Ex: `Now listening on: http://localhost:5000`. Neste caso o servi�o estar� dispon�vel para consumo via HTTP na URL `http://localhost:5000/Service.asmx`.

2. **Executar o Cliente SOAP:**

- Execute o arquivo `ClientConsoleApp.exe` digitando `.\ClientConsoleApp.exe` e pressionando Enter. Ser� exibido o menu interativo.
- Utilize a op��o **zero** do menu para informar a URL do servi�o SOAP previamente levantado. Ex: `http://localhost:5000/Service.asmx`.
- Siga as instru��es na tela para testar as demais opera��es.

**NOTA** Para testes do Servi�o SOAP sem o cliente disponibilizado � recomendado o uso da ferramente SOAPui. Vide: `https://www.soapui.org/downloads/soapui/`

## Conclus�o

O projeto de implementa��o de um sistema de pedidos utilizando SOAP e WCF em C# foi desenvolvido com sucesso, demonstrando a capacidade de exposi��o de servi�os SOAP e consumo deles em projeto cliente. O uso de SOAP como tecnologia foi justificado pela sua ampla adop��o em ambientes corporativos e ind�strias, al�m de ser uma tecnologia consolidada no ecossistema de desenvolvimento de software.

---
