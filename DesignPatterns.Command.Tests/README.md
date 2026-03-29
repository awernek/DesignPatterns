# Testes do Command

Documentação executável do padrão **Command** no exemplo de **carrinho de e-commerce** com undo/redo.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **CarrinhoTests** | **Receiver**: regras de negócio do carrinho sem histórico. |
| **ConcreteCommandTests** | Cada comando encapsula ação + estado para **Undo** (`AdicionarItem`, `AlterarQuantidade`, `AplicarCupom`). |
| **HistoricoCarrinhoTests** | **Invoker**: pilhas undo/redo; novo comando após desfazer zera refazer. |
| **ExecucaoCarrinhoTests** | Demonstração ponta a ponta (sem desfazer adição de produto no roteiro). |

## Como rodar

```bash
dotnet test DesignPatterns.Command.Tests
```

## Conceitos que os testes evidenciam

1. **Separação** — `Carrinho` não sabe de pilha; `HistoricoCarrinho` não sabe de preço ou cupom.
2. **Desfazer** — comandos guardam o mínimo necessário (ex.: quantidade anterior) para reverter.
3. **Macro-operações** — o cliente usa `Executar`/`Desfazer`/`Refazer` sem `switch` por tipo de ação.
