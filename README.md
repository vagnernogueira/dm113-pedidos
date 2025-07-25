# [INATEL – Pós-graduação](https://inatel.br/) – [Desenvolvimento Mobile e Cloud Computing](https://inatel.br/pos/desenvolvimento-mobile-e-cloud-computing)

## Disciplina DM113 - Desenvolvimento de serviço SOAP com WCF em C#

## Prof. Pedro Julio Matuck

### Aluno [Vagner Nogueira](https://github.com/vagnernogueira)<br>

---

# Trabalho da Disciplina<br>

## Atividade proposta

Tecnologias: gRPC ou SOAP
Objetivo: Desenvolver um serviço de comunicação entre sistemas distribuídos, usando os conceitos de chamadas remotas síncronas e assíncronas, streaming (no caso de gRPC), e modelagem de contratos de serviço.

---

## Entrega da Atividade

---

### Sistema de Pedidos em SOAP

### Descrição

Este projeto implementa um serviço de gerenciamento de pedidos utilizando a tecnologia SOAP (Simple Object Access Protocol) com WCF (Windows Communication Foundation) em C#. O sistema permite que aplicações cliente consumam os serviços para consultar, adicionar, atualizar e remover pedidos, produtos e itens de pedidos.

### Justificativa

A escolha do tema "Sistema de Pedidos" foi justificada pela possível simplicidade da implementação, facilitando o foco na exposição de serviços SOAP e consumo deles em projeto cliente, ou via ferramenta de testes. Esse tipo de sistema também é comum em indústrias, como lojas ou distribuidores de produtos diversos, onde é necessário gerenciar pedidos de clientes, aproximando assim a atividade do dia a dia de uma empresa.

A escolha de utilizar o SOAP como tecnologia para o desenvolvimento do sistema de pedidos foi justificada pela larga popularidade do uso de SOAP em ambientes corporativos e indústrias. Embora SOAP tenha sido tratado como legado com o advento de arquiteturas REST, o uso de SOAP ainda é comum em sistemas corporativos, especialmente em inúmeros sistemas mais antigos ainda em operação.

### Características Detalhadas do Projeto

- **Serviço SOAP:** A comunicação é baseada em SoapCore e WCF, garantindo interoperabilidade entre diferentes plataformas que suportam SOAP.
- **Operações CRUD:** O serviço expõe métodos para operações completas de Create, Read, Update e Delete para as entidades `Pedido`, `Produto` e `ItemPedido`.
- **Contrato de Serviço:** A interface `IPedidoService` define o contrato do serviço, especificando as operações disponíveis e as estruturas de dados.
- **Modelo de Dados:** O sistema utiliza um modelo de dados simples com as entidades `Pedido`, `Produto` e `ItemPedido` para representar as informações.
- **Cliente de Console:** Inclui um exemplo de aplicação cliente de console (`ClientConsoleApp`) que demonstra como consumir os serviços SOAP expostos.
- **Configuração Flexível:** Utiliza `appsettings.json` para configurações, permitindo fácil alteração de parâmetros como a URL do serviço.

### Divisão em dois projetos

- **Serviço SOAP:** Projeto raiz `dm113-pedidos` que implementa o serviço SOAP utilizando SoapCore. 
- **Cliente SOAP:** Projeto interno `ClientConsoleApp` que consome o serviço SOAP utilizando WCF com interface em console.

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

### Teste e execução no Visual Studio

- O repositório contém uma única pasta raiz `dm113-pedidos` que contém a solução com dois projetos: `dm113-pedidos` (projeto do serviço SOAP) e `ClientConsoleApp` (projeto do cliente SOAP).
- No Visual Studio utilize a opção 'Abrir um projeto ou uma solução'. Navegue até dentro da pasta raiz `dm113-pedidos` e abra o arquivo `dm113-pedidos.sln`.

1. **Executar o Serviço SOAP:**

- Na barra superior de botões do Visual Studio (logo abaixo do menu principal), confirme que está selecionado o projeto `dm113-pedidos`.
- Clique no botão 'Iniciar sem depurar' (ícone de play verde claro) para compilar e executar o projeto. Não é necessário utilizar o modo debub (ícone play verde escuro).
- O serviço estará disponível para consumo via HTTP na URL `http://localhost:5168/Service.asmx`.
**NOTA** Caso queira alterar a porta TCP, altere o arquivo `launchSettings.json` na pasta `Properties` do projeto `dm113-pedidos`. Essa alteração afeta apenas a execução através do Visual Studio, ou seja, em ambiente de desenvolvimento.

2. **Executar o Cliente SOAP:**

- Na barra superior de botões do Visual Studio (logo abaixo do menu principal), confirme que está selecionado o projeto `ClientConsoleApp` ou selecione-o.
- Clique no botão 'Iniciar sem depurar' (ícone de play verde claro) para compilar e executar o projeto. Não é necessário utilizar o modo debub (ícone play verde escuro).
- Ao executar o projeto, será apresentado menu interativo em aplicativo de console para testar as operações do serviço SOAP.

**NOTA** O aplicativo cliente está configurado por padrão para acessar a URL `http://localhost:5168/Service.asmx`. Caso tenha alterado a porta TCP do serviço SOAP utilize a primeira opção no meu interativo para informar a URL utilizada (opção zero do menu). Caso não tenha feito alterações, não precisa entrar nessa opção do menu interativo.

3. **Testar as Operações:**

- O projeto `ClientConsoleApp` possui um menu interativo em aplicativo de console que permite ao usuário testar as operações do serviço SOAP.
- O usuário pode inserir informações de pedidos, produtos e itens de pedidos, bem como consultar informações existentes.
- Após executar o projeto, siga as instruções na tela para testar as operações.

### Teste e execução no Terminal Powershell do windows

- Navegue até a seção release deste repositório no github e baixe os arquivos zipados.
- `https://github.com/vagnernogueira/dm113-pedidos/releases/tag/v1.0`
- Descompacte os arquivos em uma pasta de sua preferência, em um computador windows com dotnet instalado.
- Abra o Terminal Powershell do windows. Navegue até a pasta onde os arquivos foram descompactados.

1. **Executar o Serviço SOAP:**

- Execute o arquivo `dm113-pedidos.exe` digitando `.\dm113-pedidos.exe` e pressionando Enter.
- Observe atentamente o log de execução no terminal onde será mostrado a porta onde o serviço levantou. 
- Ex: `Now listening on: http://localhost:5000`. Neste caso o serviço estará disponível para consumo via HTTP na URL `http://localhost:5000/Service.asmx`.

2. **Executar o Cliente SOAP:**

- Execute o arquivo `ClientConsoleApp.exe` digitando `.\ClientConsoleApp.exe` e pressionando Enter. Será exibido o menu interativo.
- Utilize a opção **zero** do menu para informar a URL do serviço SOAP previamente levantado. Ex: `http://localhost:5000/Service.asmx`.
- Siga as instruções na tela para testar as demais operações.

**NOTA** Para testes do Serviço SOAP sem o cliente disponibilizado é recomendado o uso da ferramente SOAPui. Vide: `https://www.soapui.org/downloads/soapui/`

## Conclusão

O projeto de implementação de um sistema de pedidos utilizando SOAP e WCF em C# foi desenvolvido com sucesso, demonstrando a capacidade de exposição de serviços SOAP e consumo deles em projeto cliente. O uso de SOAP como tecnologia foi justificado pela sua ampla adopção em ambientes corporativos e indústrias, além de ser uma tecnologia consolidada no ecossistema de desenvolvimento de software.

---
