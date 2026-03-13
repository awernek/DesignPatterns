# Design Patterns

Repositório de exemplos de código com **Design Patterns** em C# (.NET), com foco em Clean Code e princípios SOLID.

## Estrutura

```
DesignPatterns/
├── DesignPatterns.Console           # Aplicação de console para executar os exemplos
├── DesignPatterns.AbstractFactory    # Implementação do padrão Abstract Factory
├── DesignPatterns.AbstractFactory.Tests   # Testes que ajudam a entender o padrão
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

## Padrões disponíveis

| # | Padrão            | Projeto                    | Descrição                                              |
|---|-------------------|----------------------------|--------------------------------------------------------|
| 1 | Abstract Factory  | DesignPatterns.AbstractFactory | Famílias de produtos (veículo + guincho) por porte. |

## Convenções

- Cada padrão vive em um projeto separado para isolamento e clareza.
- A console apenas orquestra a execução; a lógica de demonstração fica nos projetos de padrão.
- Código segue SOLID e Clean Code: dependência em abstrações, responsabilidades bem definidas, nomes expressivos.

## Licença

Uso livre para estudo e referência.
