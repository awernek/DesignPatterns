# Testes do Abstract Factory

Estes testes foram escritos para **reforçar o entendimento do padrão Abstract Factory**. Cada classe de teste destaca um aspecto do padrão.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **AutoSocorroFactorySelectorTests** | O **cliente** não conhece as fábricas concretas; usa um seletor que, dado um critério (porte), devolve a fábrica adequada. |
| **AbstractFactoryFamiliaTests** | Cada fábrica concreta produz uma **família** de produtos que combinam entre si (veículo + guincho do mesmo porte). Trocar a fábrica troca toda a família. |
| **VeiculoCreatorTests** / **GuinchoCreatorTests** | Os **creators** encapsulam “qual tipo concreta criar?”; o resto do código depende só da abstração (Veiculo, Guincho). |
| **AutoSocorroTests** | O **AutoSocorro** é o orquestrador: recebe uma fábrica (abstração) e um veículo, e o atendimento usa o par veículo+guincho criado por essa fábrica. |

## Como rodar

Na raiz da solution:

```bash
dotnet test
```

Ou só o projeto de testes:

```bash
dotnet test DesignPatterns.AbstractFactory.Tests
```

## Conceitos que os testes evidenciam

1. **Depender de abstrações (DIP)**  
   Os testes usam `IAutoSocorroFactory` e `IAutoSocorroFactorySelector`; a escolha da implementação concreta fica concentrada no seletor.

2. **Família de produtos**  
   `AbstractFactoryFamiliaTests` garante que, para um dado porte, tanto o veículo quanto o guincho criados pela mesma fábrica têm esse porte — ou seja, são da mesma família.

3. **Extensibilidade (OCP)**  
   Novos portes ou novas famílias exigem novas fábricas e atualização do seletor; o `AutoSocorro` e o fluxo de atendimento não precisam ser alterados.
