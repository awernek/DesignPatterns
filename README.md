# Design Patterns

Repositório de exemplos de código com **Design Patterns** em C# (.NET), com foco em Clean Code e princípios SOLID.

## Estrutura

```
DesignPatterns/
├── DesignPatterns.Console                 # Aplicação de console para executar os exemplos
├── DesignPatterns.AbstractFactory       # Implementação do padrão Abstract Factory
├── DesignPatterns.AbstractFactory.Tests # Testes do Abstract Factory
├── DesignPatterns.FactoryMethod         # Implementação do padrão Factory Method
├── DesignPatterns.FactoryMethod.Tests   # Testes do Factory Method
├── DesignPatterns.Singleton             # Implementação do padrão Singleton
├── DesignPatterns.Singleton.Tests       # Testes do Singleton
├── DesignPatterns.Adapter               # Implementação do padrão Adapter
├── DesignPatterns.Adapter.Tests         # Testes do Adapter
├── DesignPatterns.Facade                # Implementação do padrão Facade
├── DesignPatterns.Facade.Tests          # Testes do Facade
├── DesignPatterns.Composite             # Implementação do padrão Composite
├── DesignPatterns.Composite.Tests       # Testes do Composite
├── DesignPatterns.Command               # Implementação do padrão Command
├── DesignPatterns.Command.Tests         # Testes do Command
├── DesignPatterns.Strategy              # Implementação do padrão Strategy
├── DesignPatterns.Strategy.Tests        # Testes do Strategy
├── DesignPatterns.Observer              # Implementação do padrão Observer
├── DesignPatterns.Observer.Tests        # Testes do Observer
└── [outros padrões...]
```

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (ou a versão indicada no projeto)

## Como executar

```bash
cd DesignPatterns.Console
dotnet run
```

No menu, escolha o número do padrão que deseja ver em ação.

## Testes

Os testes servem como **documentação executável** do padrão: cada classe de teste destaca um conceito (seletor de fábricas, família de produtos, creators, orquestração).

```bash
dotnet test
```

Detalhes e interpretação dos testes do Abstract Factory: [DesignPatterns.AbstractFactory.Tests/README.md](DesignPatterns.AbstractFactory.Tests/README.md).  
Factory Method: [DesignPatterns.FactoryMethod.Tests/README.md](DesignPatterns.FactoryMethod.Tests/README.md).  
Singleton: [DesignPatterns.Singleton.Tests/README.md](DesignPatterns.Singleton.Tests/README.md).  
Adapter: [DesignPatterns.Adapter.Tests/README.md](DesignPatterns.Adapter.Tests/README.md).  
Facade: [DesignPatterns.Facade.Tests/README.md](DesignPatterns.Facade.Tests/README.md).  
Composite: [DesignPatterns.Composite.Tests/README.md](DesignPatterns.Composite.Tests/README.md).  
Command: [DesignPatterns.Command.Tests/README.md](DesignPatterns.Command.Tests/README.md).  
Strategy: [DesignPatterns.Strategy.Tests/README.md](DesignPatterns.Strategy.Tests/README.md).  
Observer: [DesignPatterns.Observer.Tests/README.md](DesignPatterns.Observer.Tests/README.md).

## Padrões disponíveis

| # | Padrão            | Projeto                    | Descrição                                              |
|---|-------------------|----------------------------|--------------------------------------------------------|
| 1 | Abstract Factory  | DesignPatterns.AbstractFactory | Famílias de produtos (veículo + guincho) por porte. |
| 2 | Factory Method    | DesignPatterns.FactoryMethod | Notificações: Creator com `CriarMensagem` por canal (e-mail, SMS, push). |
| 3 | Singleton         | DesignPatterns.Singleton | Logger único (thread-safe) compartilhado por serviços. |
| 4 | Adapter           | DesignPatterns.Adapter | Checkout usa `IProcessadorPagamento`; `PagSeguroAdapter` traduz a SDK simulada. |
| 5 | Facade            | DesignPatterns.Facade | Pagamentos: `PagamentoFacade` orquestra provedores (PayPal, Mercado Pago, PicPay) e notificação. |
| 6 | Composite         | DesignPatterns.Composite | Arquivos e pastas como `IComponente`: `Arquivo` (folha) e `Pasta` (composto). |
| 7 | Command           | DesignPatterns.Command | Carrinho: comandos concretos + `HistoricoCarrinho` (undo/redo). |
| 8 | Strategy          | DesignPatterns.Strategy | Frete: `Pedido` delega a `IFreteStrategy` (PAC, express, retirada). |
| 9 | Observer          | DesignPatterns.Observer | Status de pedido: subject `Pedido` notifica `IObserver` (e-mail, estoque, fidelidade, rastreio). |

## Tutoriais

Cada padrão tem um `TUTORIAL.md` com: problema resolvido, ideia em uma frase, analogia de memorização, papéis, código-âncora, quando usar / não usar, armadilhas comuns e diferença entre padrões similares.

| Padrão | Tutorial |
|---|---|
| Abstract Factory | [DesignPatterns.AbstractFactory/TUTORIAL.md](DesignPatterns.AbstractFactory/TUTORIAL.md) |
| Factory Method | [DesignPatterns.FactoryMethod/TUTORIAL.md](DesignPatterns.FactoryMethod/TUTORIAL.md) |
| Singleton | [DesignPatterns.Singleton/TUTORIAL.md](DesignPatterns.Singleton/TUTORIAL.md) |
| Adapter | [DesignPatterns.Adapter/TUTORIAL.md](DesignPatterns.Adapter/TUTORIAL.md) |
| Facade | [DesignPatterns.Facade/TUTORIAL.md](DesignPatterns.Facade/TUTORIAL.md) |
| Composite | [DesignPatterns.Composite/TUTORIAL.md](DesignPatterns.Composite/TUTORIAL.md) |
| Command | [DesignPatterns.Command/TUTORIAL.md](DesignPatterns.Command/TUTORIAL.md) |
| Strategy | [DesignPatterns.Strategy/TUTORIAL.md](DesignPatterns.Strategy/TUTORIAL.md) |
| Observer | [DesignPatterns.Observer/TUTORIAL.md](DesignPatterns.Observer/TUTORIAL.md) |

## Convenções

- Cada padrão vive em um projeto separado para isolamento e clareza.
- A console apenas orquestra a execução; a lógica de demonstração fica nos projetos de padrão.
- Código segue SOLID e Clean Code: dependência em abstrações, responsabilidades bem definidas, nomes expressivos.

## Licença

Uso livre para estudo e referência.
