# Testes do Facade

Documentação executável do padrão **Facade** no exemplo de **pagamento com múltiplos provedores**.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **PagamentoFacadeTests** | Um único `Pagar(...)` roteia para PayPal, Mercado Pago ou PicPay; em caso de sucesso, a notificação roda depois da cobrança. Valida provedor e identificador. |
| **ExecucaoFacadePagamentoTests** | A execução de demonstração cobre os três provedores em sequência. |

## Como rodar

```bash
dotnet test DesignPatterns.Facade.Tests
```

## Conceitos que os testes evidenciam

1. **Subsistemas heterogêneos** — APIs diferentes (`Cobrar`, `RealizarCobranca`, `EfetuarPagamento`) ficam atrás de uma única fachada.
2. **Orquestração** — cobrança e, se bem-sucedida, confirmação por e-mail na ordem correta.
3. **Não é uma prisão** — o teste `PayPal_PodeSerUsadoForaDaFacade` mostra que o subsistema continua acessível diretamente quando fizer sentido.
4. **Composição (DIP)** — `PagamentoFacade` recebe dependências pelo construtor, o que facilita testes e substituições futuras.
