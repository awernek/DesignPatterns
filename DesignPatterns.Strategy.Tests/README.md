# Testes do Strategy

Documentação executável do padrão **Strategy** no exemplo de **cálculo de frete**.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **FreteStrategyTests** | Cada **concrete strategy** encapsula um algoritmo distinto (PAC, express, retirada). |
| **PedidoTests** | O **context** (`Pedido`) só depende de `IFreteStrategy`; troca de estratégia altera o resultado sem mudar o pedido. |
| **ExecucaoStrategyTests** | Demonstração completa: resumos com troca de modalidade e laço polimórfico na comparação. |

## Como rodar

```bash
dotnet test DesignPatterns.Strategy.Tests
```

## Conceitos que os testes evidenciam

1. **DIP** — `Pedido` conhece a interface, não as classes concretas de frete.
2. **Aberto/fechado** — novas modalidades = nova classe `IFreteStrategy`; `Pedido` permanece estável.
3. **Composição** — a estratégia é injetada no construtor e pode ser trocada em tempo de execução (`TrocarStrategy`).
