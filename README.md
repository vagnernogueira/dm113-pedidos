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
- **Cliente SOAP:** Projeto interno `ClientConsoleApp` que consome o serviço SOAP utilizando WCF.
---

### Teste e execução

1. **Executar o Serviço SOAP:**
   - Abra o projeto `dm113-pedidos` no Visual Studio.
   - Compile e execute o projeto.
   - O serviço estará disponível para consumo via HTTP.

2. **Executar o Cliente SOAP:**
   - Abra o projeto `ClientConsoleApp` no Visual Studio.
   - Compile e execute o projeto.
   - O cliente irá consumir o serviço SOAP exposto pelo projeto `dm113-pedidos`.

3. **Testar as Operações:**
    - O projeto `ClientConsoleApp` possui um menu interativo que permite ao usuário testar as operações do serviço SOAP.
    - O usuário pode inserir informações de pedidos, produtos e itens de pedidos, bem como consultar informações existentes.
    - Após executar o projeto, siga as instruções na tela para testar as operações.

## Conclusão

O projeto de implementação de um sistema de pedidos utilizando SOAP e WCF em C# foi desenvolvido com sucesso, demonstrando a capacidade de exposição de serviços SOAP e consumo deles em projeto cliente. O uso de SOAP como tecnologia foi justificado pela sua ampla adopção em ambientes corporativos e indústrias, além de ser uma tecnologia consolidada no ecossistema de desenvolvimento de software.
