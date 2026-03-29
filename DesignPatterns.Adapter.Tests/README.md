# Testes do Adapter

Documentação executável do padrão **Adapter** no exemplo de gateway de pagamento (PagSeguro).

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **PagSeguroAdapterTests** | O adapter traduz chamadas do **Target** (`IProcessadorPagamento`) para o **Adaptee** (`PagSeguroApi`): tipos e formato de retorno diferentes. |
| **ServicoDeCheckoutTests** | O **cliente** depende só da abstração; um fake de `IProcessadorPagamento` prova que o checkout não acopla ao PagSeguro. |
| **ExecucaoAdapterTests** | A cadeia completa Adaptee → Adapter → `ServicoDeCheckout` gera a saída esperada na demonstração. |

## Como rodar

```bash
dotnet test DesignPatterns.Adapter.Tests
```

## Conceitos que os testes evidenciam

1. **Separação Target / Adaptee** — o domínio fala `IProcessadorPagamento`; a SDK mantém seus próprios métodos.
2. **Object Adapter** — `PagSeguroAdapter` recebe `PagSeguroApi` por construtor (composição, testável e alinhado a DIP).
3. **Cliente estável (OCP)** — novos gateways entram com novos adapters; `ServicoDeCheckout` permanece igual.
